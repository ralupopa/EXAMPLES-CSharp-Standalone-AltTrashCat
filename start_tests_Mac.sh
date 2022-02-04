echo "==> Open application"
open App/TrashCatMac/TrashCatTest.app
echo "==>Wait for application to start"
sleep 3

cd TestAlttrashCSharp
echo "==>Restore test project and run tests"
dotnet test

echo "==>Kill app"
killall TrashCat
