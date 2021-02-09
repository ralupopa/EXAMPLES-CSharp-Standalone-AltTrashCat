# Standalone Build with CSharp Tests

This repository shows a few C# tests that use the page object model and AltUnityTester to test the Unity endless runner sample:
https://assetstore.unity.com/packages/essentials/tutorial-projects/endless-runner-sample-game-87901

## NuGet package

This projects requires to add https://www.nuget.org/packages/AltUnityDriver package in order to work.

### Running the tests on Windows or MacOS
The tests are meant to be run on an Windows or MacOS device. The app is provided in this repository, under the app/ folder.
To start the tests, depending of your OS run:
`./start_tests_Mac.sh`
or
`./start_tests_Windows.sh`

This script will:

- start the app on your device
- run the tests
- stop the app after the test are done

You can view a video of how to run the tests on MAC OS by clicking on the following image: 

[![Youtube](http://img.youtube.com/vi/tr3_8YawBck/0.jpg)](https://www.youtube.com/embed/tr3_8YawBck "Youtube")
