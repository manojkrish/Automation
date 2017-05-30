using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GIP
{
    class Centres:Browser_Init
    {
        

        By Table_Grid_values = By.XPath("//*[@ng-table='vm.table']/tbody/");

        By Centres_Menu = By.XPath("//span[text()='Centres']");

        By Center_Add = By.XPath("html/body/div[1]/div[2]/ui-view/centerobjectslist/div/ui-view/section/div/div[1]/a");

        //General Tab

        By Name = By.XPath("//*[@ng-model='vm.centerObject.name']");

        By Organisation_Country_Select = By.Name("organisationCountryId");//By.XPath("html/body/div/div[2]/ui-view/centerobjectsadd/section/validation-form/form/div[1]/div/div[1]/ng-form/div/div[1]/div/div[2]/div/div[1]/select");

        By Organisation_country_dropdown = By.XPath("//*[@ng-model='vm.centerObject.organisationCountryId']//option");

        By Time_Zone_Select = By.XPath("html/body/div/div[2]/ui-view/centerobjectsadd/section/validation-form/form/div[1]/div/div[1]/ng-form/div/div[1]/div/div[3]/div/div[1]/select");

        By Time_Zone_dropdown = By.XPath("//*[@ng-model='vm.centerObject.timeZoneId']//option");

        By WBS = By.XPath("//*[@ng-model='vm.centerObject.wbs']");

        By Telephone_Number = By.XPath("//*[@ng-model='vm.centerObject.telephoneNumber']");

        By Country_Select = By.XPath("//*[@name='address.countryId']");

        By Country_Dropdown = By.XPath("//*[@ng-model='vm.model.countryId']//option");

        By Town = By.XPath("//*[@ng-model='vm.model.town']");

        By County = By.XPath("//*[@ng-model='vm.model.county']");

        By Post_Code = By.XPath("//*[@ng-model='vm.model.postCode']");

        By Street_Address_I = By.XPath("//*[@ng-model='vm.model.streetAddress1']");

        By Street_Address_II = By.XPath("//*[@ng-model='vm.model.streetAddress2']");

        By Street_Address_III = By.XPath("//*[@ng-model='vm.model.streetAddress3']");

        By Street_Address_IV = By.XPath("//*[@ng-model='vm.model.streetAddress4']");

        By Active_Center_Check_Box = By.XPath("//*[@class='checkbox']//*[@ng-model='vm.centerObject.active']");

        By IELTS_Context = By.XPath("//*[@class='checkbox']//*[@ng-model='vm.showIeltsTab']");

        By Boss_Context = By.XPath("//*[@class='checkbox']//*[@ng-model='vm.showBossTab']");

        By Schools_Context = By.XPath("//*[@class='checkbox']//*[@ng-model='vm.showSchoolsTab']");

        By IELTS_Tab = By.XPath("//*[@class='nav-tabs-custom nav-tabs-no-margin ng-isolate-scope']//ul//li[2]//a");

        //IELTS Specific

        By IELTS_Telephone_Number = By.XPath("//*[@ng-model='vm.model.telephoneNumber']");

        By IELTS_Fax_Number = By.XPath("//*[@ng-model='vm.model.faxNumber']");

        By IELTS_Email_Enquires = By.XPath("//*[@ng-model='vm.model.publicEmail']");

        By IELTS_Contactc_Name = By.XPath("//*[@ng-model='vm.model.contactName']");

        By IELTS_Export_Email = By.XPath("//*[@ng-model='vm.model.internalEmail']");

        By IELTS_Discount = By.XPath("//*[@ng-model='vm.model.discount']");

        By IELTS_Extras = By.XPath("//*[@ng-model='vm.model.extras']");

        By IELTS_WBS = By.XPath("//*[@ng-model='vm.model.wbs']");

        By IELTS_Center_Number = By.XPath("//*[@ng-model='vm.model.centreNumber']");

        By IELTS_Time_To_Upload = By.XPath("//*[@ng-model='vm.model.uploadTime']");

        By IELTS_Time_To_Reupload = By.XPath("//*[@ng-model='vm.model.reuploadTime']");

        By IELTS_Active_Center = By.XPath("//*[@id='active']");

        By Cancel = By.XPath("//*[@class='box-footer']//a");

        By SaveChanges = By.XPath("//*[@bc-click='vm.save()']");


        //EDIT

        By Centre_Table_Value = By.XPath("//*[@ng-table='vm.table']/tbody/tr");

        By Centre_search_Name_Field = By.XPath("//*[@ng-model='vm.filters.name']");


        public Centres(IWebDriver driver)
        {

            this.driver = driver;

        }

        public void Add_Centre()
        {

            Thread.Sleep(6000);

            Utilities.Click_On_Element(driver, Centres_Menu, 60);

            Thread.Sleep(4000);

            Utilities.Click_On_Element(driver, Center_Add, 60);

        }

        public void Edit_Centre()
        {
            Thread.Sleep(4000);

            Utilities.Click_On_Element(driver, Centres_Menu, 60);

            Thread.Sleep(4000);

            Utilities.Send_Keys(driver, Centre_search_Name_Field, 60, "AutomatedCentre4");

            Thread.Sleep(4000);

            Utilities.Search_Field_Edit_Click(driver, Table_Grid_values, "AutomatedCentre4");
        }

        public void Add_Centres_General()
        {

            Thread.Sleep(4000);

            Utilities.Send_Keys(driver, Name, 60, "AutomatedCentre4");

            Utilities.Customized_Drop_Down_Select(driver, Organisation_country_dropdown, "Zimbabwe - British Council");

            Thread.Sleep(6000);

            Utilities.Customized_Drop_Down_Select(driver, Time_Zone_dropdown, "aaaa");

            Utilities.Send_Keys(driver, WBS, 60, "WBS");

            Utilities.Send_Keys(driver, Telephone_Number, 60, "0987654321");

            Utilities.Click_On_Element(driver, Country_Select, 60);

            Utilities.Send_Keys(driver, Country_Select, 60, "India");

            Utilities.Send_Keys(driver, Town, 60, "TestTown");

            Utilities.Send_Keys(driver, County, 60, "TestCounty");

            Utilities.Send_Keys(driver, County, 60, "678965");

            Utilities.Send_Keys(driver, Post_Code, 60, "123456");

            Utilities.Send_Keys(driver, Street_Address_I, 60, "Address 1");

            Utilities.Send_Keys(driver, Street_Address_II, 60, "Address 2");

            Utilities.Send_Keys(driver, Street_Address_III, 60, "Address 3");

            Utilities.Send_Keys(driver, Street_Address_IV, 60, "Address 4");

            Utilities.Click_On_Element(driver, Active_Center_Check_Box, 60);

            try
            {

                Utilities.Displayed_Asserting(driver, IELTS_Tab);

            }
            catch (NoSuchElementException)
            {

                Utilities.Click_On_Element(driver, IELTS_Context, 60);

            }

            Utilities.Click_On_Element(driver, IELTS_Tab, 60);

        }

        public void Add_Centres_IELTS_Tab()
        {

            Thread.Sleep(4000);

            Utilities.Send_Keys(driver, IELTS_Telephone_Number, 60, "2345617890");

            Utilities.Send_Keys(driver, IELTS_Fax_Number, 60, "0987612345");

            Utilities.Send_Keys(driver, IELTS_Email_Enquires, 60, "Test_Email_Enquires@Test.com");

            Utilities.Send_Keys(driver, IELTS_Contactc_Name, 60, "Test_Name");

            Utilities.Send_Keys(driver, IELTS_Export_Email, 60, "Test_Export_Email@Test.com");

            Utilities.Send_Keys(driver, IELTS_Discount, 60, "100");

            Utilities.Send_Keys(driver, IELTS_Extras, 60, "34556");

            Utilities.Send_Keys(driver, IELTS_WBS, 60, "SBW");

            Utilities.Send_Keys(driver, IELTS_Center_Number, 60, "12345");

            Utilities.Send_Keys(driver, IELTS_Time_To_Upload, 60, "240");

            Utilities.Send_Keys(driver, IELTS_Time_To_Reupload, 60, "10");

            Utilities.Click_On_Element(driver, IELTS_Active_Center, 60);

        }

        public void Edit_Centres_General()
        {

            Utilities.Clear_Field(driver, Name, 60);

            Utilities.Send_Keys(driver, Name, 60, "EditedAutomatedCentre4");

            Utilities.Customized_Drop_Down_Select(driver, Organisation_country_dropdown, "Zimbabwe - British Council");

            Thread.Sleep(6000);

            Utilities.Customized_Drop_Down_Select(driver, Time_Zone_dropdown, "aaaa");

            Utilities.Clear_Field(driver, WBS, 60);

            Utilities.Send_Keys(driver, WBS, 60, "WBS");

            Utilities.Clear_Field(driver, Telephone_Number, 60);

            Utilities.Send_Keys(driver, Telephone_Number, 60, "0987654321");

            Utilities.Click_On_Element(driver, Country_Select, 60);

            Utilities.Send_Keys(driver, Country_Select, 60, "India");

            Utilities.Clear_Field(driver, Town, 60);

            Utilities.Send_Keys(driver, Town, 60, "TestTown");

            Utilities.Clear_Field(driver, County, 60);

            Utilities.Send_Keys(driver, County, 60, "TestCounty");

            Utilities.Clear_Field(driver, Post_Code, 60);

            Utilities.Send_Keys(driver, Post_Code, 60, "123456");

            Utilities.Clear_Field(driver, Street_Address_I, 60);

            Utilities.Send_Keys(driver, Street_Address_I, 60, "Address 1");

            Utilities.Clear_Field(driver, Street_Address_II, 60);

            Utilities.Send_Keys(driver, Street_Address_II, 60, "Address 2");

            Utilities.Clear_Field(driver, Street_Address_III, 60);

            Utilities.Send_Keys(driver, Street_Address_III, 60, "Address 3");

            Utilities.Clear_Field(driver, Street_Address_IV, 60);

            Utilities.Send_Keys(driver, Street_Address_IV, 60, "Address 4");

            if (!Utilities.Enabled_Asserting(driver, Active_Center_Check_Box))
            {

                Utilities.Click_On_Element(driver, Active_Center_Check_Box, 60);

            }

            try
            {

                Utilities.Displayed_Asserting(driver, IELTS_Tab);

            }
            catch (NoSuchElementException)
            {

                Utilities.Click_On_Element(driver, IELTS_Context, 60);

            }

            Utilities.Click_On_Element(driver, IELTS_Tab, 60);


        }

        public void Edit_Centres_IELTS_Tab()
        {

            Thread.Sleep(4000);

            Utilities.Clear_Field(driver, IELTS_Telephone_Number, 60);

            Utilities.Send_Keys(driver, IELTS_Telephone_Number, 60, "2345617890");

            Utilities.Clear_Field(driver, IELTS_Fax_Number, 60);

            Utilities.Send_Keys(driver, IELTS_Fax_Number, 60, "0987612345");

            Utilities.Clear_Field(driver, IELTS_Email_Enquires, 60);

            Utilities.Send_Keys(driver, IELTS_Email_Enquires, 60, "Test_Email_Enquires@Test.com");

            Utilities.Clear_Field(driver, IELTS_Contactc_Name, 60);

            Utilities.Send_Keys(driver, IELTS_Contactc_Name, 60, "Test_Name");

            Utilities.Clear_Field(driver, IELTS_Export_Email, 60);

            Utilities.Send_Keys(driver, IELTS_Export_Email, 60, "Test_Export_Email@Test.com");

            Utilities.Clear_Field(driver, IELTS_Discount, 60);

            Utilities.Send_Keys(driver, IELTS_Discount, 60, "100");

            Utilities.Clear_Field(driver, IELTS_Extras, 60);

            Utilities.Send_Keys(driver, IELTS_Extras, 60, "34556");

            Utilities.Clear_Field(driver, IELTS_WBS, 60);

            Utilities.Send_Keys(driver, IELTS_WBS, 60, "SBW");

            Utilities.Clear_Field(driver, IELTS_Center_Number, 60);

            Utilities.Send_Keys(driver, IELTS_Center_Number, 60, "12345");

            Utilities.Clear_Field(driver, IELTS_Time_To_Upload, 60);

            Utilities.Send_Keys(driver, IELTS_Time_To_Upload, 60, "220");

            Utilities.Clear_Field(driver, IELTS_Time_To_Reupload, 60);

            Utilities.Send_Keys(driver, IELTS_Time_To_Reupload, 60, "10");

            Thread.Sleep(3000);

            if (!Utilities.Selected_Asserting(driver, IELTS_Active_Center))
            {

                Utilities.Click_On_Element(driver, IELTS_Active_Center, 60);

            }

        }

        public void Click_Save()
        {

            Utilities.Click_On_Element(driver, SaveChanges, 60);

        }
    }
}
