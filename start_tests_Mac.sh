top

echo "==>Kill previous build"
npx kill-port 13000

echo "==> Open application"
open App/TrashCatMac/TrashCat.app/
echo "==>Wait for application to start"
sleep 3

cd TestAlttrashCSharp
echo "==>Restore test project and run tests"
dotnet test

echo "==>Kill app"
killall TrashCat

launchctl list
