using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE; 
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumFirst
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }

    [TestFixture]
    public class Hooks : Base
    {
        private BrowserType _browserType;
        public Hooks(BrowserType browser)
        {
            _browserType = browser;
        }


        [SetUp]
        public void InitializeTest()
        {
            // Local
            ChooseDriverInstance(_browserType);

            // Seleniumgrid in Docker container

            //ChooseWebDriver(_browserType); 
        }
        /// <summary>
        /// CHOOSE remote webdriver
        /// </summary>
        /// <param name="browserType"></param>
        public void ChooseWebDriver(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                DesiredCapabilities cap = DesiredCapabilities.Chrome();
                cap.SetCapability("version", "");
                cap.SetCapability("platform", "LINUX");
                Driver = new RemoteWebDriver(new Uri("http://localhost:4446/wd/hub"), cap);
            }
            if (browserType == BrowserType.Firefox)
            {
                DesiredCapabilities cap = DesiredCapabilities.Firefox();
                cap.SetCapability("version", "");
                cap.SetCapability("platform", "LINUX");
                Driver = new RemoteWebDriver(new Uri("http://localhost:4446/wd/hub"), cap);
            }
            if (browserType == BrowserType.IE)
            {
                DesiredCapabilities cap = DesiredCapabilities.InternetExplorer();
                cap.SetCapability("version", "");
                cap.SetCapability("platform", "LINUX");
                Driver = new RemoteWebDriver(new Uri("http://localhost:4446/wd/hub"), cap);
            }

        }
        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
                Driver = new ChromeDriver();
            if (browserType == BrowserType.Firefox)
                Driver = new FirefoxDriver();
            if (browserType == BrowserType.IE)
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                Driver = new InternetExplorerDriver(options);
            }
        }
    }
}
