using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumParallelTest
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : Hooks
    {
        public FirefoxTesting() : base(BrowserType.Firefox)
        {
            // browser test
        }

        [Test]
        public void FirefoxGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");

            Driver.FindElement(By.Name("q")).SendKeys("Selenium");

            //System.Threading.Thread.Sleep(20000); 

            Driver.FindElement(By.Name("btnG")).Click();

            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true), 
                                              "The text Selenium doesn't exist"); 
        }
    }

    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting() : base(BrowserType.Chrome)
        {
        }

        [Test]
        public void ChromeGoogleTest()
        {
            Driver.Navigate().GoToUrl("http://www.google.com");

            Driver.FindElement(By.Name("q")).SendKeys("ExecuteAutomation");

            Driver.FindElement(By.Name("btnG")).Click();

            Assert.That(Driver.PageSource.Contains("ExecuteAutomation"), Is.EqualTo(true),
                                              "The text ExecuteAutomation doesn't exist");
        }
    }
}
