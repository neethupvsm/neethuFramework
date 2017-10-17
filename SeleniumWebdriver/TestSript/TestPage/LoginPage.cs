using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLParser;

namespace TestScript.TestPage
{
    public class LoginPage : GuimapLocator
    {
        public LoginPage() : base(@"\Guimaps\Login.xml")
        {

        }


        public Dictionary<string, string> username
        {
            get
            {
                return GetLocatorValue("username");
            }
        }

        public Dictionary<string, string> Password
        {
            get
            {
                return GetLocatorValue("Password");
            }
        }

        public Dictionary<string, string> Login
        {
            get
            {
                return GetLocatorValue("Login");
            }
        }

        public Dictionary<string, string> LoginPageHeader
        {
            get
            {
                return GetLocatorValue("LoginPageHeader");
            }
        }
        public Dictionary<string, string> LoginLink
        {
            get
            {
                return GetLocatorValue("LoginLink");
            }
        }
        public Dictionary<string, string> search
        {
            get
            {
                return GetLocatorValue("search");
            }
        }
        public Dictionary<string, string> HomeLabel
        {
            get
            {
                return GetLocatorValue("HomeLabel");
            }
        }
    }
}