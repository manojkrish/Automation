using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using Microsoft.Office.Interop.Outlook;
using System.Net.Mime;
using System.Collections;
using Attachment = Microsoft.Office.Interop.Outlook.Attachment;
using Exception = System.Exception;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;


namespace ORS2_Admin
{
    [TestClass]
    public class Utilities
    {
        
        [TestMethod]
        public static void Click_On_Element(IWebDriver driver, By selector, long timeOutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));

                wait.Until(ExpectedConditions.ElementToBeClickable(selector)).Click();

            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));

                wait.Until(ExpectedConditions.ElementToBeClickable(selector)).Click();
            }
        }

        [TestMethod]
        public static void Send_Keys(IWebDriver driver, By selector, long timeOutInSeconds, String st)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));

                wait.Until(ExpectedConditions.ElementToBeClickable(selector)).SendKeys(st);
            }
            catch (ElementNotVisibleException e)
            {

                Console.WriteLine(e);

            }
        }

        [TestMethod]
        public static void SaveScreenShot(string screenshotFirstName)
        {
            var folderLocation = Environment.CurrentDirectory.Replace("Out", "\\ScreenShot\\");
            if (!Directory.Exists(folderLocation))
            {
                Directory.CreateDirectory(folderLocation);
            }
            //var screenshot = ((ITakesScreenshot)IWebDriver).GetScreenshot();
            var filename = new StringBuilder(folderLocation);
            filename.Append(screenshotFirstName);
            filename.Append(DateTime.Now.ToString("dd-mm-yyyy HH_mm_ss"));
            filename.Append(".png");
            //screenshot.SaveAsFile(filename.ToString(), System.Drawing.Imaging.ImageFormat.Png);
        }

        [TestMethod]
        public static void Customized_Drop_Down_Select(IWebDriver driver, By selector, string st)
        {

            try
            {

                IList<IWebElement> options = driver.FindElements(selector);

                //Listing the Elements in the Dropdown

                foreach (IWebElement option in options)
                {
                    String s1t = option.Text;

                    Console.WriteLine(s1t);

                    if (s1t.Equals(st))
                    {
                        option.Click();
                    }

                }

            }
            catch (StaleElementReferenceException)
            {

                IList<IWebElement> options = driver.FindElements(selector);

                ////Listing the Elements in the Dropdown

                foreach (IWebElement option in options)
                {
                    String s1t = option.Text;

                    Console.WriteLine(s1t);

                    if (s1t.Contains(st))
                    {
                        option.Click();
                    }

                }


            }

        }

        [TestMethod]
        public static void Drop_Down_Select(IWebDriver driver, By selector, string st)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            IWebElement We = driver.FindElement(selector);

            SelectElement sel = new SelectElement(driver.FindElement(selector));

            wait.Until(ExpectedConditions.ElementToBeClickable(We));

            sel.SelectByText(st);

        }

        [TestMethod]
        public static void HTML_Table(IWebDriver driver, By selector)
        {
            IList<IWebElement> ls = driver.FindElements(selector);

            foreach (IWebElement we in ls)
            {

                string st = we.Text;

                //Console.WriteLine(st);

            }

        }

        [TestMethod]
        public static void Clear_Field(IWebDriver driver, By selector, long timeOutInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));

            wait.Until(ExpectedConditions.ElementToBeClickable(selector)).Clear();
        }

        [TestMethod]
        public static Boolean Displayed_Asserting(IWebDriver driver, By selector)
        {

            Boolean value = driver.FindElement(selector).Displayed;

            return value;
        }

        [TestMethod]
        public static Boolean Enabled_Asserting(IWebDriver driver, By selector)
        {

            Boolean value = driver.FindElement(selector).Enabled;

            return value;
        }

        [TestMethod]
        public static Boolean Selected_Asserting(IWebDriver driver, By selector)
        {

            Boolean value = driver.FindElement(selector).Selected;

            return value;
        }

        [TestMethod]
        public static void FileUpload(String st)
        {

            AutoItX3 autoit = new AutoItX3();

            autoit.WinActivate("Open");

            Thread.Sleep(4000);

            autoit.Send(st);

            Thread.Sleep(4000);

            autoit.Send("{Enter}");

        }

        [TestMethod]
        public static void Customized_Multiple_DropDown_Select(IWebDriver driver, By selector, String[] st, long timeOutInSeconds)
        {
            try
            {

                IList<IWebElement> options = driver.FindElements(selector);

                //Listing the Elements in the Dropdown

                foreach (IWebElement option in options)
                {
                    String s1t = option.Text;

                    Console.WriteLine(s1t);

                    if (st.Contains(s1t))
                    {
                        option.Click();
                    }

                }

            }
            catch (StaleElementReferenceException)
            {

                IList<IWebElement> options = driver.FindElements(selector);

                ////Listing the Elements in the Dropdown

                foreach (IWebElement option in options)
                {
                    String s1t = option.Text;

                    //Console.WriteLine(s1t);

                    if (st.Contains(s1t))
                    {
                        option.Click();
                    }

                }


            }

        }

        [TestMethod]
        public static string Extents_Screenshot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            //screenshot.SaveAsFile(localpath, ImageFormat.Png);
            return localpath;
        }

        [TestMethod]
        public static void OutlookSendEmail(string[] recepientAddress, string messageSubject, string messageBody, string attachmentfile, string attachmentDisplayName)
        {

            try
            {
                // Create the Outlook application by using inline initialization.
                Application oApp = new Application();

                //Create the new message by using the simplest approach.
                MailItem oMsg = (MailItem)oApp.CreateItem(OlItemType.olMailItem);

                String[] st = recepientAddress;

                for (int i = 0; i < st.Length; i++)
                {

                    //Add a recipient.
                    // TODO: Change the following recipient where appropriate.
                    Recipient oRecip = (Recipient)oMsg.Recipients.Add(st[i]);
                    oRecip.Resolve();
                    oRecip = null;

                }

                //Set the basic properties.
                oMsg.Subject = messageSubject;
                oMsg.Body = messageBody;

                //Add an attachment.
                // TODO: change file path where appropriate
                String sSource = attachmentfile;
                String sDisplayName = attachmentDisplayName;
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)OlAttachmentType.olByValue;
                Attachment oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);

                // If you want to, display the message.
                //oMsg.Display(true);  //modal

                //Send the message.
                oMsg.Save();
                oMsg.Send();


                //Explicitly release objects.

                oAttach = null;
                oMsg = null;
                oApp = null;
            }

                // Simple error handler.
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught: "+e);
            }

            //Default return value.

        }

        [TestMethod]
        public static void WaitForElementVisible(IWebDriver driver, By selector, long timeOutInSeconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(selector));
            }
            catch (Exception)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
            }
            finally
            {
                stopwatch.Stop();
            }
        }

       [TestMethod]
        public DataTable readDataFromExcel(string strFilePath, string strQuery)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            String query = strQuery; // "SELECT * FROM [" + strSheetName + "$]";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                cmd = new OleDbCommand(query, conn);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                // Exception Msg 

            }
            finally
            {
                da.Dispose();
                conn.Close();
            }
            return dt;
        }

        [TestMethod]
        public static void Date_Picker(IWebDriver driver, By Date_Picker_Current_Month_Year, By Date_Picker_Previous, By Date_Picker_Next, By Date_Picker_Month_table, By Date_Picker_Day_table, string year, string month, string date)
        {

            Thread.Sleep(4000);

            IWebElement we = driver.FindElement(Date_Picker_Current_Month_Year);

            we.Click();

            Thread.Sleep(4000);

            // Selecting the Year in the Date Picker

            String st = driver.FindElement(Date_Picker_Current_Month_Year).Text;

            if (!st.Contains(year))
            {
                string st3 = "null";

                while (!year.Equals(st3))
                {

                    int User_Year = Int32.Parse(year);

                    try
                    {

                        int App_Year = Int32.Parse(st3);

                        if (User_Year < App_Year)
                        {

                            driver.FindElement(Date_Picker_Previous).Click();

                        }
                        else
                        {

                            driver.FindElement(Date_Picker_Next).Click();

                        }

                        st3 = driver.FindElement(Date_Picker_Current_Month_Year).Text;

                    }
                    catch (Exception)
                    {

                        st3 = driver.FindElement(Date_Picker_Current_Month_Year).Text;

                    }
                }

            }
            //End of the Year selection Option


            Thread.Sleep(3000);


            // Start of the month Selection 
            try
            {

                for (int i = 1; i <= 4; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {

                        IWebElement We = driver.FindElement(Date_Picker_Month_table).FindElement(By.XPath("//table//tbody//tr[" + i + "]//td[" + j + "]//button"));

                        String WER = We.Text;

                        Console.WriteLine(WER);

                        if (driver.FindElement(Date_Picker_Month_table).FindElement(By.XPath("//table//tbody//tr[" + i + "]//td[" + j + "]//button")).Text == month)
                        {

                            driver.FindElement(Date_Picker_Month_table).FindElement(By.XPath("//table//tbody//tr[" + i + "]//td[" + j + "]//button")).Click();

                            break;
                        }


                    }

                }
            }
            catch (NoSuchElementException)
            {

            }

            //End of the Month Selection


            Thread.Sleep(3000);


            //Start of the Date Selector
            try
            {
                for (int i = 1; i < 7; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {

                        IWebElement We1 = driver.FindElement(Date_Picker_Day_table).FindElement(By.XPath("//table//tbody//tr[" + i + "]//td[" + j + "]"));

                        String WER = We1.Text;

                        Console.WriteLine(WER);


                        if (driver.FindElement(Date_Picker_Day_table).FindElement(By.XPath("//table//tbody//tr[" + i + "]//td[" + j + "]")).Text == date)
                        {

                            driver.FindElement(Date_Picker_Day_table).FindElement(By.XPath("//table//tbody//tr[" + i + "]//td[" + j + "]//button")).Click();


                        }

                    }
                }
            }
            catch (StaleElementReferenceException)
            {



            }
            catch (NoSuchElementException)
            {


            }

            Thread.Sleep(3000);
            //End of the Date Selector

        }

        [TestMethod]
        public static void Search_Field_Edit_Click(IWebDriver driver, By Table_Grid_Value, String str)
        {

            IList<IWebElement> ls = driver.FindElements(Table_Grid_Value);

            int i = ls.Count;

            for (int k = 1; k <= i; k++)
            {

                for (int j = 1; j <= 4; j++)
                {

                    try
                    {

                        IWebElement we = driver.FindElement(Table_Grid_Value).FindElement(By.XPath("//tr[" + k + "]/td[" + j + "]"));

                        string st = we.Text;

                        if (st.Equals(str))
                        {

                            Thread.Sleep(4000);

                            driver.FindElement(Table_Grid_Value).FindElement(By.XPath("//tr[" + k + "]/td[5]//a")).Click();

                            break;
                        }

                    }
                    catch (NoSuchElementException)
                    {

                        break;

                    }
                }

            }

        }

       }
    }

