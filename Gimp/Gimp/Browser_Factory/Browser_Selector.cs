using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace Gimp
{
    class Browser_Selector
    {
        public static IWebDriver driver;
       
        public static void InitBrowser(string browserName)
        {          
            switch (browserName)
            {
                case "Firefox":
                    
                        driver = new FirefoxDriver();
                     
                         break;

                case "IE":

                        InternetExplorerOptions options = new InternetExplorerOptions();
                        
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

                        driver = new InternetExplorerDriver(@"C:\IEDriver", options);
                   
                        //driver = new InternetExplorerDriver(@"C:\IEDriver");
                       
                         break;

                case "Chrome":
                    
                        driver = new ChromeDriver(@"C:\ChromeDriver");
                    
                        break;
            }            
        }

        public static void LoadApplication(string url)
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().Refresh();

            driver.Manage().Cookies.DeleteAllCookies();
            
            driver.Url = url;
        }

        public static void CloseAllDrivers()
        {

            driver.Close();
            driver.Quit();

        }
    }
}