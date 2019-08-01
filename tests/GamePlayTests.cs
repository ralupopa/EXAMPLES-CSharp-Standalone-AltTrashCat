using  alttrashcat_tests_csharp.pages;
using NUnit.Framework;
using System;
namespace alttrashcat_tests_csharp.tests
{
    public class GamePlayTests
    {
        AltUnityDriver altUnityDriver;
        MainMenuPage mainMenuPage;
        GamePlay gamePlayPage;
        PauseOverlayPage pauseOverlayPage;
        GetAnotherChancePage getAnotherChancePage;
        [OneTimeSetUp]
        public void SetUp(){
            altUnityDriver=new AltUnityDriver();
            mainMenuPage=new MainMenuPage(altUnityDriver);
            mainMenuPage.LoadScene();
            mainMenuPage.PressRun();
            gamePlayPage=new GamePlay(altUnityDriver);
            pauseOverlayPage=new PauseOverlayPage(altUnityDriver);
            getAnotherChancePage=new GetAnotherChancePage(altUnityDriver);

        }
        [OneTimeTearDown]
        public void TearDown(){
            altUnityDriver.Stop();
        }
        [Test]
        public void TestGamePlayDisplayedCorrectly(){
            Assert.True(gamePlayPage.IsDisplayed());
        }
        [Test]
        public void TestGameCanBePausedAndResumed(){
            gamePlayPage.PressPause();
            Assert.True(pauseOverlayPage.IsDisplayed());
            pauseOverlayPage.PressResume();
            Assert.True(gamePlayPage.IsDisplayed());
        }
        [Test]
        public void TestGameCanBePausedAndStopped(){
            gamePlayPage.PressPause();
            pauseOverlayPage.PressMainMenu();
            Assert.True(mainMenuPage.IsDisplayed());
        }
        [Test]
        public void TestAvoidingObstacles(){
            gamePlayPage.AvoidObstacles(5);
            Assert.True(gamePlayPage.GetCurrentLife()>0);
        }
        [Test]
        public void TestPlayerDiesWhenObstacleNotAvoided(){
            float timeout=20;
            while(timeout>0){
                try{
                    getAnotherChancePage.IsDisplayed();
                    break;
                }
                catch (Exception){
                    timeout-=1;
                }
            }
            Assert.True(getAnotherChancePage.IsDisplayed());
        }
    }
}