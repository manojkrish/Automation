using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using NUnit.Framework.Interfaces;

namespace School_Flow
{
    [TestFixture]
    public class TestExecutor
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void Start_Report()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\School_Application_Report.html";
            extent = new ExtentReports(reportPath, true);
            extent
            .AddSystemInfo("Host Name", "Manoj")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Manoj.KRanganathan");
            extent.LoadConfig(projectPath + "Extent-Config.xml");
        }


        [Test]
        public void School_Creation_Flow()
        {
            test = extent.StartTest("School_Creation_Flow");
            Create_Profile cp = new Create_Profile(driver);
            cp.Browser_Initilization();
            cp.Creation();
            cp.Tear_Down();
            extent.EndTest(test);
        }


        [OneTimeTearDown]
        public void End_Report()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var Test_Pass = TestContext.CurrentContext.Result.Outcome;

            if (status == TestStatus.Failed)
            {
                test.Log(LogStatus.Fail, stackTrace + errorMessage);
            }
            else
            {
                test.Log(LogStatus.Pass, stackTrace + Test_Pass);
            }

            extent.Flush();
            extent.Close();

            String[] st = { "Manoj.KRanganathan@in.britishcouncil.org" };

            Utilities.OutlookSendEmail(st, "School_Create_Profile_Report", "Data_upload", "C:\\Automation\\School - Copy\\School_Flow\\School_Flow\\Reports\\School_Application_Report.html", "School_AUtomation_Report");


        }

    }
}
