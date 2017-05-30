using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace Appium_Project
{
    [TestClass]
    public class Ap
    {

        AppiumDriver<IWebElement> driver;


        [TestMethod]
        public void TestMethod1()
        {

            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("devicename","");
            cap.SetCapability("apppackage", "");
            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4273/wd/hub"), cap);

        }
    }
}
