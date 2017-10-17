using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebdriver;

namespace TestScript.BasePages
{
    public class CommonMethods : TestBase
    {
        //public CommonMethods()
        //{

        //}
        public int RandomNumber()
        {
            Random randomnumber = new Random();
            return randomnumber.Next(100, 10000);
        }

        public string GetNumber()
        {
            DateTime time = DateTime.Now;
            var val = time.ToString("mmssff");
            return val;
        }

        public void validateDropDownMenu(string text, Dictionary<string, string> locator)
        {
            var options = driver.GetElements(locator);
            List<string> optionText = new List<string>();
            foreach (var item in options)
            {
                optionText.Add(item.Text);
            }
            if (!optionText.Contains(text))
            {
                Assert.Fail(text + "not found in the dropdown");
            }
        }

        public int VerifyClearText(Dictionary<string, string> locator)
        {
            var clear = driver.getText(locator);
            return clear.Length;
        }

        //public void verifyDataIsAdded(string text,Dictionary<string, string> locator)
        //{

        //    var textEle = driver.GetElements(locator);
        //    List<string> addData = new List<string>();
        //    foreach (var item in textEle)
        //    {
        //        addData.Add(item.textEle);
        //    }

        //}
        public string GetEstTimings()
        {
            var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var targetTime = TimeZoneInfo.ConvertTime(DateTime.Now, est);
            var time = targetTime.ToString("hh:mm:tt");
            return time;
        }
        public string GetEstDate()
        {
            var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var targetTime = TimeZoneInfo.ConvertTime(DateTime.Now, est);
            var date = targetTime.ToString("MM/dd/yyyy");
            return date;
        }


        //AssertDate
        public void AssertDate(Dictionary<string, string> locator)
        {
            IWebElement element = driver.GetElement(locator);
            Assert.AreEqual(DateTime.Now.ToString("MM/dd/yyyy"), element.Text, "Created date not displayed correctly");
        }

        //Field Empty
        public bool VerifyFieldEmpty(Dictionary<string, string> locator)
        {
            IWebElement element = driver.GetElement(locator);
            if (element.Text == null)
            {
                return true;
            }
            return false;
        }

        //Madatory field message
        public string[] VerifyMandatoryFieldEmptyMessages(Dictionary<string, string> locator)
        {
            IList<IWebElement> elementList;
            elementList = driver.GetListOfElement(locator);
            string[] elementValues = new String[elementList.Count];
            int i = 0;
            foreach (IWebElement element in elementList)
            {
                elementValues[i++] = element.Text;
            }

            return elementValues;

        }

        //Compare Text

        public bool CompareText(Dictionary<string, string> locator, string TobeComparedWith)
        {
            IWebElement element = driver.GetElement(locator);

            if (element.Equals(TobeComparedWith))
            {
                return true;
            }
            return false;
        }


        //AssertText
        public void AssertText(string text, Dictionary<string, string> locator)
        {
            IWebElement element = driver.GetElement(locator);
            Assert.AreEqual(text, element.Text, text + " displayed correctly");
        }
    }
}