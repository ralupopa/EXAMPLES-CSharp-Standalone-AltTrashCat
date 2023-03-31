# Standalone Build with CSharp Tests

This repository shows a few C# tests that use the page object model and AltTester to test the Unity endless runner sample:
[Asset store unity - endless runner smaple](https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901)

The TestAlttrashCSharp project containes the game build for Standalone Windows or MacOS platform.
The **TestAlttrashCSharp.csproj** has specified TargetFramework: **netcoreapp3.1.** This means that need to install [the corresponding .NET runtime](https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=3.1.0&arch=x64&rid=win10-x64) in order to be able to run the tests.

## Pre-requisites
1. Install the necessary .NET runtime version
2. Create a folder `App`
3. on MacOS/Linux
    Create a folder `TrashCatMac` under `App`.
    The app is provided at [TrashCatMacOS](https://altom.com/app/uploads/AltTester/TrashCat/TrashCatMacOS.app.zip) and needs to be included unzipped under the App/TrashCatMac/ folder.

    on Windows
    Create a folder `TrashCatWindows` under `App`.
    The app is provided at [TrashCatWindows](https://altom.com/app/uploads/AltTester/TrashCat/TrashCatWindows.zip) and needs to be included unzipped under the App/TrashCatWindows/ folder.

# Running the tests on Windows or MacOS
The tests are meant to be run on an Windows or MacOS device.

To start the tests, depending of your OS run:
- on MacOS/Linux

```
./start_tests_Mac.sh
```

- on Windows

```
./start_tests_Windows.sh
```
    
This script will:

- start the app on your device
- run the tests
- stop the app after the tests are done

You can view a video of how to run the tests on MAC OS by clicking on the following image: 

[![Youtube](http://img.youtube.com/vi/tr3_8YawBck/0.jpg)](https://www.youtube.com/embed/tr3_8YawBck "Youtube")

### NuGet package

**This project already has the AltDriver inside (version 1.8.0), but otherwise would require to add [AltTester Driver](https://www.nuget.org/packages/AltTester-Driver) package in order to work.**

# Run tests manually (with [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test))

1. Check the dotnet SDK and runtime versions which are installed

```
dotnet --info
```

2. Launch game from `App\TrashCatWindows\TrashCat.exe`

3. Move to `TestAlttrashCSharp` and execute all tests (mention the output folder)

```
dotnet test -- NUnit.TestOutputXml  = "TestAlttrashCSharp" --results-directory TestResults
```

! **Make sure to have the Alttester Desktop App closed, otherwise the test won't be able to connect to proper port.**

### Run all tests from a specific class / file

```
dotnet test --filter <test_class_name>
```

### Run only one test from a class

```
dotnet test --filter <test_class_name>.<test_name>
```

```
dotnet test -- NUnit.TestOutputXml  = "TestAlttrashCSharp" --results-directory TestResults --filter <test_class_name>.<test_name>
```

# Run tests and generate XML, HTML test reports

## Using [Allure](https://docs.qameta.io/allure-report/)

### Automatic script

```
allure_run_tests_generate_report.sh
```

### Manual Steps

1. Launch game from `App\TrashCatWindows\TrashCat.exe`

2. Move to `TestAlttrashCSharp`

3. Execute all tests and generate output specific for NUnit Allure adapter

```
dotnet test -- NUnit.TestOutputXml  = "TestAlttrashCSharp" --results-directory allure-results
```

4. Generate test results report

```
allure serve allure-results
```

## Using [Nure](https://www.nuget.org/packages/nure)

Read [Setup Nure](setup_nure.md) as pre-requisite.

### Automatic script

```
nure_run_tests_generate_report.sh
```

### Manual Steps

1. Launch game from `App\TrashCatWindows\TrashCat.exe`

2. Move to `TestAlttrashCSharp`

3. Execute all tests and generate an XML output file with results

```
nunit3-console bin/Debug/netcoreapp3.1/TestAlttrashCSharp.dll --work=TestResults
```

eg: execute one test by name:

```
nunit3-console bin/Debug/netcoreapp3.1/TestAlttrashCSharp.dll --work=TestResults --where "name=TestNameHere"
```

3. Transform XML to HTML report
```
nure TestResults/TestResult.xml -o TestResults --html
``` 