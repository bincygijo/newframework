using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.Global.CommonMethods;

namespace Framework.Pages
{
    public class Register
    {
          internal Register()
          {
              PageFactory.InitElements(Driver.driver, this);

          }

          //Enter Firstname
          [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
          private IWebElement FirstName{ get; set; }

          //Enter Lastname
          [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
          private IWebElement LastName { get; set; }

          //Enter Username
          [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
          private IWebElement UserName { get; set; }

          //Enter Password
          [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
          private IWebElement Password { get; set; }


        public void UserRegistration()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Register");

            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));

            //Enter Firstname
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(2, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"), ExcelLib.ReadData(2, "InputValue"));


            //Enter Lastname
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(3, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(3, "InputValue"));

            //Enter Username
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(4, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"), ExcelLib.ReadData(4, "InputValue"));

            //Enter Password
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(5, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "LocatorValue"), ExcelLib.ReadData(5, "InputValue"));

            //Click Register button
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(6, "LocatorValue")), 6);
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "LocatorValue"));

            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(7, "LocatorValue")), 6);
            string Actualmessage = Driver.driver.FindElement(By.XPath("//div[@class='alert alert-success']")).Text;
            string Expectedmsg = "Registration successful";
            if (Actualmessage.ToLower() == Expectedmsg.ToLower())
            {

                Login loginobj = new Login();
                loginobj.LoginSuccessfull();

                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Registration successful");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Registration successful");
                //Adding screenshot in extendReport
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Registration");
                string screenShotPath = Global.CommonMethods.SaveScreenShotClass.SaveScreenshot(Driver.driver, "Register");
                Base.test.Log(LogStatus.Pass, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
                
                
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Registration is not successfull");
            }
        }

        public void ValidateFirstName()
        {
            try
            {
                string Username = Driver.driver.FindElement(By.XPath("//div[@class='col-md-6 col-md-offset-3']/h1")).Text;
                Console.WriteLine(Username);
            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Error, "There is an error: " + e);
                Console.WriteLine("There is an error: " + e);

            }

            /* internal void register()
             {
                 ExcelLib.PopulateInCollection(Base.ExcelPath, "Register");
                 //Commonsteps();

                 Driver.wait(2);

                 // Email.SendKeys(ExcelLib.ReadData(2, "Email"));
                 //Password.SendKeys(ExcelLib.ReadData(2, "Password"));
                 //ConfirmPassword.SendKeys(ExcelLib.ReadData(2, "ConfirmPassword"));

                 //First Name
                 Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "Value"), ExcelLib.ReadData(2, "FirstName"));
                 Driver.wait(2);
                 //Last Name
                 Driver.Textbox(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "Value"), ExcelLib.ReadData(2, "LastName"));
                 Driver.wait(2);
                 //Email
                 Driver.Textbox(Driver.driver, ExcelLib.ReadData(5, "Locator"), ExcelLib.ReadData(5, "Value"), ExcelLib.ReadData(2, "Email"));
                 Driver.wait(2);
                 //Password
                 Driver.Textbox(Driver.driver, ExcelLib.ReadData(6, "Locator"), ExcelLib.ReadData(6, "Value"), ExcelLib.ReadData(2, "Password"));
                 Driver.wait(2);

                 //role
                 Driver.ActionButton(Driver.driver, ExcelLib.ReadData(11, "Locator"), ExcelLib.ReadData(11, "Value"));

                 IWebElement role = Driver.driver.FindElement(By.XPath(ExcelLib.ReadData(11, "Value")));
               //  new SelectElement(role).SelectByText(ExcelLib.ReadData(2, "Role"));

                 //terms of usage
                 Driver.ActionButton(Driver.driver, ExcelLib.ReadData(7, "Locator"), ExcelLib.ReadData(7, "Value"));

                 //Resgiter button
                 // Registerbutton.Click();
                 //Driver.ActionButton(Driver.driver, ExcelLib.ReadData(8, "Locator"), ExcelLib.ReadData(8, "Value"));
             }*/
        }
    }
}
