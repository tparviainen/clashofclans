$packageVersion = "2.0.0"
$project = ".\ClashOfClans\ClashOfClans.csproj"

dotnet build --configuration Release $project
dotnet pack -p:PackageVersion=$packageVersion --configuration Release $project
