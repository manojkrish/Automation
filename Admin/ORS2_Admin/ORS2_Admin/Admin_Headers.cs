using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ORS2_Admin
{
    public class B2C_Test_Taker_Flow 
    {

        public IWebDriver driver;

        By Heeder_Menu = By.XPath("//general-navigation/ul/li[1]/a");

        By All_Organisation_Dropdown = By.XPath("//general-navigation/ul/li[1]/ul/li/a");

        By All_Countries = By.XPath("//general-navigation/ul/li[2]/a");

        By All_Countries_Dropdown = By.XPath("//general-navigation/ul/li[2]/ul/li/a");

        By All_Centres = By.XPath("//general-navigation/ul/li[3]/a");

        By All_Centres_Dropdown = By.XPath("//general-navigation/ul/li[3]/ul/li/a");

        By All_Locations = By.XPath("//general-navigation/ul/li[4]/a");

        By All_locations_Dropdown = By.XPath("//general-navigation/ul/li[4]/ul/li/a");

        By Test_Taker_Menu = By.XPath("html/body/div/admin-sidebar/aside/section/ul/centre-context-visible/div/ng-transclude/li[2]/a");

        By Test_Taker_B2C_Test_takers = By.XPath("//*[@class='sidebar-menu']//centre-context-visible//li[2]/ul/li[1]/a");

        By Add_Test_Taker = By.XPath("//*[@class='box-header bc-filter-box-header']/a");

        By First_Name = By.XPath("//*[@ng-model='vm.model.firstName']");

        By Sur_Name = By.XPath("//*[@ng-model='vm.model.surname']");

        By DOB = By.XPath("//*[@ng-model='vm.model.dob']");

        By Email = By.XPath("//*[@ng-model='vm.model.email']");

        By Id_Does_Not_require = By.XPath("//*[@ng-model='vm.model.idDoesNotExpire']");

        By ID_Type = By.XPath("//*[@ng-model='vm.model.idTypeId']//option");

        By ID_Number = By.XPath("//*[@ng-model='vm.model.idNumber']");

        By ID_Issuing_Authority = By.XPath("//*[@ng-model='vm.model.issuingAuthority']");

        By ID_Expiry_date = By.XPath("//*[@ng-model='vm.model.idExpiry']");

        By Telephone_Number = By.XPath("//*[@ng-model='vm.model.telephone']");

        By Mobile_Number = By.XPath("//*[@ng-model='vm.model.mobile']");

        By Address_1 = By.XPath("//*[@ng-model='vm.model.address.streetAddress1']");

        By Address_2 = By.XPath("//*[@ng-model='vm.model.address.streetAddress2']");

        By Address_3 = By.XPath("//*[@ng-model='vm.model.address.streetAddress3']");

        By Address_4 = By.XPath("//*[@ng-model='vm.model.address.streetAddress4']");

        By City = By.XPath("//*[@ng-model='vm.model.address.town']");

        By State = By.XPath("//*[@ng-model='vm.model.address.state']");

        By Post_Code = By.XPath("//*[@ng-model='vm.model.address.postCode']");

        By Country = By.XPath("//*[@ng-model='vm.model.address.countryId']//option");

        //Calendar

        By calender_Open_Click = By.XPath("html/body/div/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/input");

        By Date_Picker_Previous_button = By.XPath("html/body/div/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/div[2]/ul/li[1]/div/div/div/table/thead/tr[1]/th[1]/button");

        By Date_Picker_Next_button = By.XPath("html/body/div[1]/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/div[2]/ul/li[1]/div/div/div/table/thead/tr[1]/th[3]/button");

        By Current_Month_Year_Picker = By.XPath(".//*[@id='datepicker-1576-5995-title']");

        By Date_Table = By.XPath("//*[@class='uib-daypicker ng-scope']//tbody//tr[1]//td//button");

        By Month_Picker_Previous_button = By.XPath("//*[@class='uib-monthpicker ng-scope']//thead/tr/th[1]//button");

        By Month_Picker_Next_button = By.XPath("//*[@class='uib-monthpicker ng-scope']//thead/tr/th[3]//button");

        By Current_Year_on_Click_Month_year_Pick = By.XPath("//*[@class='uib-datepicker-popup dropdown-menu ng-scope']//thead//tr[1]//th[2]//*[@class='ng-binding']");
            
            //By.XPath("//*[@aria-activedescendant='datepicker-711-7742-17']//thead/tr[1]/th[2]//button//*[@class='ng-binding']");
            
            //By.XPath("html/body/div/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/div[2]/ul"); 
            
            //By.XPath("//*[@aria-activedescendant='datepicker-711-7742-17']//thead/tr[1]/th[2]//button//*[@class='ng-binding']");

        

        public B2C_Test_Taker_Flow(IWebDriver driver)
        {

            driver = this.driver;
        
        }


        public void PreConfig_Admin_Values()
        {

            Thread.Sleep(9000);

            Console.WriteLine("Pass");

            driver.FindElement()


            Utilities.Click_On_Element(driver, All_Organisation, 60);

            Utilities.Customized_Drop_Down_Select(driver, All_Organisation_Dropdown, "British Council");

            Utilities.Click_On_Element(driver, All_Countries, 60);

            Utilities.Customized_Drop_Down_Select(driver, All_Countries_Dropdown, "India");

            Utilities.Click_On_Element(driver, All_Centres, 60);

            Utilities.Customized_Drop_Down_Select(driver, All_Centres_Dropdown, "British Council Examinations and English Services India Private Limited");

            Utilities.Click_On_Element(driver, All_Locations, 60);

            Utilities.Customized_Drop_Down_Select(driver, All_locations_Dropdown, "Chennai (South India)");

            Thread.Sleep(5000);

            if (!Utilities.Displayed_Asserting(driver, Test_Taker_B2C_Test_takers))
            {

                Utilities.Click_On_Element(driver, Test_Taker_Menu, 60);

            }

            Utilities.Click_On_Element(driver, Test_Taker_B2C_Test_takers, 60);

            Thread.Sleep(4000);

            Utilities.Click_On_Element(driver, Add_Test_Taker, 60);

            Utilities.Send_Keys(driver, First_Name, 60, "First_TestTaker");

            Utilities.Send_Keys(driver, Sur_Name, 60, "surtesttaker");
            
            //  }
            //Utilities.Send_Keys(driver, DOB, 60, "10-01-1985");

            // public void date()
            // {
            //       Utilities.Click_On_Element(driver, calender_Open_Click, 60);

            //     Thread.Sleep(5000);

            //   if (Utilities.Get_text(driver,Current_Year_on_Click_Month_year_Pick,60).Contains("1985"))
            // {

            // Utilities.Click_On_Element(driver, Current_Year_on_Click_Month_year_Pick, 60);

            //                Utilities.Click_On_Element(driver, Current_Year_on_Click_Month_year_Pick, 60);

            //              IList<IWebElement> we = driver.FindElements(By.XPath(".//*[@class='uib-yearpicker ng-scope']//tbody/tr/td"));

            //        foreach (IWebElement Count in we)
            //      {
            //      while (Count.Text.Contains("2001"))
            //        {

            //        Count.Click();



            //  }


            // }

            // }     

            // }

            Utilities.Send_Keys(driver, Email, 60, "Testtaker@test.com");

            Utilities.Click_On_Element(driver, Id_Does_Not_require, 60);

            Utilities.Customized_Drop_Down_Select(driver, ID_Type, "National Identity Card");

            Utilities.Send_Keys(driver, ID_Number, 60, "123546789");

            Utilities.Send_Keys(driver, ID_Issuing_Authority, 60, "AuthorityTest");

            //Utilities.Send_Keys(driver, ID_Expiry_date, 60, "20-302017");

            Utilities.Send_Keys(driver, Telephone_Number, 60, "1234567890");

            Utilities.Send_Keys(driver, Mobile_Number, 60, "0987654321");

            Utilities.Send_Keys(driver, Address_1, 60, "Address1");

            Utilities.Send_Keys(driver, Address_2, 60, "Address2");

            Utilities.Send_Keys(driver, Address_3, 60, "Address3");

            Utilities.Send_Keys(driver, Address_4, 60, "Address4");

            Utilities.Send_Keys(driver, City, 60, "city1");

            Utilities.Send_Keys(driver, State, 60, "state");

            Utilities.Send_Keys(driver, Post_Code, 60, "098789098");

            Utilities.Customized_Drop_Down_Select(driver, Country, "Afghanistan");

        }  
            
       }
    }
