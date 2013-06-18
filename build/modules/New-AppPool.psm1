<#
    .DESCRIPTION
        Creates an AppPool in IIS and sets up the specified identity to run under.

    .EXAMPLE
        New-AppPool

    .PARAMETER appPoolName
        The name of the application pool.

    .PARAMETER appPoolIdentityType
        The type of identity you want the AppPool to run as, default is 'LocalSystem'. 

    .PARAMETER maxProcesses
        The number of Worker Processes this AppPool should spawn, default is 1.

    .PARAMETER username
        The Username that this app pool should run as.

    .PARAMETER password
        The password for the Username that this app pool should run as.

    .SYNOPSIS
        Will setup an App Pool with a Managed Runtime Version of 4.0 and it defaults to using an Identity of LocalSystem.
#>

Import-Module WebAdministration

function New-AppPool
{
    param(
        [parameter(Mandatory=$true,position=0)] [string] $appPoolName,
        [parameter(Mandatory=$true,position=1)] [ValidateSet("LocalSystem","LocalService","NetworkService","SpecificUser","ApplicationPoolIdentity")] [string] $appPoolIdentityType,
        [parameter(Mandatory=$false,position=2)] [int] $maxProcesses = 1,
        [parameter(Mandatory=$false,position=3)] [string] $username,
        [parameter(Mandatory=$false,position=4)] [string] $password
    )

    $ErrorActionPreference = "Stop"

    $identityType = 0

    Switch ($appPoolIdentityType)
    {
        "LocalSystem" { $identityType = 0 }
        "LocalService" { $identityType = 1 } 
        "NetworkService" { $identityType = 2 }
        "SpecificUser" { $identityType = 3 }
        "ApplicationPoolIdentity" { $identityType = 4 }
    }
        
    try {
        $poolCreated = Get-WebAppPoolState $appPoolName -errorvariable myerrorvariable
        Write-Output "AppPool '$appPoolName' already exists"
    } catch {
        # If we error out assume it doesn't exist. Create it.
        Write-Output "Creating AppPool: $appPoolName"
        New-WebAppPool -Name $appPoolName
        Write-Output "Created AppPool: $appPoolName"
    }

    Set-ItemProperty -Path IIS:\AppPools\$appPoolName -Name processmodel.identityType -Value $identityType
    Write-Output "Updated Identity Type to: $appPoolIdentityType -> $identityType"
    Set-ItemProperty -Path IIS:\AppPools\$appPoolName -Name processmodel.maxProcesses -Value $maxProcesses
    Write-Output "Updated Max Worker Processes to: $maxProcesses."
    Set-ItemProperty -Path "IIS:\AppPools\$appPoolName" -Name managedRuntimeVersion -Value "v4.0"
    Write-Output "Updated ManagedRuntimeVersion to: v4.0"

    if ( $username -And $password ) {
        Set-ItemProperty -Path IIS:\AppPools\$appPoolName -Name processModel.username -Value $username
        Write-Output "Set Username to: $username."
        Set-ItemProperty -Path IIS:\AppPools\$appPoolName -Name processModel.password -Value $password
        Write-Output "Set Password to: $password."
    }
}

Export-ModuleMember New-AppPool
