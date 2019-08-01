using  alttrashcat_tests_csharp.pages;
using NUnit.Framework;
using System;
namespace alttrashcat_tests_csharp.tests
{
    public class MainMenuTests
    {
        AltUnityDriver altUnityDriver;
        MainMenuPage mainMenuPage;
        [OneTimeSetUp]
        public void SetUp(){
            altUnityDriver=new AltUnityDriver();
            mainMenuPage=new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();

        }
        [OneTimeTearDown]
        public void TearDown(){
            altUnityDriver.Stop();
        }
        [Test]
        public void TestMainMenuPageLoadedCorrectly(){
            Assert.True(mainMenuPage.IsDisplayed());
        }
    }
}