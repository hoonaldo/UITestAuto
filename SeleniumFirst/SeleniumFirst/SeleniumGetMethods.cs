using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{
    class SeleniumGetMethods
    {
        public static string GetText( IWebElement element)
        {
            return element.GetAttribute("value"); 

            //if (elementType == ProperType.Id)
            //    return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            //if (elementType == ProperType.Name)
            //    return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
            //else return String.Empty;
        }

        public static string GetTextDDL( IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text; 

            //if (elementType == ProperType.Id)
            //    return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            //if (elementType == ProperType.Name)
            //    return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            
            //else return String.Empty;
        }

    }
}
