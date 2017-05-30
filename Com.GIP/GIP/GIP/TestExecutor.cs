using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIP
{
    [TestClass]
    public class TestExecutor
    {
        public IWebDriver driver;

        [TestMethod]
        public void Organisation_test()
        {
            Organisation or = new Organisation(driver);
            or.Browser_Initilization();
            or.Add_Organisation();
            or.Edit_Organisation();
            or.Tear_Down();
        }

        //[TestMethod]
        public void Organisation_Countries_test()
        {
            Organisation_Countries or = new Organisation_Countries(driver);
            or.Browser_Initilization();
            or.Add_Organisation_Countries();
            or.Organisation_Countries_Add_General_Tab();
            or.Organisation_Countries_Add_Specific_Tab();
            or.Tear_Down();
        }

        //[TestMethod]
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

        //[TestMethod]
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

        //[TestMethod]
        public void Terms_and_Condition_test()
        {
            Terms_and_condition or = new Terms_and_condition(driver);
            or.Browser_Initilization();
            or.Search_Terms_and_condition();
            or.Add_Terms_and_condition();
            or.Edit_Terms_and_condition();
            or.Tear_Down();       
        }

        //[TestMethod]
        public void Currencies_test()
        {
            Currencies or = new Currencies(driver);
            or.Browser_Initilization();
            or.Search_Dictionaries_Currencies();
            or.Add_Dictionaries_Currencies();
            or.Tear_Down();      
        }

        //[TestMethod]
        public void Countries_test()
        {
            Countries or = new Countries(driver);
            or.Browser_Initilization();
            or.Search_Dictionaries_Countries();
            or.Add_Dictionaries_Countries();
            or.Tear_Down();      
         }

           
    }
}
