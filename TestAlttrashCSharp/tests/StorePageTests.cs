using System;
using System.Threading;
using Altom.AltDriver;
using alttrashcat_tests_csharp.pages;
using NUnit.Framework;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace alttrashcat_tests_csharp.tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Store")]
    public class StorePageTests
    {
        AltDriver altDriver;
        MainMenuPage mainMenuPage;
        StorePage storePage;

        [SetUp]
        public void Setup()
        {
            altDriver = new AltDriver();
            mainMenuPage = new MainMenuPage(altDriver);
            storePage = new StorePage(altDriver);
            storePage.LoadScene();
            mainMenuPage.PressStore();
            storePage.PressStoreToIncreaseCoins();
        }

        [TearDown]
        public void Dispose()
        {
            altDriver.Stop();
            Thread.Sleep(1000);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public void TestAccessStoreAndIncreaseCoins()
        {
            storePage.IsDisplayed();
            storePage.PressStoreToIncreaseCoins();
            var coinsText = storePage.GetCoinsCounterText();
            Assert.True(Int32.Parse(coinsText) != 0);
        }

        [Test(Author = "Ralu", Description = "Can Buy Night theme")]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestBuyNightTime()
        {
            Assert.Multiple(() =>
            {
                storePage.PressThemes();
                Assert.NotNull(storePage.OwnedButtonText);
                Assert.NotNull(storePage.BuyButtonText);
                storePage.PressBuy();
                storePage.PressCloseStore();
                Assert.True(mainMenuPage.IsDisplayed());
                mainMenuPage.ButtonsLeftRightAreDisplayed();
                Assert.NotNull(mainMenuPage.ThemeName);
                Assert.AreEqual(mainMenuPage.GetThemeNameText(), "Day");
                mainMenuPage.PressButtonRight();
                StringAssert.Contains("Night", mainMenuPage.GetThemeNameText());

                mainMenuPage.DeleteData();
            });
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestCheckItemsList()
        {
            storePage.IsDisplayed();
            Assert.True(storePage.StoreTabsAreDisplayed());
            Assert.AreEqual(4, storePage.ItemsList.Count);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestCheckCharactersList()
        {
            storePage.IsDisplayed();
            Assert.True(storePage.StoreTabsAreDisplayed());
            storePage.PressCharacters();
            Assert.AreEqual(2, storePage.CharactersList.Count);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestCheckAccessoriesList()
        {
            storePage.IsDisplayed();
            Assert.True(storePage.StoreTabsAreDisplayed());
            storePage.PressAccessories();
            Assert.AreEqual(2, storePage.AccessoriesList.Count);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestCheckThemesList()
        {
            storePage.IsDisplayed();
            Assert.True(storePage.StoreTabsAreDisplayed());
            storePage.PressThemes();
            Assert.AreEqual(2, storePage.ThemesList.Count);

            storePage.PressCloseStore();
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        public void TestBuyCharacterRubbishRaccoon()
        {
            Assert.Multiple(() =>
            {
                storePage.PressCharacters();
                Assert.NotNull(storePage.OwnedButtonText);
                Assert.NotNull(storePage.BuyButtonText);
                storePage.PressBuy();
                storePage.PressCloseStore();
                Assert.True(mainMenuPage.IsDisplayed());
                Assert.True(mainMenuPage.ButtonsLeftRightAreDisplayed());
                Assert.AreEqual(mainMenuPage.GetCharacterNameText(), "Trash Cat");
                mainMenuPage.PressButtonRight();
                StringAssert.Contains("Rubbish Raccoon", mainMenuPage.GetCharacterNameText());

                mainMenuPage.DeleteData();
            });
        }

    }
}
