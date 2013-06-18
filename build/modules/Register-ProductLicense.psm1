<#
    .DESCRIPTION
        Will update a registry setting with a value provided  Specifically designed for software that uses Microsofts licensing scheme.

    .EXAMPLE
        Register-License "DevExpress" "0378852D-D597-4A32-B6D9-680A16A3CDA6" "121" "Somebiglonghashvaluethatmatchesthekeyneeded=="

    .PARAMETER ProductName
        The product name that you are registering

    .PARAMETER LicenseRegistryKey
        The GUID representing the registry Key of the product in question.

    .PARAMETER LicenseKeyVerion
        The version of the software you are registering

    .PARAMETER LicenseKeyHash
        A hash of the license key which is to be stored in the registry.

    .SYNOPSIS
        Properly updates the registry with registration information for a particular piece of software which uses the Mircosoft licensing mechanism.

    .NOTES
        Nothing yet...
#>
function Register-License
{
    param( 
        [parameter(position=0)] [string] $ProductName,
        [parameter(position=1)] [string] $LicenseRegistryKey,
        [parameter(position=2)] [string] $LicenseKeyVerion,
        [parameter(position=3)] [string] $LicenseKeyHash
    )

    $ErrorActionPreference = "Stop"

    $pwd = Get-ModuleDirectory
    Import-Module $pwd\Test-RunAsAdmin
    Test-RunAsAdmin

    $licenseRoot = "HKCR:\Licenses"
    $registryKey = "$($licenseRoot)\$($LicenseRegistryKey)"

    if (-not(Test-Path "HKCR:\")) {
        New-PSDrive -PSProvider registry -Root HKEY_CLASSES_ROOT -Name HKCR
    }
    
    if (Test-Path $registryKey) { 
        Write-Output "$($ProductName) Registry Key already in place."
    } else { 
        New-Item -Path $licenseRoot -Name $LicenseRegistryKey
	    Write-Output "Added $($ProductName) Registry Key."
    }

    if (Get-ItemProperty -Name $LicenseKeyVerion -path $registryKey -erroraction silentlycontinue) { 
        Write-Output "$($ProductName) License Key already in place."
    } else { 
	    New-ItemProperty $registryKey -Name $LicenseKeyVerion -Value $LicenseKeyHash -PropertyType "String"
	    Write-Output "Added $($ProductName) License Key."
    }
}

function Get-ModuleDirectory {
    return Split-Path $script:MyInvocation.MyCommand.Path
}

Export-ModuleMember Register-License