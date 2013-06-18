<#
    .DESCRIPTION
        Will create a Website with the specified settings if one doesn't exist.

    .EXAMPLE
        New-Website "apps.marquisalliance.com" "C:\inetpub\apps.marquisalliance.com" "apps.marquisalliance.com"

    .PARAMETER siteName
        The name of the Website that we are creating.

    .PARAMETER sitePath
        The physical path where this Website is located on disk.

    .PARAMETER hostHeader
        The "C" name that IIS forward on to this Website.

    .SYNOPSIS
        Will setup a web application under the specified Website and AppPool.
#>

Import-Module WebAdministration

function New-Site
{
    param(
        [parameter(Mandatory=$true,position=0)] [string] $siteName,
        [parameter(Mandatory=$true,position=1)] [string] $sitePath,
        [parameter(Mandatory=$true,position=2)] [string] $hostHeader
    )

    $ErrorActionPreference = "Stop"

    Write-Output "Creating Web Site: $siteName"
    $TestWebSite = Get-WebSite | where { $_.Name -eq $siteName }
    
    if($TestWebSite -eq $null)    {
        New-Website -Name $siteName -PhysicalPath $sitePath -HostHeader $hostHeader
        Write-Output "Created Web Site: $siteName"
    } else {
        Write-Output "Web Site already exists: $siteName"
    }
}

Export-ModuleMember New-Site