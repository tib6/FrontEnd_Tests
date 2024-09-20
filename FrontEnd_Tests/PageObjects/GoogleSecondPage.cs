namespace FrontEnd_Tests.PageObjects
{
    public class GoogleSecondPage
    {
        private IWebDriver driver;

        public GoogleSecondPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void goTo(string url) => driver.Navigate().GoToUrl(url);
        public void quit() => driver.Quit();
        public string getTitle() => driver.Title;
        public IWebElement selectDivByText(string value) => driver.FindElement(By.XPath($"//div[text() = '{value}']"));
        public IWebElement insertBox() => driver.FindElement(By.XPath("//textarea[@class = 'gLFyf']"));
        public IWebElement searchButton(string value) => driver.FindElement(By.XPath($"//div[contains(@class, 'FPdoLc')]//input[@value='{value}']"));
        public IList<IWebElement> CautaGoogle() => driver.FindElements(By.XPath("//input[@value = 'Google Search']"));
    }
}

