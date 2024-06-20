$CurrentDir = Get-Location

$CoverageFile = Join-Path $CurrentDir -ChildPath "test-results/coverage.opencover.xml"
$ReportDir = Join-Path $CurrentDir -ChildPath "test-results/coverage-report"

echo "Cleaning up previous output..."

if (Test-Path -Path $CoverageFile) {
    Remove-Item $CoverageFile
}

if (Test-Path -Path $ReportDir) {
    Remove-Item -Recurse $ReportDir
}

echo "Building solution..."

dotnet build | Out-Null

echo "Running tests..."

dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat="opencover" /p:CoverletOutput=$CoverageFile

if (Test-Path -Path $CoverageFile) {
    echo "Building report..."

    reportgenerator -reports:$CoverageFile -targetdir:$ReportDir -reporttypes:Html
    
    echo "Test suite completed"
} else {
    echo "One or more tests failed. No report will be generated."
}