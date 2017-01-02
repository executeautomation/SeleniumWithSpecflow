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

        [Given(@"I verify the entered user form details in the application database")]
        public void GivenIVerifyTheEnteredUserFormDetailsInTheApplicationDatabase(Table table)
        {
            //Mock data collection
            List<AUTDatabase> mockAUTData = new List<AUTDatabase>()
            {
                new AUTDatabase()
                {
                    FirstName = "Karthik",
                    Initial = "k",
                    MiddleName = "k"
                },

                new AUTDatabase()
                {
                    FirstName = "Prashanth",
                    Initial = "k",
                    MiddleName = "k"
                }
            };

            //For verification with single row data
            var result = table.FindAllInSet(mockAUTData);

            //For verification againt Multiple row data
            var resultnew = table.FindAllInSet(mockAUTData);

        }


    }

    public class AUTDatabase
    {
        public string Initial { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }
    }



}
