$packageVersion = "3.0.3"
$project = "..\src\ClashOfClans\ClashOfClans.csproj"
$configuration = "Release"

dotnet clean -c $configuration $project
dotnet build -c $configuration $project
dotnet pack -p:PackageVersion=$packageVersion -c $configuration $project
