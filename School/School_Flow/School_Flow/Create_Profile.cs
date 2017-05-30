using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace School_Flow
{
    public class Create_Profile : Browser
    {

        By Current_System_date = By.XPath("//*[@id='change-date-input']");

        By Current_System_Date_Set = By.XPath("//*[@id='set-date-button']");

        By Session = By.XPath("//*[@id='selectedSession']");

        By Session_Selection = By.XPath("//*[@id='selectedSession']//option");

        By Country = By.XPath("//*[@id='country-menu-select']");

        By Country_Selection = By.XPath("//*[@id='country-menu-select']//ul//li");

        By Configuration_Menu = By.XPath("//*[@id='configuration-menu-button']");

        By Configuration_School = By.XPath("//*[@id='school-menu-button']");

        By Configuration_School_Search = By.XPath(".//*[@id='mainGrid']/div[1]/div/table/thead/tr[2]/th[1]/span/span/span/input");

        By Configuration_School_Search_DropDown = By.XPath(".//*[@id='mainGrid']/div[1]/div/table/thead/tr[1]/th[1]/a");
        
        By Configuration_School_Search_Result_Click = By.XPath(".//*[@id='mainGrid']/div[2]/table/tbody/tr/td[1]/a");

        By Create_New_Profile = By.XPath(".//*[@id='PreparationCentre.CreateNewProfile']");

        By Centre_Number = By.XPath(".//*[@id='PreparationCentre.CentreNumber']");

        By Venue_Type = By.XPath(".//*[@id='NewProfile.VenueType']");

        By Venue_Type_Value = By.XPath(".//*[@id='NewProfile.VenueType']//option");

        By Create_New_Profile_Submit = By.XPath(".//*[@id='submit-button']");

        By Profile_Already_Exist = By.XPath(".//*[@id='toast-container']/div/div");

        By Back = By.XPath(".//*[@id='back-button']");

        By School_Admin_Link = By.XPath(".//*[@id='ng-app']/body/div[1]/header/div/span[2]/a");

        By Create_Profile_Tr_values = By.XPath(".//*[@id='ng-app']/body/div[1]/div[2]/section/div[2]/div[3]/div[2]/div[2]/div[2]/table/tbody/tr");

        By Create_Profile_Td_values = By.XPath(".//*[@id='ng-app']/body/div[1]/div[2]/section/div[2]/div[3]/div[2]/div[2]/div[2]/table/tbody/tr/td");



        public Create_Profile(IWebDriver driver)
        {

            this.driver = driver;

        }


        public void Creation()
        {

                Utilities.Clear_Field(driver, Current_System_date, 60);

                Thread.Sleep(4000);

                Utilities.Send_Keys(driver, Current_System_date, 60, "03/03/2016");

                Thread.Sleep(4000);

                Utilities.Click_On_Element(driver, Current_System_Date_Set, 60);

                Thread.Sleep(4000);

                String strQuery = "SELECT * FROM [Sheet1$]"; //where Ref='TC1'";

                string temp = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                Utilities util = new Utilities();

                DataTable dtRunInfo = util.readDataFromExcel("C:\\Automation\\School\\School_Flow\\School_Flow\\DataSheet.xlsx", strQuery);

                for (int i = 0; i < dtRunInfo.Rows.Count; i++)//FOR Loop 1

                {
                    
                    enterUserInfo(dtRunInfo, i);


                }

            }

        public void enterUserInfo(DataTable dtRunInfo, int index)
            {
                Thread.Sleep(4000);

                Utilities.Click_On_Element(driver, Session, 60);

                Thread.Sleep(4000);

                Utilities.Customized_Drop_Down_Select(driver, Session_Selection, (string)dtRunInfo.Rows[index]["SESSION"]);

                Thread.Sleep(4000);

                Utilities.Click_On_Element(driver, Country, 60);

                Thread.Sleep(4000);

                Utilities.Customized_Drop_Down_Select(driver, Country_Selection, (string)dtRunInfo.Rows[index]["COUNTRY"]);

                Thread.Sleep(4000);

                Utilities.Click_On_Element(driver, Configuration_Menu, 60);

                Thread.Sleep(4000);

                Utilities.Click_On_Element(driver, Configuration_School, 60);

                Thread.Sleep(4000);

                Utilities.Send_Keys(driver, Configuration_School_Search, 60, (string)dtRunInfo.Rows[index]["SCHOOL"]);

                Thread.Sleep(7000);

                Utilities.Click_On_Element(driver, Configuration_School_Search_DropDown, 60);

                Thread.Sleep(7000);

                Utilities.Click_On_Element(driver, Configuration_School_Search_Result_Click, 60);

                Thread.Sleep(7000);

                Utilities.Click_On_Element(driver, Create_New_Profile, 60);

                Thread.Sleep(4000);

                Utilities.Send_Keys(driver, Centre_Number, 60, (string)dtRunInfo.Rows[index]["CENTRE NUMBER"]);

                Thread.Sleep(7000);

                Utilities.Click_On_Element(driver, Venue_Type, 60);

                Thread.Sleep(7000);

                Utilities.Customized_Drop_Down_Select(driver, Venue_Type_Value, (string)dtRunInfo.Rows[index]["VENUE"]);

                Thread.Sleep(7000);

                Utilities.Click_On_Element(driver, Create_New_Profile_Submit, 60);

                Thread.Sleep(3000);

                if (Utilities.Enabled_Asserting(driver, Profile_Already_Exist))
                {

                    Console.WriteLine("Profile is already created for the school:"+(string)dtRunInfo.Rows[index]["SCHOOL"]);
                
                    Thread.Sleep(2000);

                    Utilities.Click_On_Element(driver, Back, 60);

                    Thread.Sleep(4000);

                    Utilities.Click_On_Element(driver, School_Admin_Link, 60);

                    Utilities.Click_On_Element(driver, Configuration_Menu, 60);

            }
                else
                {
                      Thread.Sleep(2000);

                      Utilities.Click_On_Element(driver, Back, 60);

                      Thread.Sleep(4000);

                      Utilities.Click_On_Element(driver, School_Admin_Link, 60);

                      Utilities.Click_On_Element(driver,Configuration_Menu,60);


                }
        }
    }
}
