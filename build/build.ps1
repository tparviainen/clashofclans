# https://docs.microsoft.com/en-us/nuget/concepts/package-versioning : Major.Minor.Patch[-Suffix]
$packageVersion = Get-Content .\version.txt -Tail 1
$packageId = "ClashOfClans"
$basePath = "..\src\ClashOfClans\"
$project =  $basePath + $packageId + ".csproj"
$nuspec = $basePath + $packageId + ".nuspec"
$nupkg = "$packageId.$packageVersion.nupkg"
$configuration = "Release"

dotnet clean -c $configuration $project
dotnet build -c $configuration $project -p:Version=$packageVersion

nuget pack $nuspec -Properties Version=$packageVersion -Symbols -SymbolPackageFormat snupkg
nuget push $nupkg -ApiKey ${env:NUGET_API_KEY} -Source https://api.nuget.org/v3/index.json
