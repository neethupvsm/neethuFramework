using NUnit.Framework;
using SeleniumWebdriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TestScript;
using TestScript.BasePages;

namespace TestScript.StepDefinition
{
    [Binding]


    public class LoginStepDefinition : TestBase
    {
        //CommonMethods Methods = new CommonMethods();

        Random randomNumber = new Random();
        int number;

        public LoginStepDefinition()
        {

        }

        [Given(@"I navigate to the url")]
        public void GivenINavigateToTheUrl()
        {
            driver.NavigateToUrl("http://newarkjobs2020.com");
            //driver.NavigateToUrl("https://www.google.com/");



            Thread.Sleep(9000);
            driver.click(Login.LoginLink);
            Thread.Sleep(9000);
        }

        [When(@"I enter valid username and Password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            driver.WaitForElementVisible(Login.LoginPageHeader);
            driver.SendKeys(Login.username, "testV");
            driver.SendKeys(Login.Password, "testV123!");


        }

        [Then(@"I must able to login into the home page")]
        public void ThenIMustAbleToLoginIntoTheHomePage()
        {
            driver.click(Login.Login);
        }

        [Then(@"Verify all the options are displayed correctly")]
        public void ThenVerifyAllTheOptionsAreDisplayedCorrectly()
        {

        }



    }
}