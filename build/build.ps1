# https://docs.microsoft.com/en-us/nuget/concepts/package-versioning : Major.Minor.Patch[-Suffix]
$packageVersion = "6.0.0"
$project = "..\src\ClashOfClans\ClashOfClans.csproj"
$configuration = "Release"

dotnet clean -c $configuration $project
dotnet pack -p:PackageVersion=$packageVersion -p:Version=$packageVersion -c $configuration $project
