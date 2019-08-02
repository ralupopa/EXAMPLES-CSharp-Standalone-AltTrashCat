echo "==> Start application"

start "" "App\TrashCat2\TrashCat2.exe"

sleep 5
cd TestAlttrashCSharp

dotnet restore
dotnet test -- xunit.parallelizeAssembly=false

taskkill //PID $(tasklist | grep TrashCat2.exe | awk '{print $2}') //T //F

