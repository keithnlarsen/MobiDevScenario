properties {
    $framework = '4.5'
    $rootDir = (Resolve-Path $pwd\..\)
    $solutionFile = (Resolve-Path $rootDir\*.sln)
    $clientProjectFile = (Resolve-Path $rootDir\Formatster.UI.Wpf\Formatster.UI.Wpf.csproj)
    $testAssembly = "Formatster.Tests"
    $buildDir = (Join-Path $rootDir build)
    $buildArtifactsDir = (Join-Path $rootDir build-artifacts)
    $buildOutputDir = (Join-Path $buildArtifactsDir output)
    $packagesDir = (Join-Path $rootDir packages)
    $version = if ("$version".length -gt 0) { "$version" } else { '1.0.0' }
    $buildNumber = if ("$buildNumber".length -gt 0) { "$buildNumber" } else { '1' }
    $informationalVersion = if ("$informationalVersion".length -gt 0) { "$informationalVersion" } else { 'Developer Build' }
    $nUnitVersion = "2.6.2"
}

task default -Depends Clean, Compile, UnitTest

FormatTaskName {
    param($taskName)
    Import-Module "$buildDir\modules\Format-TaskNameToHost"

    Format-TaskNameToHost $taskName
}

task Clean -Description "Deletes the build artifacts directory and runs a 'clean' on the solution" { 
    if (Test-Path $buildArtifactsDir) {
        Remove-Item $buildArtifactsDir -Recurse -Force -ErrorAction SilentlyContinue
    }
    Exec { msbuild $solutionFile /t:clean } "Could not clean the project"
}

task SetVersion -Description "Sets the version number in 'AssemblyInfo.cs'" {
    Import-Module "$buildDir\modules\Update-AssemblyVersions"
    Update-AssemblyVersions $version $buildNumber $informationalVersion
}

task MakeBuildDir -Description "Creates the build artifacts directory" {
    if (-not (Test-Path $buildArtifactsDir)) {
        New-Item $buildArtifactsDir -ItemType Container
    }
}

task Compile -Depends Clean, MakeBuildDir, SetVersion -Description "Compiles the application" {
    # There is a bug in msbuild that doesn't allow us to specify the buildnumber or assembly version at the command CommandLine
    # Such as: "/p:ApplicationRevision=$buildNumber" "/p:ApplicationVersion=$version"
    Exec { msbuild $solutionFile "/p:Configuration=Release" "/p:OutDir=$buildOutputDir\" } "Build Failed - Compilation"
}

task UnitTest -Depends Compile -Description "Runs only Unit Tests" {
    $targetDll = Resolve-Path $buildOutputDir\$testAssembly.dll
    $xmlFile = "$buildArtifactsDir\UnitTest-Results.xml"
  
    Exec { & $packagesDir\NUnit.Runners.$nUnitVersion\tools\nunit-console.exe /run:$testAssembly.Unit "$targetDll" /xml="$xmlFile" } "Unit Tests Failed"
}

task ? -Description "Helper to display task info.  In addition to passing a task into the build, you can pass parameters in the form of: -parameters @{env='local',version'X.X.X.X'}" {
    Write-Documentation
}

function PostPackageCleanup() {
    if (Test-Path $buildOutputDir) {
        Remove-Item $buildOutputDir -Recurse -Force -ErrorAction SilentlyContinue
    }

    if (Test-Path $buildPublishDir) {
        Remove-Item $buildPublishDir -Recurse -Force -ErrorAction SilentlyContinue
    }
}