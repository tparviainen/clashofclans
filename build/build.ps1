. .\functions.ps1

$version = Get-PackageVersion
$packageId = "ClashOfClans"
$basePath = Join-Path ".." "src" "ClashOfClans"
$project = Join-Path $basePath "$packageId.csproj"
$nuspec = Join-Path $basePath "$packageId.nuspec"
$nupkg = "$packageId.$version.nupkg"
$configuration = "Release"
$commit = Get-CommitHash
$branch = Get-BranchName

dotnet clean -c $configuration $project
dotnet build -c $configuration $project -p:Version=$version -p:ContinuousIntegrationBuild=true

nuget pack $nuspec -Properties "Version=$version;Commit=$commit;Branch=$branch" -Symbols -SymbolPackageFormat snupkg
nuget push $nupkg -ApiKey ${env:NUGET_API_KEY} -Source https://api.nuget.org/v3/index.json
