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
    }
}