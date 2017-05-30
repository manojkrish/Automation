using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimp
{
    class Marketing_Question
    {
        public IWebDriver driver;

        //ADD Marketing Questions

        By Dictionaries_Dropdown = By.XPath("//*[@ng-class='{'open': !vm.dictCollapsed}']");

        By Dictionaries_Marketing_Questions_Menu = By.XPath("//span[text()='Marketing questions']");

        By Dictionaries_Marketing_Questions_Add = By.XPath("//*[@loading-container='vm.table.settings().$loading']//*[contains(text(),'Add')]");

        By Dictionaries_Marketing_Questions_Add_Name_Input = By.XPath("//*[@ng-model='vm.marketingQuestion.name']");

        By Dictionaries_Marketing_Questions_Add_Short_Code = By.XPath("//*[@ng-model='vm.marketingQuestion.shortCode']");

        By Dictionaries_Marketing_Questions_Add_Option = By.XPath("//*[@class='box-footer']//button");

        By Dictionaries_Marketing_Questions_Add_ESOL_Code = By.XPath("//*[@ng-model='vm.marketingQuestionOption.esolCode']");

        By Dictionaries_Marketing_Questions_Add_Display_Order = By.XPath("//*[@ng-model='vm.marketingQuestionOption.displayOrder']");

        By Dictionaries_Marketing_Questions_Add_ESOL_Description = By.XPath("//*[@ng-model='vm.marketingQuestionOption.esolDescription']");

        By Dictionaries_Marketing_Questions_Add_Active = By.XPath("//*[@class='checkbox']/label");

        By Dictionaries_Marketing_Questions_Add_SaveChanges = By.XPath("html/body/div[1]/div/div/validation-form/form/div/div/div[3]/button[1]");

        By Dictionaries_Marketing_Questions_Add_Cancel = By.XPath("html/body/div[1]/div/div/validation-form/form/div/div/div[3]/button[2]");

        By Save_Dictionaries_Marketing_Questions_Add = By.XPath("//button[@bc-click='vm.save()']");

        By Dictionaries_Marketing_Questions_Add_Cancel2 = By.XPath("//*[@class='box-footer']//a");

        //SEARCH CURRENCIES

        By Search_By_Currencies = By.XPath("//*[@ng-model='vm.filters.query']");

        By Search_Grid = By.XPath("//*[@class='box-body']//table//tbody");


        public Marketing_Question(IWebDriver driver)
        {

            this.driver = driver;

        }

        public void Add_Dictionaries_Currencies()
        {

            Utilities.Click_On_Element(driver, Dictionaries_Dropdown, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Marketing_Questions_Menu, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Marketing_Questions_Add, 60);

            Utilities.Send_Keys(driver, Dictionaries_Marketing_Questions_Add_Name_Input, 60, "AutomatedCountriesName");

            Utilities.Send_Keys(driver, Dictionaries_Marketing_Questions_Add_Short_Code, 60, "CODE");

            Utilities.Click_On_Element(driver,Dictionaries_Marketing_Questions_Add_Option,60);

            Utilities.Send_Keys(driver,Dictionaries_Marketing_Questions_Add_Display_Order,60,"34");

            Utilities.Send_Keys(driver, Dictionaries_Marketing_Questions_Add_ESOL_Code, 60, "NUM2");

            Utilities.Send_Keys(driver, Dictionaries_Marketing_Questions_Add_ESOL_Description, 60, "Automated description");

            Utilities.Click_On_Element(driver,Dictionaries_Marketing_Questions_Add_Active,60);

            Utilities.Click_On_Element(driver, Save_Dictionaries_Marketing_Questions_Add, 60);

            Utilities.Click_On_Element(driver, Dictionaries_Marketing_Questions_Add_Cancel2, 60);

        }

        public void Search_Dictionaries_Currencies()
        {

            Utilities.Send_Keys(driver, Search_By_Currencies, 60, "26");

            Utilities.Search_Field_Edit_Click(driver, Search_Grid, "26");

        }


    }
}
