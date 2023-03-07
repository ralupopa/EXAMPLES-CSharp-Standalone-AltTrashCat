using Altom.AltDriver;
using System.Collections.Generic;

namespace alttrashcat_tests_csharp.pages
{
    public class StorePage : BasePage
    {
        public StorePage(AltDriver driver) : base(driver)
        {
        }
        public void LoadScene()
        {
            Driver.LoadScene("Main");
        }
        public AltObject Store { get => Driver.WaitForObject(By.NAME, "StoreTitle", timeout: 10); }
        public AltObject OwnedButtonText { get => Driver.WaitForObject(By.PATH, "//BuyButton/Text[@text=Owned]", timeout: 10); }
        public AltObject BuyButtonText { get => Driver.WaitForObject(By.PATH, "//BuyButton/Text[@text=BUY]", timeout: 10); }
        public AltObject CoinElement { get => Driver.WaitForObject(By.NAME, "Coin", timeout: 10); }
        public AltObject CoinsCounter { get => Driver.WaitForObject(By.NAME, "CoinsCounter", timeout: 10); }
        public AltObject PremiumCounter { get => Driver.WaitForObject(By.NAME, "Premium", timeout: 10); }
        public AltObject ThemesTab { get => Driver.WaitForObject(By.NAME, "Themes", timeout: 10); }
        public bool IsDisplayed()
        {
            if (Store != null && CoinElement != null 
                && CoinsCounter != null && PremiumCounter != null)
                return true;
            return false;
        }
        public void PressStoreToIncreaseCoins()
        {
            Store.Tap();
        }
        public string GetCoinsCounterText()
        {
            return CoinsCounter.GetText();
        }
        public void PressBuyNightTime()
        {
            var parentButton = BuyButtonText.getParent();
            parentButton.Tap();
        }
        public void PressThemes()
        {
            ThemesTab.Tap();
        }
    }
}