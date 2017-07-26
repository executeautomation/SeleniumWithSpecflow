using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecflowParallelTest
{
    [Binding]
    public class Hooks
    {

        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            SelectBrowser(BrowserType.Chrome);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }


        internal void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--headless");
                    _driver = new ChromeDriver(option);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.Firefox:
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    _driver = new FirefoxDriver(service);
                    _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
                    break;
                case BrowserType.IE:
                    break;
                default:
                    break;
            }
        }

    }

    enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
}
