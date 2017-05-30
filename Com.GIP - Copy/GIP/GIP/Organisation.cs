using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GIP 
{
    public class Organisation : Browser_Init
    {
        By Organisation_Menu = By.XPath("//span[text()='Organisations']");

        By Organisation_Add = By.XPath("//*[@loading-container='vm.table.settings().$loading']//*[contains(text(),'Add')]");

        By Add_Organisation_Name_Input = By.XPath("//*[@ng-model='vm.organisation.name']");

        By Add_Organisation_type = By.XPath("//*[@class='box-body']//*[@ng-transclude='']/select");

        By Add_Organisation_Website = By.XPath("//*[@ng-model='vm.organisation.website']");

        By Click_Organisation_Active = By.XPath("//input[@ng-model='vm.organisation.active']");

        By Click_Organisation_Allow_Internal_User = By.XPath("//input[@ng-model='vm.organisation.allowInternalUsers']");

        By Click_Organisation_Allow_External_User = By.XPath("//input[@ng-model='vm.organisation.allowExternalUsers']");

        By Save_Add_organisation = By.XPath("//button[@bc-click='vm.save()']");

        By Upload_Image = By.XPath("//*[@class='upload-image-button']/button[@ngf-select='vm.uploadImage($file, $invalidFiles)']");

        By Add_Organisation_Search_Field = By.XPath("//*[@class='bc-search-container']//input");

        By Organisation_Table_Values = By.XPath("//organisationslist//table/tbody/tr");

        By Organisation_Already_Existing_Alert = By.XPath("//*[@ng-if='field.$error.serverResponse']");

        By Organisation_Cancel = By.XPath("//*[@class='box-footer']//a");

        public Organisation(IWebDriver driver)
        {

            this.driver = driver;
        }

        public void Add_Organisation()
        {
            Utilities.Click_On_Element(driver, Organisation_Menu, 60);

            Thread.Sleep(6000);

            Utilities.Click_On_Element(driver, Organisation_Add, 60);

            Utilities.Send_Keys(driver, Add_Organisation_Name_Input, 60, "");

            Thread.Sleep(6000);

            Utilities.Drop_Down_Select(driver, Add_Organisation_type, "");

            Utilities.Send_Keys(driver, Add_Organisation_Website, 60, "");

            Utilities.Click_On_Element(driver, Click_Organisation_Active, 60);

            Utilities.Click_On_Element(driver, Click_Organisation_Allow_Internal_User, 60);

            Utilities.Click_On_Element(driver, Click_Organisation_Allow_External_User, 60);

            //File Upload

            Utilities.Click_On_Element(driver, Upload_Image, 60);

           // Utilities.FileUpload(@"C:\Users\ManojKRanganathan\Desktop\vso test.png");

            Thread.Sleep(4000);

            Utilities.Click_On_Element(driver, Save_Add_organisation, 60);

            Thread.Sleep(4000);

            //if (Utilities.Displayed_Asserting(driver, Organisation_Already_Existing_Alert))
            //{
            //    Utilities.Click_On_Element(driver, Organisation_Cancel, 60);

            //}
            //else
            //{

            //    Utilities.Click_On_Element(driver, Save_Add_organisation, 60);

            //}
        
        
        }

        public void Edit_Organisation()
        { 
            Utilities.Click_On_Element(driver, Organisation_Menu, 60);

            Utilities.Send_Keys(driver, Add_Organisation_Search_Field, 60,"");

            Thread.Sleep(6000);

            IList<IWebElement> ls = driver.FindElements(Organisation_Table_Values);

            int i = ls.Count;

            for (int k = 1; k <= i; k++)
            {

                for (int j = 1; j <= 4; j++)
                {

                    IWebElement we = driver.FindElement(By.XPath("//organisationslist//table/tbody/tr[" + k + "]/td[" + j + "]"));

                    string st = we.Text;

                    if (st.Equals(""))
                    {

                        driver.FindElement(By.XPath("//organisationslist//table/tbody/tr[" + k + "]/td[6]//a")).Click();

                        break;
                    }

                }

            }


            Thread.Sleep(6000);

            Utilities.Clear_Field(driver, Add_Organisation_Name_Input, 60);

            Utilities.Send_Keys(driver, Add_Organisation_Name_Input, 60,"");

            Thread.Sleep(6000);

            Utilities.Drop_Down_Select(driver, Add_Organisation_type,"");

            Utilities.Clear_Field(driver, Add_Organisation_Website, 60);

            Utilities.Send_Keys(driver, Add_Organisation_Website, 60,"");

            //Utilities.Click_On_Element(driver, Click_Organisation_Active, 60);

            //Utilities.Click_On_Element(driver, Click_Organisation_Allow_Internal_User, 60);

            //Utilities.Click_On_Element(driver, Click_Organisation_Allow_External_User, 60);

            Utilities.Click_On_Element(driver, Save_Add_organisation, 60);

            Thread.Sleep(4000);

            //if (Utilities.Displayed_Asserting(driver, Organisation_Already_Existing_Alert))
            //{
            //    Utilities.Click_On_Element(driver, Organisation_Cancel, 60);

            //}        
        }
    }
}
