$packageVersion = "4.0.1"
$project = "..\src\ClashOfClans\ClashOfClans.csproj"
$configuration = "Release"

dotnet clean -c $configuration $project
dotnet pack -p:PackageVersion=$packageVersion -p:Version=$packageVersion -c $configuration $project
