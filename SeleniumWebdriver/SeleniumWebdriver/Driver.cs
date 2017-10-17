using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver
{
    public class Driver
    {
        public static IWebDriver driver = null;
        //public string download = "";
        public IWebDriver InitiateDriverInstance(String Browser)
        {
            if (Browser.ToLower().Contains("firefox"))
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.SetPreference("browser.download.folderList", 1);
                profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv,application/vnd.ms-excel,application/pdf,image/png");
                driver = new FirefoxDriver(profile);
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));
                driver.Manage().Window.Maximize();

            }
            else if (Browser.ToLower().Contains("chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--disable-extensions");
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
            }

            else if (Browser.ToLower().Contains("ie"))
            {
                driver = new InternetExplorerDriver();
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));
                driver.Manage().Window.Maximize();
            }

            return driver;
        }
        public IWebElement GetElement(Dictionary<string, string> locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            IWebElement element = null;
            switch (locator.Keys.First())
            {
                case "id":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator.Values.First())));
                    element = driver.FindElement(By.Id(locator.Values.First()));
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator.Values.First())));
                    element = driver.FindElement(By.XPath(locator.Values.First()));
                    break;
                case "name":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator.Values.First())));
                    element = driver.FindElement(By.Name(locator.Values.First()));
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator.Values.First())));
                    element = driver.FindElement(By.LinkText(locator.Values.First()));
                    break;
                case "partiallinktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator.Values.First())));
                    element = driver.FindElement(By.PartialLinkText(locator.Values.First()));
                    break;
                case "classname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator.Values.First())));
                    element = driver.FindElement(By.ClassName(locator.Values.First()));
                    break;
                case "tagname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator.Values.First())));
                    break;
            }
            return element;
        }

        public IList<IWebElement> GetListOfElement(Dictionary<string, string> locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            IList<IWebElement> element = null;
            switch (locator.Keys.First())
            {
                case "id":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator.Values.First())));
                    element = driver.FindElements(By.Id(locator.Values.First()));
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator.Values.First())));
                    element = driver.FindElements(By.XPath(locator.Values.First()));
                    break;
                case "name":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator.Values.First())));
                    element = driver.FindElements(By.Name(locator.Values.First()));
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator.Values.First())));
                    element = driver.FindElements(By.LinkText(locator.Values.First()));
                    break;
                case "partiallinktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator.Values.First())));
                    element = driver.FindElements(By.PartialLinkText(locator.Values.First()));
                    break;
                case "classname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator.Values.First())));
                    element = driver.FindElements(By.ClassName(locator.Values.First()));
                    break;
                case "tagname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator.Values.First())));
                    break;
                case "cssselector":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator.Values.First())));
                    element = driver.FindElements(By.CssSelector(locator.Values.First()));
                    break;
            }
            return element;
        }

        public IList<IWebElement> GetElements(Dictionary<string, string> locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            IList<IWebElement> element = null;
            switch (locator.Keys.First())
            {
                case "id":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator.Values.First())));
                    element = driver.FindElements(By.Id(locator.Values.First()));
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator.Values.First())));
                    element = driver.FindElements(By.XPath(locator.Values.First()));
                    break;
                case "name":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator.Values.First())));
                    element = driver.FindElements(By.Name(locator.Values.First()));
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator.Values.First())));
                    element = driver.FindElements(By.LinkText(locator.Values.First()));
                    break;
                case "partiallinktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator.Values.First())));
                    element = driver.FindElements(By.PartialLinkText(locator.Values.First()));
                    break;
                case "classname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator.Values.First())));
                    element = driver.FindElements(By.ClassName(locator.Values.First()));
                    break;
                case "tagname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator.Values.First())));
                    break;
            }
            return element;
        }

        public void SendKeys(Dictionary<string, string> locator, string input)
        {
            IWebElement element = GetElement(locator);
            element.SendKeys(input);
        }

        public void click(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            element.Click();

        }
        public void clear(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            element.Clear();
        }


        //gets the text based on the locator
        public string getText(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            return element.Text;
        }


        public void close()
        {
            driver.Close();
        }
        public void Quit()
        {
            driver.Quit();
        }

        //wait time for element to visible
        public void WaitForElementVisible(Dictionary<string, string> locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            switch (locator.Values.First())
            {
                case "id":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator.Values.First())));
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator.Values.First())));
                    break;
                case "name":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator.Values.First())));
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator.Values.First())));
                    break;
                case "partiallinktext":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator.Values.First())));
                    break;
                case "classname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator.Values.First())));
                    break;
                case "tagname":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator.Values.First())));
                    break;
                case "cssselector":
                    wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator.Values.First())));
                    break;
            }
        }

        //navigates to the particular url
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);

        }

        //navigate forward

        public void NavigateForward()
        {
            driver.Navigate().Forward();
        }

        //navigate backward
        public void NavigateBackward()
        {
            driver.Navigate().Back();
        }

        //method returns windowtitle
        public string getWindowTitle
        {
            get
            {
                return driver.Title;
            }

        }

        //selects the element based on the text from dropdown
        public void SelectByText(Dictionary<string, string> locator, string textOption)
        {
            IWebElement awebelement = GetElement(locator);
            SelectElement element = new SelectElement(awebelement);
            element.SelectByText(textOption);
        }


        //selects the element based on the index 
        public void SelectByIndex(Dictionary<string, string> locator, int index)
        {

            IWebElement awebelement = GetElement(locator);
            SelectElement element = new SelectElement(awebelement);
            element.SelectByIndex(index);
        }

        //selects the element based on the value
        public void SelectByValue(Dictionary<string, string> locator, string textValue)
        {
            IWebElement awebelement = GetElement(locator);
            SelectElement element = new SelectElement(awebelement);
            element.SelectByValue(textValue);
        }

        //moves to particular element when you right click
        public void MoveToElement(Dictionary<string, string> locator)
        {

            Actions action = new Actions(driver);
            IWebElement element = GetElement(locator);
            action.MoveToElement(element).Build().Perform();
        }

        //double clicks the particular element
        public void DoubleClick(Dictionary<string, string> locator)
        {
            Actions action = new Actions(driver);
            IWebElement element = GetElement(locator);
            action.DoubleClick(element).Build().Perform();

        }

        //used for right click
        public void ContextClick(Dictionary<string, string> locator)
        {
            Actions action = new Actions(driver);
            IWebElement element = GetElement(locator);
            action.DoubleClick(element).Build().Perform();
        }


        public void ClickAndHold(Dictionary<string, string> locator)
        {
            Actions action = new Actions(driver);
            IWebElement element = GetElement(locator);
            action.ClickAndHold(element).Build().Perform();
        }

        //method for accepting the Alerts
        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }


        //method to dismiss the alert
        public void DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        //switching between frames
        public void SwitchToFrame(int id)
        {
            driver.SwitchTo().Frame(id);
        }

        //switiching to a frame by passing the frame name
        public void SwitchToFrame(string name)
        {
            driver.SwitchTo().Frame(name);
        }


        public void SwitchToFrame(IWebElement element)
        {
            driver.SwitchTo().Frame(element);
        }

        public void Highlight(Dictionary<string, string> locator, string color = "green")
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement element = GetElement(locator);
            if (color == "green")
                js.ExecuteScript("arguments[0].style.border = '" + "4px solid rgb(0,255,0)" + "'", element);
            else
                js.ExecuteScript("arguments[0].style.border = '" + "4px solid rgb(255,0,0)" + "'", element);

        }



        public void TakeScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //ss.SaveAsFile("e:\\image.png", System.Drawing.Imaging.ImageFormat.Png);
        }


        //returns true if it is enabled
        public bool IsEnabled(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            return element.Enabled;
        }

        //return true if it is displayed
        public bool IsDisplayed(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            return element.Displayed;
        }
        public bool IsSelected(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            return element.Selected;
        }

        public void JavaScriptClick(Dictionary<string, string> locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("argument" + " " + "ts[0].click()");
            GetElement(locator);
        }

        //scrolls to a particular element selected
        public void ScrollToElement(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("argument[0].scrollIntoView(true)", element);

        }

        //scrolls top
        public void ScrollToTop(Dictionary<string, string> locator)
        {

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scroll(document.Body.scroll(Height)),0");

        }

        //scrolls bottom
        public void ScrollToBottom(Dictionary<string, string> locator)
        {

            ((IJavaScriptExecutor)driver).ExecuteScript("0,window.scroll(document.Body.scroll(Height))");
        }

        //GetText
        public string GetText(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            return element.Text;
        }
        public string GetAttribute(Dictionary<string, string> locator)
        {
            IWebElement element = GetElement(locator);
            var ele = element.GetAttribute("value");
            return ele;

        }

    }
}