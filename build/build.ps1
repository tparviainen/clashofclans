param ([switch]$ci)

# https://docs.microsoft.com/en-us/nuget/concepts/package-versioning : Major.Minor.Patch[-Suffix]
$major = 6  # Major: Breaking changes
$minor = 0  # Minor: New features, but backwards compatible
$patch = 4  # Patch: Backwards compatible bug fixes only

$packageVersion = "$major.$minor.$patch"
$project = "..\src\ClashOfClans\ClashOfClans.csproj"

if ($ci) {
    $suffix = "ci.$(Get-Date -Format 'yy')$((Get-Date).Month*50 + (Get-Date).Day).$(Get-Date -Format 'HHmm')"

    $year=Get-Date -Format 'yy'
    $midd=(Get-Date).Month*50 + (Get-Date).Day
    $time=Get-Date -Format 'HHmm'

    $packageVersion = "$packageVersion-$suffix"
    $configuration = "Debug"
}
else {
    $configuration = "Release"
}

write-host "dotnet clean -c $configuration $project"
write-host "dotnet pack -p:PackageVersion=$packageVersion -p:Version=$packageVersion -c $configuration $project"

exit

dotnet clean -c $configuration $project
dotnet pack -p:PackageVersion=$packageVersion -p:Version=$packageVersion -c $configuration $project
