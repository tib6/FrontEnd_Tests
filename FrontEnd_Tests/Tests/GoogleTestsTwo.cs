namespace FrontEnd_Tests.Tests
{
    [TestFixture, Category("google_test")]
    public class GoogleTestTwo : BaseFixture
    { 
        private readonly string search = "lola";

        [Test]
        public void GoogleTests_Search2()
        {
            var googlePage = new GooglePage(Driver);
            var googleSecondPage = new GoogleSecondPage(Driver);
            googlePage.goTo(TestSettings.baseGoogleURL);

            googleSecondPage.selectDivByText("Accept all").Click();
            googlePage.insertBox().SendKeys(search);
            ExtentTestManager.GetTest().Log(Status.Info, "Send Keys");
            googleSecondPage.insertBox().SendKeys(Keys.Enter);

            Console.WriteLine("Title is: " + googlePage.getTitle().ToString() + " : " + search);

            Assert.That(googlePage.getTitle().ToString().Contains(search));

            ExtentTestManager.GetTest().Log(Status.Info, "Get title succesfully! - 2");
            googlePage.quit();
        }

        [Test]
        public void NewTabNavigation2()
        {
            var googlePage = new GooglePage(Driver);
            var googleSecondPage = new GoogleSecondPage(Driver);

            googlePage.goTo(TestSettings.baseGoogleURL);
            var initTitle = googlePage.getTitle();
            googleSecondPage.selectDivByText("Accept all").Click();

            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            googlePage.goTo(TestSettings.baseGoogleURL);
            ExtentTestManager.GetTest().Log(Status.Info, "New google Tab Opened");
            Assert.That(initTitle, Is.EqualTo(googlePage.getTitle()));
            googlePage.insertBox().SendKeys(search);
            googleSecondPage.insertBox().SendKeys(Keys.Enter);
            Console.WriteLine("Title is: " + googlePage.getTitle().ToString() + " : " + search);
            ExtentTestManager.GetTest().Log(Status.Info, "New google tab Closed");
            Driver.Close();

            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            ExtentTestManager.GetTest().Log(Status.Info, "Back to First Google Tab");
            Assert.That(initTitle, Is.EqualTo(googlePage.getTitle()));
            googlePage.insertBox().SendKeys(search);
            googleSecondPage.insertBox().SendKeys(Keys.Enter);
            Console.WriteLine("Title is: " + googlePage.getTitle().ToString() + " : " + search);
            ExtentTestManager.GetTest().Log(Status.Info, "First Google Tab Closed");
            Assert.That(googlePage.getTitle().ToString().Contains(search));
        }
    }
}
