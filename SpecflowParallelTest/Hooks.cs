using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            service.HideCommandPromptWindow = true;
            service.SuppressInitialDiagnosticInformation = true;
            _driver = new FirefoxDriver(service);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}
