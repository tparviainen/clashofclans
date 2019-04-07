$packageVersion = "1.0.2"
$project = ".\ClashOfClans\ClashOfClans.csproj"

dotnet build --configuration Release $project
dotnet pack -p:PackageVersion=$packageVersion --configuration Release $project
