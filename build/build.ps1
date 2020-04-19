# https://docs.microsoft.com/en-us/nuget/concepts/package-versioning : Major.Minor.Patch[-Suffix]
$packageVersion = Get-Content .\version.txt -Tail 1
$project = "..\src\ClashOfClans\ClashOfClans.csproj"
$configuration = "Release"

dotnet clean -c $configuration $project
dotnet build -p:PackageVersion=$packageVersion -p:Version=$packageVersion -c $configuration $project

nuget pack $project -Version $packageVersion -Properties Configuration=$configuration -IncludeReferencedProjects
nuget push ClashOfClans.$packageVersion.nupkg -ApiKey ${env:NUGET_API_KEY} -Source https://api.nuget.org/v3/index.json
