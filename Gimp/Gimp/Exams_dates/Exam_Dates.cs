using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gimp
{
    class Exam_Dates
    {
        public IWebDriver driver;

        By Exam_Date_menu = By.XPath("//span[text()='Exam dates']");

        By Add_Exam_Date = By.XPath("//*[@ng-click='vm.openModal()']");

        By All_Option_Select = By.XPath("//*[@ng-model='vm.filters.examOptionId']");

        By All_Option_DropDown = By.XPath("//*[@ng-model='vm.filters.examOptionId']//option");

        By All_Formats_Select = By.XPath("//*[@ng-model='vm.filters.examFormatId']");

        By All_Formats_DropDown = By.XPath("//*[@ng-model='vm.filters.examFormatId']//option");

        By New_Exam_Date = By.Id("date");

        By Speaking_Window_From = By.Id("speakingWindowFrom");

        By Speaking_Window_To = By.Id("speakingWindowTo");

        By New_Exam_Date_Current_Month_year = By.XPath("//*[@ng-model='date']//ul//li//table//thead//tr[1]//th[2]//button");

        By New_Exam_date_Previous_button = By.XPath("//*[@ng-model='date']//ul//table//thead//tr[1]//th[1]//button");

        By New_Exam_date_Next_button = By.XPath("//*[@ng-model='date']//ul//table//thead//tr[1]//th[3]//button");

        //By New_Exam_date_Month = By.XPath("//*[@ng-model='date']//ul//li//table//tbody//tr//td");

        By New_Exam_date_Month_Selector = By.XPath("//*[@ng-model='date']//ul//li//table//tbody//tr//td//button");

        By New_Date_Select_Month_table = By.XPath("//*[@ng-model='date']//ul//li");

        By New_Date_Select_Day_table = By.XPath("//*[@ng-model='date']//ul//li");

        By General_Training = By.XPath("//*[@class='checkbox']//label//input");

        By SaveChanges = By.XPath("//*[@class='modal-footer']//button[1]");


        //Search Function Locator 

        By Click_Search_Exam = By.XPath("html/body/div/div[2]/exam-dates/section/div/div[1]/div/date-range-filter/div/div");

        By Search_Exam_From_Previous = By.XPath("//*[@ng-model='vm.rangeDateFrom']//table//thead//tr[1]//th[1]//button");

        By Search_Exam_From_Next = By.XPath("//*[@ng-model='vm.rangeDateFrom']//table//thead//tr[1]//th[3]//button");

        By Search_Exam_From_Current_Month_year = By.XPath("//*[@ng-model='vm.rangeDateFrom']//table//thead//tr[1]//th[2]//button");

        By Search_Exam_From_Select_Month_table = By.XPath("//*[@ng-model='vm.rangeDateFrom']");

        By Search_Exam_From_Select_Day_table = By.XPath("//*[@ng-model='vm.rangeDateFrom']");

        By Search_Exam_To_Previous = By.XPath("//*[@ng-model='vm.rangeDateFrom']//table//thead//tr[1]//th[1]//button");

        By Search_Exam_To_Next = By.XPath("//*[@ng-model='vm.rangeDateFrom']//table//thead//tr[1]//th[3]//button");
        
        By Search_Exam_To_Current_Month_year = By.XPath("//*[@ng-model='vm.rangeDateTo']//table//thead//tr[1]//th[2]//button");

        By Search_Exam_To_Select_Month_table = By.XPath("//*[@ng-model='vm.rangeDateTo']");

        By Search_Exam_To_Select_Day_table = By.XPath("//*[@ng-model='vm.rangeDateTo']");

        

        public Exam_Dates(IWebDriver driver)
        {

            this.driver = driver;


        }


        public void Add_Exam()
        {

            Thread.Sleep(9000);

            Utilities.Click_On_Element(driver, Exam_Date_menu, 120);

            Thread.Sleep(9000);      
        }



        public void Select_Exams_date()
        {

            Utilities.Click_On_Element(driver, Add_Exam_Date, 120);

            Utilities.Click_On_Element(driver, New_Exam_Date, 120);

            Utilities.Date_Picker(driver, New_Exam_Date_Current_Month_year, New_Exam_date_Previous_button,New_Exam_date_Next_button,New_Date_Select_Month_table,New_Date_Select_Day_table,"2019","March","21");

            Thread.Sleep(3000);

            Utilities.Click_On_Element(driver,Speaking_Window_From,60);

            Utilities.Date_Picker(driver, New_Exam_Date_Current_Month_year, New_Exam_date_Previous_button, New_Exam_date_Next_button, New_Date_Select_Month_table, New_Date_Select_Day_table, "2019", "April", "06");

            Thread.Sleep(3000);

            Utilities.Click_On_Element(driver,Speaking_Window_To,60);

            Thread.Sleep(2000);

            Utilities.Date_Picker(driver, New_Exam_Date_Current_Month_year, New_Exam_date_Previous_button, New_Exam_date_Next_button, New_Date_Select_Month_table, New_Date_Select_Day_table, "2019", "April", "27");

            Utilities.Click_On_Element(driver, General_Training, 60);

            Utilities.Click_On_Element(driver, SaveChanges, 60);


        }

        public void Search_Exam_date()
        {

            Utilities.Click_On_Element(driver,All_Option_Select,60);

            Utilities.Customized_Drop_Down_Select(driver,All_Option_DropDown,"Academic");

            Thread.Sleep(3000);

            Utilities.Click_On_Element(driver, All_Formats_Select, 60);

            Utilities.Customized_Drop_Down_Select(driver, All_Formats_DropDown, "Paper Based");

            Utilities.Click_On_Element(driver,Click_Search_Exam,60);

            Utilities.Date_Picker(driver,Search_Exam_From_Current_Month_year,Search_Exam_From_Previous,Search_Exam_From_Next,Search_Exam_From_Select_Month_table,Search_Exam_From_Select_Day_table,"2019","January","01");

            Thread.Sleep(3000);

            Utilities.Date_Picker(driver, Search_Exam_To_Current_Month_year, Search_Exam_To_Previous, Search_Exam_To_Next, Search_Exam_To_Select_Month_table, Search_Exam_To_Select_Day_table, "2019", "January", "20");
        
        }
    
    }
}

               
       
        