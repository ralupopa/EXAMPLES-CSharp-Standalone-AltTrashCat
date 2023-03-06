# Standalone Build with CSharp Tests

This repository shows a few C# tests that use the page object model and AltTester to test the Unity endless runner sample:
[Asset store unity - endless runner smaple](https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901)

The **TestAlttrashCSharp.csproj** has specified TargetFramework: **netcoreapp3.1.** This means that need to install The corresponding .NET runtime in order to be able to run the tests.

## NuGet package

**This project already has the AltDriver inside (version 1.8.0), but otherwise would require to add [AltTester Driver](https://www.nuget.org/packages/AltTester-Driver) package in order to work.**

### Running the tests on Windows or MacOS
The tests are meant to be run on an Windows or MacOS device.
Create a folder `App` under project.

To start the tests, depending of your OS run:

- `./start_tests_Mac.sh` on MacOS/Linux

    Create a folder `TrashCatMac` under `App`.
    The app is provided at [TrashCatMacOS](https://altom.com/app/uploads/AltTester/TrashCat/TrashCatMacOS.app.zip) and needs to be included unzipped under the App/TrashCatMac/ folder.

- `./start_tests_Windows.sh` on Windows

    Create a folder `TrashCatWindows` under `App`.
    The app is provided at [TrashCatWindows](https://altom.com/app/uploads/AltTester/TrashCat/TrashCatWindows.zip) and needs to be included unzipped under the App/TrashCatWindows/ folder.
    
This script will:

- start the app on your device
- run the tests
- stop the app after the test are done

You can view a video of how to run the tests on MAC OS by clicking on the following image: 

[![Youtube](http://img.youtube.com/vi/tr3_8YawBck/0.jpg)](https://www.youtube.com/embed/tr3_8YawBck "Youtube")

## Run tests manually

1. Check the dotnet SDK and runtime versions which are installed

```
dotnet --info
```

2. Launch game from `App\TrashCatWindows\TrashCat.exe`

3. Move to `TestAlttrashCSharp` and execute all tests

```
dotnet test  -- NUnit.TestOutputXml = "TestAlttrashCSharp"
```


! **Make sure to have the Alttester Desktop App closed, otherwise the test won't be able to connect to proper port.**

## Run specific tests

### Run all tests from a specific class / file

```
dotnet test --filter <test_class_name>
```

### Run only one test from a class

```
dotnet test --filter <test_class_name>.<test_name>
```