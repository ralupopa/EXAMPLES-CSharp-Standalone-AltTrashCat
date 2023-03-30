echo "==> Start application"

start "" "App\TrashCatWindows\TrashCat.exe"

echo "==> Wait for app to start"
sleep 5
cd TestAlttrashCSharp

echo "==> Run tests with nunit3-console and generate XML test report"
nunit3-console bin/Debug/netcoreapp3.1/TestAlttrashCSharp.dll --work=TestResults

echo "==> Generate HTML test report"
nure TestResults/TestResult.xml -o TestResults --html

echo "==> Kill app"
taskkill //PID $(tasklist | grep TrashCat.exe | awk '{print $2}') //T //F