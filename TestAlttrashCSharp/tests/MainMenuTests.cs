using Altom.AltDriver;
using alttrashcat_tests_csharp.pages;
using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
namespace alttrashcat_tests_csharp.tests
{
    
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Main Menu")]
    public class MainMenuTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        StorePage storePage;
        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altDriver);
            storePage = new StorePage(altDriver);
            mainMenuPage.LoadScene();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TestMainMenuPageLoadedCorrectly()
        {
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void TestShowLeaderboard()
        {
            mainMenuPage.PressLeaderboard();
            Assert.NotNull(mainMenuPage.LeaderBoardText);
            Assert.AreEqual(mainMenuPage.GetLeaderboardText(), "Leaderboard");
            mainMenuPage.PressCloseLeaderboard();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [Test]
        [AllureSeverity(SeverityLevel.minor)]
        public void TestShowMissionsContainsTwo()
        {
            mainMenuPage.PressMissions();
            Assert.NotNull(mainMenuPage.MissionsText);
            Assert.AreEqual(mainMenuPage.GetMissionsText(), "MISSIONS");
            Assert.AreEqual(2, mainMenuPage.MissionsList.Count);
            mainMenuPage.PressCloseMissions();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void TestShowStore()
        {
            mainMenuPage.PressStore();

            Assert.NotNull(storePage.StoreText);
            Assert.AreEqual(storePage.GetStoreText(), "STORE");
            Assert.AreEqual(4, storePage.StoreTabsList.Count);
            Assert.True(storePage.StoreTabsAreDisplayed());
            storePage.PressCloseStore();
            Assert.True(mainMenuPage.IsDisplayed());
        }
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void TestShowSettings()
        {
            mainMenuPage.PressSettings();
            Assert.NotNull(mainMenuPage.SettingsText);
            Assert.AreEqual(mainMenuPage.GetSettingsText(), "SETTINGS");
            Assert.True(mainMenuPage.SettingsSlidersAreDisplayed());
            mainMenuPage.PressCloseSettings();
            Assert.True(mainMenuPage.IsDisplayed());
        }
    }
}