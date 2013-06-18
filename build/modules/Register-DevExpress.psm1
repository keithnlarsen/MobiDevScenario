<#
    .DESCRIPTION
        This will register DevExpress on the computer which it is run.

    .EXAMPLE
        Register-Product "121" "Somebiglonghashvaluethatmatchesthekeyneeded=="

    .PARAMETER LicenseKeyVerion
        The version of the software you are registering

    .PARAMETER LicenseKeyHash
        A hash of the license key which is to be stored in the registry.

    .SYNOPSIS
        Properly registers DevExpress so that applications using the product can be compiled, without actually installing rotten disease that is DevExpress.

    .NOTES
        Nothing yet...
#>
function Register-DevExpress
{
    param( 
        [parameter(Mandatory=$true,position=0)] [string] $version,
        [parameter(Mandatory=$true,position=1)] [string] $keyHash
    )

    $ErrorActionPreference = "Stop"

    $pwd = Get-ModuleDirectory
    Import-Module $pwd\Register-ProductLicense
    $ProductName = "DevExpress"
    $RegistryKeyName = "0378852D-D597-4A32-B6D9-680A16A3CDA6"

    $RegKeyTestPath = "HKCR:\Licenses\$($RegistryKeyName)"
    
    if (-not(Test-Path "HKCR:\")) {
        New-PSDrive -PSProvider registry -Root HKEY_CLASSES_ROOT -Name HKCR | Out-Null
    }
    
    if (Test-Path $RegKeyTestPath) { 
        Write-Output "DevExpress v12.1 Registry Key already in place."
    } else {
        Write-Output "!!! WARNING !!! If this is being run anywhere other than a build server, you should make sure that you are properly licensed to use this product."
        Register-License $ProductName $RegistryKeyName $version $keyHash
    }
}

function Get-ModuleDirectory {
    return Split-Path $script:MyInvocation.MyCommand.Path
}

Export-ModuleMember Register-DevExpress