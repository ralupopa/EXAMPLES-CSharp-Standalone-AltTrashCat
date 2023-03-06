using Altom.AltDriver;
using alttrashcat_tests_csharp.pages;
using System;
using System.Threading;
using NUnit.Framework;
namespace alttrashcat_tests_csharp.tests
{
    public class MainMenuTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver(port: 13000);
            mainMenuPage = new MainMenuPage(altDriver);
            mainMenuPage.LoadScene();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        public void TestMainMenuPageLoadedCorrectly()
        {
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [Test]
        public void TestShowLeaderboard()
        {
            mainMenuPage.PressLeaderboard();
            Assert.NotNull(mainMenuPage.LeaderBoardText);
            Assert.AreEqual(mainMenuPage.GetLeaderboardText(), "Leaderboard");
            mainMenuPage.PressCloseLeaderboard();
            Assert.True(mainMenuPage.IsDisplayed());
        }

        [Test]
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
        public void TestShowStore()
        {
            mainMenuPage.PressStore();
            Assert.NotNull(mainMenuPage.StoreText);
            Assert.AreEqual(mainMenuPage.GetStoreText(), "STORE");
            Assert.AreEqual(4, mainMenuPage.StoreTabsList.Count);
            Assert.True(mainMenuPage.StoreTabsAreDisplayed());
            mainMenuPage.PressCloseStore();
            Assert.True(mainMenuPage.IsDisplayed());
        }
        [Test]
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