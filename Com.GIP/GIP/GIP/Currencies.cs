using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIP
{
    class Currencies :Browser_Init
    {
        By Dictionaries_Dropdown = By.XPath("//*[@ng-class='{'open': !vm.dictCollapsed}']");

        By Dictionaries_Currencies_Menu = By.XPath("//span[text()='Currencies']");

        By Dictionaries_Currencies_Add = By.XPath("//*[@loading-container='vm.table.settings().$loading']//*[contains(text(),'Add')]");

        By Dictionaries_Currencies_Add_Name_Input = By.XPath("//*[@ng-model='vm.modalData.currency.name']");

        By Dictionaries_Currencies_Add_ISO_Code = By.XPath("//*[@ng-model='vm.modalData.currency.code']");

        By Dictionaries_Currencies_Add_ISOnum = By.XPath("//*[@ng-model='vm.modalData.currency.isoNum']");

        By Dictionaries_Currencies_Add_Active = By.XPath("//*[@ng-model='vm.modalData.currency.active']");

        By Save_Dictionaries_Currencies_Add = By.XPath("//button[@bc-click='vm.save()']");

        By Dictionaries_Currencies_Add_Cancel = By.XPath("//*[@class='box-footer']//a");

        //SEARCH CURRENCIES

        By Search_By_Currencies = By.XPath("//*[@ng-model='vm.filters.query']");

        By Search_Grid = By.XPath("//*[@class='box-body']//table//tbody");


        public Currencies(IWebDriver driver)
        {

            this.driver = driver;

        }

        public void Add_Dictionaries_Currencies()
        {

            Utilities.Click_On_Element(driver, Dictionaries_Dropdown, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Currencies_Menu, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Currencies_Add, 60);

            Utilities.Send_Keys(driver, Dictionaries_Currencies_Add_Name_Input, 60, "AutomatedCountriesName");

            Utilities.Send_Keys(driver, Dictionaries_Currencies_Add_ISO_Code, 60, "CODE");

            Utilities.Send_Keys(driver, Dictionaries_Currencies_Add_ISOnum, 60, "NUM2");

            Utilities.Click_On_Element(driver, Dictionaries_Currencies_Add_Active, 60);

            Utilities.Click_On_Element(driver, Save_Dictionaries_Currencies_Add, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Currencies_Add_Cancel, 60);

        }

        public void Search_Dictionaries_Currencies()
        {

            Utilities.Send_Keys(driver, Search_By_Currencies, 60, "Bolivia, Bolivianos");

            Utilities.Search_Field_Edit_Click(driver, Search_Grid, "Bolivia, Bolivianos");

        }
    }
}
