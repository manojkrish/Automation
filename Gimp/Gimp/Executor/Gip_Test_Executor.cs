using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gimp
{
    [TestFixture]
    class Gip_Test_Executor
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
            string reportPath = projectPath + "Reports\\GIP_Application_Report.html";
           

            extent = new ExtentReports(reportPath, true);
            extent
            .AddSystemInfo("Host Name", "Manoj")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Manoj.KRanganathan");
            extent.LoadConfig(projectPath + "Extent-Config.xml");
                
        }

       [Test]
        public void Organisation_Test_Flow()
        {

            Browser_Selector.InitBrowser("Chrome");
            Browser_Selector.LoadApplication("http://gimp-projectdemo-qa.dev.britishcouncil.org/#/");
            Organisation or = new Organisation(driver);
            test = extent.StartTest("Organisation_Test_Flow");
            or.Add_Organisation();
            Thread.Sleep(4000);
            or.Edit_Organisation();
            Browser_Selector.CloseAllDrivers();
                                  
        }
        
        [OneTimeTearDown]
        public void GetResult()
        {


            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test.Log(logstatus, stackTrace + errorMessage);

            //extent.EndTest(test);
            extent.Flush();
            
           // var status = TestContext.CurrentContext.Result.Outcome.Status;
            //var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            //var errorMessage = TestContext.CurrentContext.Result.Message;

//            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
  //          {

    //            test.Log(LogStatus.Fail, stackTrace + errorMessage);

      //      }
        //    else
          //  {

            //    test.Log(LogStatus.Pass,stackTrace +errorMessage);
            
           // }
                
            //extent.EndTest(test);
           // extent.Flush();
            //extent.Close();

           String[] st ={"Manoj.KRanganathan@in.britishcouncil.org"};

           Utilities.OutlookSendEmail(st, "GIP_Test_Report", "Execution Report", "C:\\Automation\\Gimp\\Gimp\\Reports\\GIP_Application_Report.html", "GIP_AUtomation_Report");
        }

    }
}
