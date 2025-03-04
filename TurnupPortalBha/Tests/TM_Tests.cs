using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using TurnupPortalBha.Pages;
using TurnupPortalBha.Utilities;

namespace TurnupPortalBha.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver

    {


        [SetUp]
        public void SetupTest()
        {   //Open browser
            driver = new ChromeDriver();

            //Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);


            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);

            
        }
        [Test]
        public void CreateTimeTest()
        {
            //Create Time record
            //TM_Page object initialization and definition
            TMPage tMPageobj = new TMPage(); 
            tMPageobj.CreateTimeRecord(driver);            
        }
        [Test]
        public void EditTimeTest()
        {
            //Edit Time record
            TMPage tMPageobj = new TMPage();
            tMPageobj.EditTimeRecord(driver);            
        }

        [Test]
        public void DeleteTimeTest()
        {
            //Delete Time record
            TMPage tMPageobj = new TMPage();
            tMPageobj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
