using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestScript
{
    [Binding]
    public class Hooks : TestBase
    {

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver.InitiateDriverInstance("chrome");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}