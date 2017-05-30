using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GIP
{
    class Keyword_Test:Browser_Init
    {

        public static void Keyword(IWebDriver driver, string xlPath, string sheetName)
        {
            var totalRow = ExcelReaderHelper.GetTotalRows(xlPath, sheetName);
            
            for (var i = 2; i < totalRow; i++)
            {
                var action = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                var webEle = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 4);
                string st = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 5);

                if ((webEle == string.Empty) && (action == string.Empty))
                    break;

                if (webEle == string.Empty)
                    continue;

                By locator = By.XPath(webEle);

                Console.WriteLine("Action {0}, WebElement {1}, Locator {2} ", action, webEle, locator);

                switch (action)
                {

                    case "SendKeys":
                        {
                            Thread.Sleep(2000);
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            Utilities.Clear_Field(driver, locator, 60);
                            Utilities.Send_Keys(driver, locator, 60, st);
                        }
                        break;
                    
                    case "Click":
                        {
                            Thread.Sleep(2000);
                            Utilities.Click_On_Element(driver,locator,120);

                        }
                        break;

                    case "MultiSelect":
                        {
                            Thread.Sleep(2000);                            
                            string value = st;

                            string[] tokens = st.Split(',');

                            string[] region;                

                            foreach (string token in tokens)
                            {
                                region = new string[] {token};
                                Utilities.Customized_Multiple_DropDown_Select(driver, locator, region, 60);
                            }
                                                                                                           
                            
                        }
                        break;

                    case "Select":
                        {
                            Thread.Sleep(2000);
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            Utilities.Customized_Drop_Down_Select(driver,locator,st);     
                        }
                        break;

                    case "Sleep":
                        {
                            Thread.Sleep(2000);
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            Thread.Sleep(Convert.ToInt32(text));
                        }
                        break;

                    case "SelectFile":
                        {
                            Thread.Sleep(2000);
                            var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            Utilities.FileUpload(st);
                            
                        }
                        break;
                    case "DisplayedAssert":
                        {
                            Thread.Sleep(2000);
                            //var text = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);

                            Utilities.Displayed_Asserting(driver,locator);
                                                 
                        }

                        break;

                    case "Search_Edit":
                        {
                            Thread.Sleep(2000);

                            Utilities.Search_Field_Edit_Click(driver,locator,st);

                         }
                        break;
                   
                }
                
            }
        }

        public void Keys(string Xlpath1)
        {


            string Xlpath = Xlpath1;
            var path = @Xlpath;
            var sheets = ExcelReaderHelper.GetAllSheetName(path);
            

            foreach (var sheetName in sheets)
            {

                Console.WriteLine(sheetName);


                Keyword(driver, path, sheetName);

             }
        
        }

    }
}
