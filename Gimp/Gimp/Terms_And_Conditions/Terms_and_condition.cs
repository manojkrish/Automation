using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimp
{
    class Terms_and_condition
    {

        public IWebDriver driver;

        //ADD TERMS AND CONDITION

        By Terms_and_conditions_Menu = By.XPath("//span[text()='Terms and conditions']");

        By Terms_and_conditions_Add = By.XPath("//*[@loading-container='vm.table.settings().$loading']//*[contains(text(),'Add')]");

        By Add_Terms_and_condition_Name_Input = By.XPath("//*[@ng-model='vm.termsAndConditions.name']");

        By Add_Terms_and_condition_Short_Code = By.XPath("//*[@ng-model='vm.termsAndConditions.shortCode']");

        By Add_Terms_and_condition_Product_type = By.XPath("//*[@label='Product']//select");

        By Add_Terms_and_condition_Product_Dropdown = By.XPath("//*[@label='Product']//select//option");

        By Add_Terms_and_condition_SubSystem_type = By.XPath("//*[@label='Subsystem']//select");

        By Add_Terms_and_condition_SubSystem_Dropdown = By.XPath("//*[@label='Subsystem']//select//option");

        By Add_Terms_and_condition_Country_Level = By.XPath("//*[@class='checkbox']//input");
        
        By Add_Terms_and_condition_Admin_Notes = By.XPath("//*[@ng-model='vm.termsAndConditions.adminNotes']");

        By Add_Terms_and_condition_Global_Level_Content = By.XPath("//*[@ng-model='vm.termsAndConditions.globalLevelContent']");

        By Save_Add_Terms_and_condition = By.XPath("//button[@bc-click='vm.save()']");

        By Terms_and_condition_Cancel = By.XPath("//*[@class='box-footer']//a");

        //SEARCH TERMS AND CONDITION

        By Search_By_Short_Code = By.XPath("//*[@ng-model='vm.filters.shortCode']");

        By Search_By_Name = By.XPath("//*[@ng-model='vm.filters.name']");

        By Search_By_Product = By.XPath("//*[@ng-model='vm.filters.product']");

        By Search_By_Product_Sub_System = By.XPath("//*[@ng-model='vm.filters.productSubSystem']");

        By Search_Grid = By.XPath("//*[@class='box-body']//table//tbody");
        

        public Terms_and_condition(IWebDriver driver)
        {

            this.driver = driver;
        
        }

        public void Add_Terms_and_condition()
        {

            Utilities.Click_On_Element(driver, Terms_and_conditions_Menu, 60);

            Utilities.Click_On_Element(driver,Terms_and_conditions_Add,60);

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Name_Input,60,"Automated");

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Short_Code,60,"123");

            Utilities.Click_On_Element(driver, Add_Terms_and_condition_Product_type, 60);

            Utilities.Customized_Drop_Down_Select(driver,Add_Terms_and_condition_Product_Dropdown,"Schools");

            Utilities.Click_On_Element(driver, Add_Terms_and_condition_SubSystem_type, 60);

            Utilities.Customized_Drop_Down_Select(driver, Add_Terms_and_condition_SubSystem_Dropdown, "B2C");

            Utilities.Click_On_Element(driver,Add_Terms_and_condition_Country_Level,60);

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Admin_Notes,60,"Automated Admin Notes updated in the Application");

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Global_Level_Content,60,"Automated global level content notes updated");

            try
            {

                Utilities.Click_On_Element(driver, Save_Add_Terms_and_condition, 60);

            }
            catch (Exception)
            {

                Utilities.Click_On_Element(driver,Terms_and_condition_Cancel,60);

            }
                         
        }

        public void Search_Terms_and_condition()
        {

            Utilities.Send_Keys(driver,Search_By_Short_Code,60,"111");

            Utilities.Send_Keys(driver,Search_By_Name, 60, "");

            Utilities.Send_Keys(driver,Search_By_Product,60,"");

            Utilities.Send_Keys(driver, Search_By_Product_Sub_System, 60, "");

            Utilities.Search_Field_Edit_Click(driver,Search_Grid,"111");
    
        }

        public void Edit_Terms_and_condition()
        {

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Name_Input,60,"Automation_Edit_Name");

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Short_Code,60,"456");

            Utilities.Click_On_Element(driver,Add_Terms_and_condition_Product_type,60);

            Utilities.Customized_Drop_Down_Select(driver, Add_Terms_and_condition_Product_Dropdown, "Schools");

            Utilities.Click_On_Element(driver,Add_Terms_and_condition_SubSystem_type,60);

            Utilities.Customized_Drop_Down_Select(driver, Add_Terms_and_condition_SubSystem_Dropdown, "B2C");

            Utilities.Click_On_Element(driver,Add_Terms_and_condition_Country_Level,60);

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Admin_Notes,60,"Edited Admin Notes field");

            Utilities.Send_Keys(driver,Add_Terms_and_condition_Global_Level_Content,60,"Edited Global Level Content field");

            try
            {

                Utilities.Click_On_Element(driver, Save_Add_Terms_and_condition, 60);

            }
            catch (Exception)
            {

                Utilities.Click_On_Element(driver, Terms_and_condition_Cancel, 60);

            }

        }

    }
}
