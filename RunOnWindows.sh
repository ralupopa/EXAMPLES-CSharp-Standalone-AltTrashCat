echo "==> Start application"

start "" "App\TrashCat2\TrashCat2.exe"

echo "==> Wait for app to start"
sleep 5
cd TestAlttrashCSharp

echo "==> Restore test project"
dotnet restore
echo "==> Run tests"
dotnet test -- xunit.parallelizeAssembly=false

echo "==> Kill app"
taskkill //PID $(tasklist | grep TrashCat2.exe | awk '{print $2}') //T //F

