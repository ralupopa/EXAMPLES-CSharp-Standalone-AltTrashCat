Adding details about a few tools and libraries used to execute tests in .NET world.

[NuGet CLI](https://learn.microsoft.com/en-us/nuget/reference/nuget-exe-cli-reference) can be used to install and manage packages (.NET framework libraries).

# 1. Install [nuget CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-nuget-cli#prerequisites)

Central repository [nuget.org](https://www.nuget.org/) for hosting nuget packages is useful to search desired libraries.

# 2. [Optional] Install [NUnit.ConsoleRunner](https://www.nuget.org/packages/NUnit.ConsoleRunner)

```
nuget install NUnit.ConsoleRunner
```

[NUnit Console Runner](https://docs.nunit.org/articles/nunit/running-tests/Console-Runner.html) is a popular runner with quite some options on CLI.

! After installation, add path to exe in environment variable PATH.

eg: command to execute tests and generate XML

```
nunit3-console bin/Debug/netcoreapp3.1/TestAlttrashCSharp.dll --work=TestResults
```

# 3. Install [Nure](https://www.nuget.org/packages/nure/)

```
nuget install nure
```

This library can be used to generate HTML report from NUnit3 TestResult.xml

! After installation, add path to exe in environment variable PATH.

eg: command to generate HTML
```
nure TestResults/TestResult.xml -o TestResults --html
```
