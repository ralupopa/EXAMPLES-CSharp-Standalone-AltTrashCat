using  alttrashcat_tests_csharp.pages;
using NUnit.Framework;

namespace alttrashcat_tests_csharp.tests
{
    public class StartPageTests 
    {
        private AltUnityDriver altUnityDriver;
        private MainMenuPage mainMenuPage;
        private StartPage startPage;
        [OneTimeSetUp]
       public void SetUp(){
            altUnityDriver=new AltUnityDriver();
            startPage=new StartPage(altUnityDriver);
            startPage.Load();
            mainMenuPage=new MainMenuPage(altUnityDriver);

        }
        [Test]
        public void TestStartPageLoadedCorrectly(){
            Assert.True(startPage.IsDisplayed());
        }
        [Test]
        public void TestStartButtonLoadMainMenu(){
            startPage.PressStart();
            Assert.True(mainMenuPage.IsDisplayed());
        }
        [OneTimeTearDown]
        public void TearDown(){
            altUnityDriver.Stop();
        }
    }
}