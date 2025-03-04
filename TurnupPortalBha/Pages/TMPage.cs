using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TurnupPortalBha.Utilities;

namespace TurnupPortalBha.Pages
{
    public class TMPage
    {
        public IWebElement goToLastPageButton, saveButton, savedCode, codeInputField, descriptionInputField, priceInputField;
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("(//div[@id='container']//a)[1]"));
            createNewButton.Click();

            //Click on TypeCode Dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//span[@class='k-input']"));
            typeCodeDropdown.Click();
            Thread.Sleep(2000);

            //Click on TimeOption
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();
            Thread.Sleep(2000);

            //Enter Code in the Code TextBox
            IWebElement codeInputField = driver.FindElement(By.XPath("//input[@id='Code']"));
            codeInputField.SendKeys("CodeBha001");

            //Enter Description in the decription TextBox
            IWebElement descriptionInputField = driver.FindElement(By.XPath("//input[@id='Description']"));
            descriptionInputField.SendKeys("This is a description for Bha001");

            //Enter Price in the price per unit TextBox
            IWebElement priceInputField = driver.FindElement(By.XPath("(//span[contains(@class,'numerictextbox')]//input)[1]"));
            priceInputField.SendKeys("7300");

            //Click on Save button
            saveButton = driver.FindElement(By.XPath("//input[@id='SaveButton']"));
            saveButton.Click();
            Thread.Sleep(2000);


            //explicit wait applied
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'Go to the last page')]"")));

            //Fluent Wait applied
            Wait.WaitToBeVisible(driver, "XPath", "//span[contains(text(),'Go to the last page')]", 5);

            //Click on goToLastPage button
            goToLastPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            goToLastPageButton.Click();

            Thread.Sleep(2000);

            //@@@doubt:  One time it is working properly, the other time throwing No such element exception
            savedCode = driver.FindElement(By.XPath("//table[@role='grid']/tbody/tr[last()]/td[1]"));

            Assert.That(savedCode.Text == "CodeBha001", "**New Time record has not been created successfully**");
            //Check Time record is saved successfully
           /* if (savedCode.Text == "CodeBha001")
            {
                Assert.Pass("**Time record has been created successfully**");
            }
            else
            {
                Assert.Fail("**New Time record has not been created successfully**");
            }*/
        }
        //*********Edit the saved time record**********
        public void EditTimeRecord(IWebDriver driver)
            {
            //Click on goToLastPage button
            goToLastPageButton.Click();
            Thread.Sleep(2000);

                             
            IWebElement editButton = driver.FindElement(By.XPath("//table[@role='grid']/tbody/tr[last()]/td[5]/a[contains(@class, 'k-grid-Edit')]"));
            editButton.Click();
            Thread.Sleep(2000);

            //Edit Code in the Code TextBox
            //The very first time it didnt throw any error, after few executions throwing Stale element exception
            //codeInputField.Clear();
            codeInputField = driver.FindElement(By.XPath("//input[@id='Code']"));
            codeInputField.Clear();
            codeInputField.SendKeys("CodeBha001edited");

            //Edit Description in the decription TextBox
            descriptionInputField = driver.FindElement(By.XPath("//input[@id='Description']"));
            descriptionInputField.Clear();
            descriptionInputField.SendKeys("This is a description for Bha001edited");


            //Enter Price in the price per unit  

            //Fluent Wait applied
           /* Wait.WaitToBeClickable(driver, "XPath", "(//span[contains(@class,'numerictextbox')]//input)[1]", 5);
           
            priceInputField = driver.FindElement(By.XPath("(//span[contains(@class,'numerictextbox')]//input)[1]"));
            priceInputField.Click();
            priceInputField.Clear();
            priceInputField.SendKeys("8400");//throwing element not interactable  exception for price per unit input field
           */
            Thread.Sleep(2000);
            
            //Click on Save button
            saveButton = driver.FindElement(By.XPath("//input[@id='SaveButton']"));
            saveButton.Click();
            Thread.Sleep(2000);



            //Check Time record has been edited successfully

            //Fluent Wait applied
            Wait.WaitToBeVisible(driver, "XPath", "//span[contains(text(),'Go to the last page')]", 5);

            //Click on goToLastPage button
            goToLastPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            goToLastPageButton.Click();

            savedCode = driver.FindElement(By.XPath("//table[@role='grid']/tbody/tr[last()]/td[1]"));

            //Compare edited Time record has been listed correctly in the list page
            if (savedCode.Text == "CodeBha001edited")
            {
                Console.WriteLine("**Time record has been edited successfully**");
            }
            else
            {
                Console.WriteLine("**New Time record has not been edited successfully**");
            }


        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Fluent applied to delete button
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[4]/div/div/div[3]/table/tbody/tr[8]/td[5]/a[2]", 5);

            //Click delete button on last listing record
            IWebElement deleteButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[8]/td[5]/a[2]"));
            deleteButton.Click();

            //explicit wait applied to alert
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());


            // Take control to alert and click yes
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            Console.WriteLine("Clicked 'Yes' in the alert to delete.");

            //Check Time record has been deleted successfully

            //Fluent Wait applied
            Wait.WaitToBeVisible(driver, "XPath", "//span[contains(text(),'Go to the last page')]", 5);

            //Click on goToLastPage button
            goToLastPageButton = driver.FindElement(By.XPath("//span[contains(text(),'Go to the last page')]"));
            goToLastPageButton.Click();

            savedCode = driver.FindElement(By.XPath("//table[@role='grid']/tbody/tr[last()]/td[1]"));

            //Compare edited Time record has been listed correctly in the list page
            if (savedCode.Text != "CodeBha001edited")
            {
                Console.WriteLine("***The time record has been deleted successfully***");
            }
            else
            {
                Console.WriteLine("***Time record has not been deleted successfully***");
            }
            
        }
    }
    }

