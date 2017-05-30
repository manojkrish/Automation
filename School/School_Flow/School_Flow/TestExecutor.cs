using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School_Flow
{
    [TestClass]
    public class TestExecutor
    {
        public IWebDriver driver;
        
        [TestMethod]
        public void School_Creation_Flow()
        {
            Create_Profile cp = new Create_Profile(driver);
            cp.Browser_Initilization();
            cp.Creation();
            cp.Tear_Down();
        }
        
    }
}
