using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecflowParallelTest.Pages
{
    public class LoginPage
    {

        //Classical way of initializing Pages via POM concept - Until Selenium 3.10.0

        //public LoginPage(IWebDriver driver)
        //{
        //    PageFactory.InitElements(driver, this);
        //}

        //[FindsBy(How = How.Name, Using = "UserName")]
        //public IWebElement txtUserName { get; set; }

        //[FindsBy(How = How.Name, Using = "Password")]
        //public IWebElement txtPassword { get; set; }

        //[FindsBy(How = How.Name, Using = "Login")]
        //public IWebElement btnLogin { get; set; }



        private readonly RemoteWebDriver _driver;

        public LoginPage(RemoteWebDriver driver) => _driver = driver;


        IWebElement txtUserName => _driver.FindElementByName("UserName");
        IWebElement txtPassword => _driver.FindElementByName("Password");
        IWebElement btnLogin => _driver.FindElementByName("Login");




        public void EnterUserNameAndPassword(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }


    }
}
