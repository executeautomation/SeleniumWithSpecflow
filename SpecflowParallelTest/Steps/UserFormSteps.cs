using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowParallelTest.Steps
{
    [Binding]
    class UserFormSteps
    {
        private IWebDriver _driver;

        public UserFormSteps(IWebDriver driver)
        {
            _driver = driver;
        }



        [Given(@"I start entering user form details like")]
        public void GivenIStartEnteringUserFormDetailsLike(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _driver.FindElement(By.Id("Initial")).SendKeys((string)data.Initial);
            _driver.FindElement(By.Id("FirstName")).SendKeys((string)data.FirstName);
            _driver.FindElement(By.Id("MiddleName")).SendKeys((string)data.MiddleName);
            Thread.Sleep(2000);
        }

        [Given(@"I click submit button")]
        public void GivenIClickSubmitButton()
        {
            _driver.FindElement(By.Name("Save")).Click();
        }


    }
}
