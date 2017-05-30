using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoItX3Lib;
using System.Runtime;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Gimp
{
    class Organisation_Countries 
    {
        public IWebDriver driver;

        //Add Countries from the Menu

        By Organisation_Countries_Menu = By.XPath("//span[text()='Organisation countries']");

        By Organisation_Countries_Add = By.XPath("//*[@loading-container='vm.table.settings().$loading']//*[contains(text(),'Add')]");


        //Selecting Values in the Add Countries - General Tab

        By Add_Organisation_Dropdown = By.XPath("//*[@name='organisationId']");

        By Add_Organisation_Name_Select = By.XPath("//*[@name='organisationId']//option");

        By Add_Country_Name_Dropdown = By.XPath("//*[@name='countryId']");

        By Add_Country_Name_Select = By.XPath("//*[@name='countryId']//option");

        By Regions_Dropdown_Click = By.CssSelector(".btn.dropdown-toggle");

        By Regions_Select = By.XPath("//*[@ng-model='vm.organisationCountry.regionIds']//ul//li/span");

        By Payment_method_dropdown = By.XPath("html/body/div/div[2]/ui-view/organisationcountriesadd/section/validation-form/form/div[1]/div/div/ng-form/div/div[1]/div[2]/div[1]/payment-methods-chooser/div/div/button");

        By Payments_method_Select = By.XPath("//*[@ng-model='vm.organisationCountry.organisationCountryPaymentTypes']//ul//li//span");

        By Acceptable_IDs = By.XPath("//*[@ng-model='$select.search']");//By.CssSelector(".ui-select-search.input-xs.ng-pristine.ng-valid.ng-empty.ng-touched");

        By Acceptable_IDs_Dropdown = By.XPath("//*[@name='availableIds']//li//span");

        By Active_Button = By.XPath("//*[@name='active']");

        By Subsidiary_Check_Box = By.XPath("//*[@class='checkbox']//*[@name='isSubsidiary']");

        By Company_Name_Field = By.XPath("html/body/div/div[2]/ui-view/organisationcountriesadd/section/validation-form/form/div[1]/div/div/ng-form/div/div[1]/div[2]/div[3]/div/div[1]/input");

        By Google_Tag_Manager = By.XPath("//*[@name='googleTagManagerCode']");


        //Selecting Values in the IELTS Specific tab

        By IELTS_Context_Check_Box = By.XPath("//*[@ng-if='vm.allowIeltsEnabled']//*[@name='IELTSEnabled']");

        By IELTS_Specific_Tab = By.XPath("//*[@class='nav nav-tabs']//li[2]//a");

        //Default Registration Deadlines

        By For_B2C_Field = By.XPath("//*[@ng-model='vm.model.defaultB2CRegistrationDeadline']");

        By For_B2B_Field = By.XPath("//*[@ng-model='vm.model.defaultB2BRegistrationDeadline']");

        //URLs fields

        By IELTS_Web_Page = By.XPath("//*[@ng-model='vm.model.webUrl']");

        By Routing_alias = By.XPath("//*[@ng-model='vm.model.routingAlias']");

        By Direct_link = By.XPath("//*[@ng-model='vm.model.directLink']");

        By Redirect_URL = By.XPath("//*[@ng-model='vm.model.redirectUrl']");

        By Redirect_URL_Check_box = By.XPath("//*[@name='alternativeRedirect']");

        //Social Networks fields

        By Twitter = By.XPath("//*[@ng-model='vm.model.ieltsTwitterLink']");

        By Facebook = By.XPath("//*[@ng-model='vm.model.ieltsFacebookLink']");

        //Deadline Days

        By Payment_deadline = By.XPath("//*[@ng-model='vm.model.paymentDeadlineDays']");

        By Automatic_cancellation = By.XPath("//*[@ng-model='vm.model.automaticCancellationDays']");

        By Automatic_Cancellation_Checkbox = By.XPath("//*[@name='enableAutomaticCancellationIfUnpaid']");

        //Payments

        By IELTS_Payment_methods = By.XPath("html/body/div[1]/div[2]/ui-view/organisationcountriesadd/section/validation-form/form/div[1]/div/div[2]/organisation-countries-ielts-specification/ng-form/div/div/div[1]/div/div[1]/div/div[3]/fieldset[2]/payment-methods-chooser/div/div[1]/button");

        By IELTS_Payment_methods_Select = By.XPath("//*[@ng-click='vm.selectPaymentType(type)']/span");

        By Payment_methods_Proof_Required = By.XPath("//*[@ng-model='vm.organisationCountry.organisationCountryPaymentTypes']//ul//li//label");

        //Other

        By Club_subscription_question_type = By.XPath("//*[@ng-model='vm.model.clubSubscriptionQuestionTypeId']//option");

        By Candidate_photo = By.XPath("//*[@ng-model='vm.model.candidatePhotoAvailabilityId']//option");

        By Country_Specific_Information = By.XPath("//*[@ng-model='vm.model.countrySpecificInformation']");

        By Save_Button = By.XPath("//*[@bc-click='vm.save()']");



        public Organisation_Countries(IWebDriver driver)
        {

            this.driver=driver;
        
        }

        public void Add_Organisation_Countries()
        {

            Utilities.Click_On_Element(driver,Organisation_Countries_Menu,60);

            Thread.Sleep(3000);

            Utilities.Click_On_Element(driver,Organisation_Countries_Add,60);

            Thread.Sleep(3000);

        }

        public void Organisation_Countries_Add_General_Tab()
        {


            Utilities.Click_On_Element(driver,Add_Organisation_Dropdown,60);

            Utilities.Customized_Drop_Down_Select(driver, Add_Organisation_Name_Select, "Postedfromautomation2");

            Thread.Sleep(3000);

            Utilities.Click_On_Element(driver,Add_Country_Name_Dropdown,60);

            Utilities.Customized_Drop_Down_Select(driver, Add_Country_Name_Select, "Azerbaijan");

            Utilities.Click_On_Element(driver, Regions_Dropdown_Click, 60);

            //Multiple Regions select information

            string[] region = { "Americas", "East Asia", "European Union", "Middle East North Africa", "South Asia", "United Kingdom","Sub Saharan Africa","Wider Europe"};

            Utilities.Customized_Multiple_DropDown_Select(driver,Regions_Select,region,60);
            
            //Utilities.Customized_Drop_Down_Select(driver, Regions_Select, "Middle East North Africa");

            Utilities.Click_On_Element(driver, Payment_method_dropdown, 60);

            //Multiple Payment select Information

            string[] Pay = {"Cash","Manual Card","Online Card","Cheque"};

            Utilities.Customized_Multiple_DropDown_Select(driver,Payments_method_Select,Pay,60);

            //End of Mutliple Select

            //Utilities.Customized_Drop_Down_Select(driver, Payments_method_Select,"Cash");

            Utilities.Click_On_Element(driver,Acceptable_IDs,60);

            string[] ID = {"Passport","National Identity Card","Other"};

            Utilities.Customized_Multiple_DropDown_Select(driver,Acceptable_IDs_Dropdown,ID,60);

            Utilities.Send_Keys(driver,Google_Tag_Manager,60,"http://www.goolemanager.com");

            //Utilities.Click_On_Element(driver, Subsidiary, 60);

            if (!Utilities.Enabled_Asserting(driver,Company_Name_Field))

            {

                Utilities.Click_On_Element(driver,Subsidiary_Check_Box,60);
                            
            
            }

            Utilities.Send_Keys(driver,Company_Name_Field,60,"Automation_Company");
            
        }

        public void Organisation_Countries_Add_Specific_Tab()
        {


            Thread.Sleep(4000);

            try 
            {

                Utilities.Displayed_Asserting(driver, IELTS_Specific_Tab);
                                 
            }
            catch(NoSuchElementException)
            {

                Utilities.Click_On_Element(driver, IELTS_Context_Check_Box, 60);
            
            }

            if (Utilities.Enabled_Asserting(driver, IELTS_Specific_Tab))

            {
                Utilities.Click_On_Element(driver, IELTS_Specific_Tab, 60);
            }

            Utilities.Send_Keys(driver,For_B2C_Field,60,"10");

            Utilities.Send_Keys(driver,For_B2B_Field,60,"12");

            Utilities.Send_Keys(driver, IELTS_Web_Page, 60, "http://www.automation.com");

            Utilities.Send_Keys(driver, Routing_alias, 60, "http://www.routingautomation.com");

            Utilities.Send_Keys(driver,Direct_link,60,"http://www.automationdirect.com");

            if (!Utilities.Enabled_Asserting(driver, Redirect_URL))
            {

                Utilities.Click_On_Element(driver, Redirect_URL_Check_box, 60);
            
            }

            Utilities.Send_Keys(driver, Redirect_URL, 60, "http://www.redirectautomation.com");

            Utilities.Send_Keys(driver, Twitter, 60, "https://twitter.com/Automation");

            Utilities.Send_Keys(driver, Facebook, 60, "https://www.facebook.com/Automation");

            Thread.Sleep(4000);

            Utilities.Click_On_Element(driver,IELTS_Payment_methods, 60);

            String[] st1 = { "Cash", "Manual Card", "Online Card", "Cheque"};
            
            Utilities.Customized_Multiple_DropDown_Select(driver, IELTS_Payment_methods_Select, st1, 60);

            Utilities.Send_Keys(driver,Payment_deadline,60,"5");

            if (!Utilities.Enabled_Asserting(driver, Automatic_cancellation))
            {

                Utilities.Click_On_Element(driver,Automatic_Cancellation_Checkbox,60);

            }

            Utilities.Send_Keys(driver,Automatic_cancellation,60,"5");

            driver.FindElement(Redirect_URL).Clear();

            Utilities.Send_Keys(driver, Redirect_URL, 60, "http://www.redirectautomation.com");

            Utilities.Customized_Drop_Down_Select(driver, Club_subscription_question_type, "OPT OUT");

            Utilities.Customized_Drop_Down_Select(driver, Candidate_photo, "Enabled and Mandatory");

            Utilities.Send_Keys(driver,Country_Specific_Information,60,"This text is posted through automation");

            Utilities.Click_On_Element(driver,Save_Button,60);
        }

    }
}
