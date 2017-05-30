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

namespace ORS2_Admin
{
    class Keyword_Test
    {
       // public IWebDriver driver;

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
                            if (!Utilities.Displayed_Asserting(driver, locator))
                            {

                                Console.WriteLine("*******************Not displayed****************");
                            
                            }
                                                 
                        }

                        break;

                    case "DOB":
                        {
                            Thread.Sleep(2000);

                            // Values of the Excel sheet information
                            var Date_Picker_Current_Month_year = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 3);
                            var Date_Picker_Previous = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 4);
                            var Date_Picker_Next = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 5);
                            var Date_Picker_month = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 6);
                            var Date_Picker_day = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 7);
                            var Date_Picker_Year_String = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 8);
                            var Date_Picker_Year_Month = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 9);
                            var Date_Picker_Year_Day = ExcelReaderHelper.GetCellValue(xlPath, sheetName, i, 10);


                            //By Values
                            By DPCMY = By.XPath(Date_Picker_Current_Month_year);
                            By DPP = By.XPath(Date_Picker_Previous);
                            By DPN = By.XPath(Date_Picker_Next);
                            By DPM = By.XPath(Date_Picker_month);
                            By DPD = By.XPath(Date_Picker_day);

                            
                            Utilities.Date_Picker(driver,DPCMY,DPP,DPN,DPM,DPD,Date_Picker_Year_String,Date_Picker_Year_Month,Date_Picker_Year_Day);
                        }

                        break;

                   // case "Assert_Save":
                     //   {
                            //Thread.Sleep(2000);

                            //try
                            //{

                            //    IWebElement we = driver.FindElement(locator);

                            //    string str = we.Text;

                            //    if (str.Contains("successfully saved"))
                            //    {

                            //        FileStream stream = new FileStream("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Location_Test_Data.xlsx", FileMode.OpenOrCreate);
                            //        ExcelWriteHelper writer = new ExcelWriteHelper(stream);
                            //        writer.BeginWrite();
                            //        writer.WriteCell(1, 6, "Pass");
                            //        writer.EndWrite();
                            //        stream.Close();

                            //    }
                            //    else
                            //    {

                            //        FileStream stream = new FileStream("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Location_Test_Data.xlsx", FileMode.OpenOrCreate);
                            //        ExcelWriteHelper writer = new ExcelWriteHelper(stream);
                            //        writer.BeginWrite();
                            //        writer.WriteCell(1, 6, "Fail");
                            //        writer.EndWrite();
                            //        stream.Close();


                            //    }
                            //}
                            //catch (NoSuchElementException)
                            //{

                            //    FileStream stream = new FileStream("C:\\Automation\\Com.GIP - Copy\\GIP\\GIP\\Location_Test_Data.xlsx", FileMode.OpenOrCreate);
                            //    ExcelWriteHelper writer = new ExcelWriteHelper(stream);
                            //    writer.BeginWrite();
                            //    writer.WriteCell(1, 6, "Fail");
                            //    writer.EndWrite();
                            //    stream.Close();
                            
                            
                        //    }
                                         
                      //   }
                  //      break;
                   
                }
                
            }
        }

        public void Keys(string Xlpath1,IWebDriver driver)
        {


            string Xlpath = Xlpath1;
            var path = @Xlpath;
            var sheets = ExcelReaderHelper.GetAllSheetName(path);
            

            foreach (var sheetName in sheets)
            {
                Keyword(driver, path, sheetName);
             }
        
        }

    }
}
