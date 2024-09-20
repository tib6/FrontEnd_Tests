namespace FrontEnd_Tests.Hooks
{
    public class BaseFixture
    {
        public static IWebDriver Driver { get; private set; }           

        [OneTimeSetUp]
        public void Setup()
        {
            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            ExtentManager.Instance.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            var options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            ExtentTestManager.GetTest().Log(Status.Info, "Browser started and navigated to URL.");
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
            Status logstatus;


            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    TakeScreenshotOnFailure();  // Capture screenshot on failure
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            // Properly Dispose of IWebDriver (ChromeDriver)
            if (Driver != null)
            {
                Driver.Quit();   // Close the browser
                Driver.Dispose();  // Dispose of the driver (important for IDisposable)
            }

            ExtentTestManager.GetTest().Log(Status.Info, "Browser closed.");
            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }
        // Capture screenshot on test failure
        private void TakeScreenshotOnFailure()
        {
            try
            {
                var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), "../../../TestResults", $"{TestContext.CurrentContext.Test.Name}.png");
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);

                // Attach screenshot to the Extent report
                ExtentTestManager.GetTest().AddScreenCaptureFromPath(screenshotPath);
            }
            catch (Exception e)
            {
                ExtentTestManager.GetTest().Log(Status.Warning, "Failed to capture screenshot: " + e.Message);
            }
        }
    }
}