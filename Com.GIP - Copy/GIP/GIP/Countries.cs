using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIP
{
    class Countries:Browser_Init
    {
        //ADD COUNTRIES

        By Dictionaries_Dropdown = By.XPath("//*[@ng-class='{'open': !vm.dictCollapsed}']");

        By Dictionaries_Countries_Menu = By.XPath("//span[text()='Countries']");

        By Dictionaries_Countries_Add = By.XPath("//*[@loading-container='vm.table.settings().$loading']//*[contains(text(),'Add')]");

        By Dictionaries_Countries_Add_Name_Input = By.XPath("//*[@ng-model='vm.country.name']");

        By Dictionaries_Countries_Add_ISO_Code2 = By.XPath("//*[@ng-model='vm.country.isoCode']");

        By Dictionaries_Countries_Add_ISO_Code3 = By.XPath("//*[@ng-model='vm.country.isoCode3']");

        By Dictionaries_Countries_Add_ISOnum = By.XPath("//*[@ng-model='vm.country.isoNum']");

        By Dictionaries_Countries_Add_Currency_Type = By.XPath("//*[label='Currency']//select");

        By Dictionaries_Countries_Add_Currency_Dropdown = By.XPath("//*[label='Currency']//select//option");

        By Dictionaries_Countries_Add_Dailing_Code = By.XPath("//*[@ng-model='vm.country.dialingCode']");

        By Dictionaries_Countries_Add_Data_Retention_Period = By.XPath("//*[@ng-model='vm.country.dataRetentionPeriod']");

        By Dictionaries_Countries_Add_Special_Needs = By.XPath("//*[@ng-model='vm.country.specialNeeds']");

        By Dictionaries_Countries_Add_Active = By.XPath("//*[@ng-model='vm.country.active']");

        By Save_Dictionaries_Countries_Add = By.XPath("//button[@bc-click='vm.save()']");

        By Dictionaries_Countries_Add_Cancel = By.XPath("//*[@class='box-footer']//a");

        //SEARCH COUNTRIES

        By Search_By_Countries = By.XPath("//*[@ng-model='vm.filters.query']");

        By Search_Grid = By.XPath("//*[@class='box-body']//table//tbody");


        public Countries(IWebDriver driver)
        {

            this.driver = driver;

        }

        public void Add_Dictionaries_Countries()
        {

            Utilities.Click_On_Element(driver, Dictionaries_Dropdown, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Countries_Menu, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Countries_Add, 60);

            Utilities.Send_Keys(driver, Dictionaries_Countries_Add_Name_Input, 60, "AutomatedCountriesName");

            Utilities.Send_Keys(driver, Dictionaries_Countries_Add_ISO_Code2, 60, "CODE2");

            Utilities.Send_Keys(driver, Dictionaries_Countries_Add_ISO_Code3, 60, "CODE3");

            Utilities.Send_Keys(driver, Dictionaries_Countries_Add_ISOnum, 60, "NUM2");

            Utilities.Click_On_Element(driver, Dictionaries_Countries_Add_Currency_Type, 60);

            Utilities.Customized_Drop_Down_Select(driver, Dictionaries_Countries_Add_Currency_Dropdown, "BAM");

            Utilities.Send_Keys(driver, Dictionaries_Countries_Add_Dailing_Code, 60, "044");

            Utilities.Send_Keys(driver, Dictionaries_Countries_Add_Data_Retention_Period, 60, "10");

            Utilities.Click_On_Element(driver, Dictionaries_Countries_Add_Special_Needs, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Countries_Add_Active, 60);

            Utilities.Click_On_Element(driver, Save_Dictionaries_Countries_Add, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Countries_Add_Cancel, 60);

        }

        public void Search_Dictionaries_Countries()
        {

            Utilities.Send_Keys(driver, Search_By_Countries, 60, "Albania");

            Utilities.Search_Field_Edit_Click(driver, Search_Grid, "Albania");

        }

    }
}
