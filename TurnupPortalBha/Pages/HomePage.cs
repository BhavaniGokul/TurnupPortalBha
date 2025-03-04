using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TurnupPortalBha.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        { 
            //Click on Administration tab
            IWebElement administrationTab = driver.FindElement(By.XPath("(//a[@class='dropdown-toggle'])[1]"));
            administrationTab.Click();

            //Click on Time and Materials tab
            IWebElement timeAndMaterialsTab = driver.FindElement(By.XPath("(//ul[@class='dropdown-menu']//a)[3]"));
            timeAndMaterialsTab.Click();

           
        }
    }
}
