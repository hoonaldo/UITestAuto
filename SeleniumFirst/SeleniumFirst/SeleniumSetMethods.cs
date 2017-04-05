using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    public static class SeleniumSetMethods
    {
        /// <summary>
        /// Extended method for enteringtext in the control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value); 
        }
        /// <summary>
        /// Click button , checkbox, options
        /// </summary>
        /// <param name="element"></param>
        // 
        public static void Clicks(this IWebElement element)
        {
            element.Click(); 

            //if (elementType == ProperType.Id)
            //    PropertiesCollection.driver.FindElement(By.Id(element)).Click();
            //if (elementType == ProperType.Name)
            //    PropertiesCollection.driver.FindElement(By.Name(element)).Click();
        }
        /// <summary>
        /// selecting a dropdown control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        // 
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value); 

            //if (elementType == ProperType.Id)
            //    new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            //if (elementType == ProperType.Name)
            //    new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
        }
    }
}
