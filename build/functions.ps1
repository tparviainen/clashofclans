function Get-CommitHash {
    return ([string](git log -1 --pretty=%H)).Trim()
}

function Get-PackageVersion {
    return Get-Content .\version.txt -Tail 1
}
