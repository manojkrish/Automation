using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ORS2_Admin
{
    [TestFixture]
    public class TestExecutor
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;


        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\Admin_Application_Report.html";

            extent = new ExtentReports(reportPath, true);
            extent
            .AddSystemInfo("Host Name", "Manoj")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Manoj.KRanganathan");
            extent.LoadConfig(projectPath + "Extent-Config.xml");
        }


        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");

            driver.Manage().Window.Maximize();

            driver.Navigate().Refresh();

            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().GoToUrl("http://ors2admin-projectdemo-qa.dev.britishcouncil.org");

            Thread.Sleep(9000);
                
        }

        //[Test]
        public void B2C_registration_Test()
        {
            test = extent.StartTest("B2C_registration_Test");

            B2C_Test_Taker_Flow bc = new B2C_Test_Taker_Flow(driver);
            
            bc.PreConfig_Admin_Values();
            
            extent.EndTest(test);
        }

        [Test]
        public void Header_Selector_Test()
        {
            test = extent.StartTest("Header_Selector_test");
            Keyword_Test k = new Keyword_Test();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Admin\\ORS2_Admin\\ORS2_Admin\\Admin_DropDown_Select.xlsx",driver);
            extent.EndTest(test);
        }



        [OneTimeTearDown]
        public void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(LogStatus.Fail, stackTrace + errorMessage);
            }
            extent.Flush();
            extent.Close();
        
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();

            driver.Quit();

        }
    }
}
