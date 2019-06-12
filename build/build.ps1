$packageVersion = "3.0.3"
$project = "..\src\ClashOfClans\ClashOfClans.csproj"

dotnet build --configuration Release $project
dotnet pack -p:PackageVersion=$packageVersion --configuration Release $project
