using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE; 

namespace SeleniumFirst
{
    [TestFixture]
    [Parallelizable]
    class Program : Hooks 
    {
        //public Program() : base(BrowserType.IE) { }
        //public Program() : base(BrowserType.Firefox) { }
        public Program() : base(BrowserType.Chrome)  { }
        static void Main(string[] args)
        {

        }

        [SetUp]
        public void Initialize()
        {
            // create the reference for our browser

            //IWebDriver driver = new ChromeDriver();

            //PropertiesCollection.driver = new ChromeDriver();

            ////// Navigate to google page
            ////            PropertiesCollection.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html");

            //Driver.Navigate().GoToUrl("file:///C:/Users/Hoon/Documents/Hoon/Selenium/simple.html");

            Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            LogWriter.LogWrt("Test Initialized"); 
        }

        [Test]
        public void testTable()
        {
            //Driver = new FirefoxDriver();

            //Driver.Navigate().GoToUrl("file:///C:/Users/Hoon/Documents/Hoon/Selenium/complicateTable.html");

            TablePage page = new TablePage();

            // Read Table

            Utilities.ReadTable(page.table);

            // get the cell value from the table
            string cc = Utilities.ReadCell("Age", 1);

            Console.WriteLine("age = " + cc);

            // Delete 
            Utilities.PerformActionOnCell("5", "Firstname", "Jill", "Edit");

            Utilities.PerformActionOnCell("Option", "Firstname", "Jill");
            Utilities.PerformActionOnCell("Option", "Lastname", "Jackson");
            Utilities.PerformActionOnCell("Option", "Age", "80");

            Console.WriteLine("testTable");
            LogWriter.LogWrt("testTable"); 
        }

        [Test]
        public void execTest()
        {
            ExcelLib.PopulateInCollection(@"C:\Users\Hoon\Documents\Hoon\Selenium\data.xlsx");

            //Login to application
            LoginPageObject pageLogin = new LoginPageObject();

            int iRow = 2; 

            EAPageObject pageEA= pageLogin.Login(ExcelLib.ReadData(iRow,"UserName"), ExcelLib.ReadData(iRow,"Password"));

            pageEA.FillUserForm(ExcelLib.ReadData(iRow, "Initial"), ExcelLib.ReadData(iRow, "MiddleName"),
                                ExcelLib.ReadData(iRow, "FirstName"));


            //// Initialize the pabe by calling its reference
            //EAPageObject page = new EAPageObject();

            //page.txtInitial.SendKeys("test automation");

            //page.btnSave.Click(); 

            Console.WriteLine("execTest");
            LogWriter.LogWrt("execTest"); 
        }

        [Test]
        public void NextTest()
        {
            Console.WriteLine("NextTest");
        }

        [TearDown]
        public void cleanup()
        {
            Driver.Close(); 
            Console.WriteLine("cleanup");
            LogWriter.LogWrt("End of Test"); 
        }
    }
}
