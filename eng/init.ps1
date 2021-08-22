function Remove-CarriageReturns {
    param (
        [Parameter(Mandatory)]
        [string]$Path
    )

    ((Get-Content $Path) -replace "\\r\\n", "\n") | Set-Content $Path
}
