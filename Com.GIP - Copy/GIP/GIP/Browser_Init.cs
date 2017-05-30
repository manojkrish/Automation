using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace GIP
{
    [TestClass]
    public class Browser_Init
    {

        public IWebDriver driver;


        [TestInitialize]
        public void Browser_Initilization()
        {

            driver = new ChromeDriver(@"C:\ChromeDriver");
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().Refresh();
            driver.Navigate().GoToUrl("http://gip-projectdemo-qa.dev.britishcouncil.org");
            Thread.Sleep(6000);
            
        }

       
        [TestCleanup]
        public void Tear_Down()
        {
            driver.Close();
            driver.Quit();  
        
        }


    }
}
