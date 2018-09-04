using Framework.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Framework.Global.CommonMethods;

namespace Framework.Global
{
    class Login
    {
        public static int LoginBase = Int32.Parse(Resource.Login);

        public void LoginSuccessfull()
        {

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");

            // Navigating to Login page using value from Excel
            // Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(LoginBase, "Url"));

            // Sending the username 
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(2, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(2, "Locator"), ExcelLib.ReadData(2, "LocatorValue"), ExcelLib.ReadData(LoginBase, "Username"));



            // Sending the password
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(3, "LocatorValue")), 6);
            Driver.GetClear(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"));
            Driver.Textbox(Driver.driver, ExcelLib.ReadData(3, "Locator"), ExcelLib.ReadData(3, "LocatorValue"), ExcelLib.ReadData(LoginBase, "Password"));

            // Clicking on the login button
            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(4, "LocatorValue")), 6);
            // Driver.GetClear(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));
            Driver.ActionButton(Driver.driver, ExcelLib.ReadData(4, "Locator"), ExcelLib.ReadData(4, "LocatorValue"));
            //Thread.Sleep(2000);

            Driver.WaitForElement(Driver.driver, By.XPath(ExcelLib.ReadData(5, "LocatorValue")), 6);
            string Actualmessage = Driver.driver.FindElement(By.XPath("//div[@class='col-md-6 col-md-offset-3']/h1")).Text;
            Console.WriteLine("mess==" + Actualmessage);

             string Expectedmsg = "Hi "+ExcelLib.ReadData(LoginBase, "Username") + "!";

             if (Actualmessage.ToLower() == Expectedmsg.ToLower())
             {

                Console.WriteLine("pass");
             }
             else
            {
                Console.WriteLine("fail");
            }

        }
    }
}
