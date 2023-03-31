
[Allure](https://docs.qameta.io/allure/) framework is a popular multi-language test report tool.

To run commandline application, [*Java Runtime Environment*](https://www.oracle.com/java/technologies/downloads/#jre8-windows) must be installed and JAVA_HOME set as environment variable.

Setup for running Allure with .NET language support can be consulted on [official documentation](https://docs.qameta.io/allure-report/#_nunit_3). For more explicit steps:

# 1. Install [Allure](https://github.com/allure-framework/allure2/releases)

From Assets download archive and extract it.

! After installation, add path to exe in environment variable PATH.

# 2. Install [NUnit Allure](https://www.nuget.org/packages/NUnit.Allure) adapter

* it was recommended to install the newer [Allure.NUnit](https://www.nuget.org/packages/Allure.NUnit/) package (but encountered errors on install)

```
nuget install NUnit.Allure
```

This will install also all [dependencies](https://www.nuget.org/packages/NUnit.Allure#dependencies-body-tab) for the library.

# 3. Add package reference in <TestProjectName>.csproj

```
dotnet add package NUnit.Allure --version 1.2.1.1
```

# 4. Create folders `allure-results` and `allure-report`

`alure-results` will be the output folder for tests execution; because of NUnit.Allure adapter this output will be in format useful for Allure to interpret and use further when creating the HTML report.

`allure-report` will be the outut folder for HTML report served by allure.

# 5. Create `allureConfig.json` at same level with < TestProjectName>.dll

Eg: < TestProjectName>.dll is found in `/bin/Debug/netcoreapp3.1`

Create `allureConfig.json` file with content as exemplified in [allure-csharp repository](https://github.com/allure-framework/allure-csharp/blob/main/Allure.NUnit/allureConfig.json)

Important to provide a FULL path to the `allure-results` folder. On windows use the double "\\".

eg: 
```
D:\\projects\\alttester\\EXAMPLES-CSharp-Standalone-AltTrashCat\\TestAlttrashCSharp\\allure-results
```

# 6. In a test class add Allure import and related attributes
- import NUnit Allure adapter (eg: `using NUnit.Allure.Core`)
- Set `[TestFixture]` above test class declaration
- Set `[AllureNUnit]` attribute under [TestFixture]

See [more examples](https://github.com/allure-framework/allure-csharp/tree/main/Allure.NUnit.Examples) for other attributes

# 7. Execute tests and generate output folder `allure-results`

```
dotnet test -- NUnit.TestOutputXml  = "TestAlttrashCSharp" --results-directory allure-results
```

# 8. Generate test results report

```
allure serve allure-results
```