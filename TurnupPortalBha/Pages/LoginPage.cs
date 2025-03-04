using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TurnupPortalBha.Pages
{
   public class LoginPage
    {
        //Functions that allow user to login to Turnup Portal
        public void LoginActions(IWebDriver driver)
        { 
            //Launch TurnupPortal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //Identify Username field and enter username
            IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
            userNameTextBox.SendKeys("hari");

            //Identify Password field and enter password
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("123123");

            //Identify login and Click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
        }



    }
}
