<#
    .DESCRIPTION
        Will setup a web application under the specified Website and AppPool.

    .EXAMPLE
        New-Application "Mudtrack" "apps.marquisalliance.com" "C:\inetpub\apps.marquisalliance.com\mudtrack" "Mudtrack"

    .PARAMETER appName
        The name of the application.

    .PARAMETER appPath
        The physical path where this application is located on disk.

    .PARAMETER siteName
        The name of the website that contains this application.

    .PARAMETER appPoolName
        The application pool that this application runs under.

    .PARAMETER updateIfFound
        With this switch passed in, the Applications PhysicalPath will be updated to point to the new AppPath provided, otherwise, if it already exists it will just be left alone.

    .SYNOPSIS
        Will setup a web application under the specified Website and AppPool.
#>

Import-Module WebAdministration

function New-Application
{
    param(
        [parameter( Mandatory=$true, position=0 )] [string] $appName,
        [parameter( Mandatory=$true, position=1 )] [string] $appPath,
        [parameter( Mandatory=$true, position=2 )] [string] $siteName,
        [parameter( Mandatory=$true, position=3 )] [string] $appPoolName,
        [parameter( Mandatory=$false, position=4 )] [switch] $updateIfFound
    )

    $ErrorActionPreference = "Stop"

    Write-Output "Creating new Web Application: $appName"
    $TestWebApp = Get-WebApplication -Name $appName
    
    if ($TestWebApp -eq $null) {
        New-WebApplication -Site $siteName -Name $appName -PhysicalPath $appPath -ApplicationPool $appPoolName
        Write-Output "Created Web Application: $appName"
    } else {
        if ($updateIfFound.isPresent) {
            Write-Output "Application '$appName' already exists."
            Set-ItemProperty IIS:\Sites\$siteName\$appName -Name PhysicalPath -Value $appPath
            Write-Output "Updated PhysicalPath to: '$appPath'."
            Set-ItemProperty IIS:\Sites\$siteName\$appName -Name ApplicationPool -Value $appPoolName
            Write-Output "Updated ApplicationPool to:'$appPoolName'."
        } else {
            Write-Output "Application '$appName' already exists, not updating you must specify the '-updateIfFound' if you wish to update the application settings."
        }
    }
}

Export-ModuleMember New-Application