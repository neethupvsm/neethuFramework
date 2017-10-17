using SeleniumWebdriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TestData;
using TestScript.StepDefinition;
using TestScript.TestPage;

namespace TestScript
{
    public class TestBase
    {
        private Driver _driver;
        public Driver driver
        {
            get
            {
                if (null == _driver)
                {
                    _driver = new Driver();
                }
                return _driver;
            }
        }

        private LoginPage login;
        public LoginPage Login
        {
            get
            {
                if (null == login)
                {
                    login = new LoginPage();
                }
                return login;
            }
        }


    }
}