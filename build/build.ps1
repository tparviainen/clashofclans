# https://docs.microsoft.com/en-us/nuget/concepts/package-versioning : Major.Minor.Patch[-Suffix]
$packageVersion = Get-Content .\version.txt -Tail 1
$project = "..\src\ClashOfClans\ClashOfClans.csproj"
$configuration = "Release"

dotnet clean -c $configuration $project
dotnet pack -p:PackageVersion=$packageVersion -p:Version=$packageVersion -c $configuration $project

nuget push ..\src\ClashOfClans\bin\$configuration\ClashOfClans.$packageVersion.nupkg -ApiKey ${env:NUGET_API_KEY} -Source https://api.nuget.org/v3/index.json
