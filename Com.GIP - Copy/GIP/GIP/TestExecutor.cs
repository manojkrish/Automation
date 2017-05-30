//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
//using NUnit.Framework.Interfaces;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace GIP
{
    [TestFixture]
    public class TestExecutor
    {
        public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;
        public Browser_Init BI = new Browser_Init();

        [OneTimeSetUp]
        public void Start_Report()
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

        [SetUp]
        public void Browser_Invoke()
        {
                 
            BI.Browser_Initilization();
            
        }
       
        //[Test]
        public void STED_organisations_test()
        {
            test = extent.StartTest("STED_organisations_test");
            Keyword_Test k = new Keyword_Test();
            k.Browser_Initilization();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\STED organisations_Test_Data.xlsx");
            k.Tear_Down();
            extent.EndTest(test);
        }

        //[Test]
        public void Family_RelationShip_test()
        {
            test = extent.StartTest("Family_RelationShip_test");
            Keyword_Test k = new Keyword_Test();
            k.Browser_Initilization();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Family_relationships_Test_Data.xlsx");
            k.Tear_Down();
            extent.EndTest(test);
        }

        //[Test]
        public void Hubs_Keyword_test()
        {
            test = extent.StartTest("Hubs_Keyword_test");
            Keyword_Test k = new Keyword_Test();
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Hubs_Test_Data.xlsx");
            extent.EndTest(test);
            Thread.Sleep(5000);         
        }
        
        //[Test]
        public void Time_Zone_Keyword_test()
        {
            test = extent.StartTest("Time_Zone_Keyword_test");
            Keyword_Test k = new Keyword_Test();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\TimeZones_Test_Data.xlsx");
            extent.EndTest(test);
            Thread.Sleep(5000);
        }

        //[Test]
        public void Location_Keyword_test()
        {
            extent.StartTest("Location_Keyword_test");
            Keyword_Test k = new Keyword_Test();
            k.Browser_Initilization();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Location_Test_Data.xlsx");
            k.Tear_Down(); 
            extent.EndTest(test);

        }
        
        [Test]
        public void Oranisation_Keyword_test()
        {            
            Keyword_Test k = new Keyword_Test();
            k.Browser_Initilization();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Organisation_Test_Data.xlsx");
            k.Tear_Down();                    
        }

        //[Test]
        public void Organisation_Countries_Keyword_Test()
        {
//            test = extent.StartTest("Organisation_Countries_Keyword_Test");
            Keyword_Test k = new Keyword_Test();
            k.Browser_Initilization();
            Thread.Sleep(9000);
            k.Keys("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Organisation_Countries_Test_Data.xlsx");
  //          test.Log(LogStatus.Pass, "Assert Pass as consition is true");
            k.Tear_Down();           
        }

        //[Test]
        public void Organisation_test()
        {
            Organisation or = new Organisation(driver);
            or.Browser_Initilization();
            or.Add_Organisation();
            or.Edit_Organisation();
            or.Tear_Down();
        }

        //[Test]
        public void Organisation_Countries_test()
        {
            Organisation_Countries or = new Organisation_Countries(driver);
            or.Browser_Initilization();
            or.Add_Organisation_Countries();
            or.Organisation_Countries_Add_General_Tab();
            or.Organisation_Countries_Add_Specific_Tab();
            or.Tear_Down();
        }

        //[Test]
        public void Centres_test()
        {
            Centres or = new Centres(driver);
            or.Browser_Initilization();
            or.Add_Centre();
            or.Add_Centres_General();
            or.Add_Centres_IELTS_Tab();
            or.Click_Save();
            or.Edit_Centre();
            or.Edit_Centres_General();
            or.Edit_Centres_IELTS_Tab();
            or.Click_Save();
            or.Tear_Down();
        }

        //[Test]
        public void Exam_date_test()
        {
            Centres or = new Centres(driver);
            or.Browser_Initilization();
            or.Add_Centre();
            or.Add_Centres_General();
            or.Add_Centres_IELTS_Tab();
            or.Click_Save();
            or.Edit_Centre();
            or.Edit_Centres_General();
            or.Edit_Centres_IELTS_Tab();
            or.Click_Save();
        }

        //[Test]
        public void Terms_and_Condition_test()
        {
            Terms_and_condition or = new Terms_and_condition(driver);
            or.Browser_Initilization();
            or.Search_Terms_and_condition();
            or.Add_Terms_and_condition();
            or.Edit_Terms_and_condition();
            or.Tear_Down();
        }

        //[Test]
        public void Currencies_test()
        {
            Currencies or = new Currencies(driver);
            or.Browser_Initilization();
            or.Search_Dictionaries_Currencies();
            or.Add_Dictionaries_Currencies();
            or.Tear_Down();
        }

        //[Test]
        public void Countries_test()
        {
            Countries or = new Countries(driver);
            or.Browser_Initilization();
            or.Search_Dictionaries_Countries();
            or.Add_Dictionaries_Countries();
            or.Tear_Down();
        }

        [TearDown]
        public void Browser_Close()
        {

            BI.Tear_Down();

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

            Utilities.OutlookSendEmail(st, "GIP_Test_Report", "Execution Report", "C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Reports\\GIP_Application_Report.html", "GIP_AUtomation_Report");


        }    

    }
}
