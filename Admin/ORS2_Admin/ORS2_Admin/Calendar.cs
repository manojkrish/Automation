using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORS2_Admin
{
    class Calendar 
    {

            By calender_Open_Click = By.XPath("html/body/div/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/input");

            By Date_Picker_Previous_button = By.XPath("html/body/div/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/div[2]/ul/li[1]/div/div/div/table/thead/tr[1]/th[1]/button");

            By Date_Picker_Next_button = By.XPath("html/body/div[1]/div[2]/ui-view/b2c-candidate-form/section/validation-form/form/div[1]/div/div[1]/b2c-candidate-details/ng-form/div/div[1]/div[1]/div[3]/div/div[1]/div/div[2]/ul/li[1]/div/div/div/table/thead/tr[1]/th[3]/button");

            By Current_Month_Year_Picker = By.XPath(".//*[@id='datepicker-1576-5995-title']");

            By Date_Table = By.XPath("//*[@class='uib-daypicker ng-scope']//tbody//tr[1]//td//button");

            By Month_Picker_Previous_button = By.XPath("//*[@class='uib-monthpicker ng-scope']//thead/tr/th[1]//button");

            By Month_Picker_Next_button = By.XPath("//*[@class='uib-monthpicker ng-scope']//thead/tr/th[3]//button");

            By Current_Year_on_Click_Month_year_Pick = By.XPath(".//*[@id='datepicker-711-8834-title']]");


            public Calendar(IWebDriver driver)
            {

                //driver = this.driver;
            
            }

            public void calendar_selct()
            {

                //Utilities.Click_On_Element(driver,calender_Open_Click,60);

                //if (Utilities.Get_text(driver, Current_Year_on_Click_Month_year_Pick, 60).Contains("1985"))
                {

                  //  Utilities.Click_On_Element(driver, Current_Year_on_Click_Month_year_Pick, 60);

                   // Utilities.Click_On_Element(driver, Current_Year_on_Click_Month_year_Pick, 60);

                    //IList<IWebElement> we = driver.FindElements(By.XPath(".//*[@class='uib-yearpicker ng-scope']//tbody/tr/td"));

                   // foreach(IWebElement Count in we)
                    {
                     //  while(Count.Text.Contains("2001"))
                       {

                       //    Count.Click();



                       }
                
                        
                    }

                 }
           
            }
                        
    }
}
