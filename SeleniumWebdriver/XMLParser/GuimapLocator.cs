using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    public class GuimapLocator
    {
        private string _identifier;
        private readonly Stream _stream = null;
        readonly string _fileName;

        protected string GuiMapPath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + @"\Guimaps\";

            }
        }


        public GuimapLocator(string guiMapName)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //_stream = assembly.GetManifestResourceStream("TestPages.GuiMaps." + guiMapName);
            _fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + guiMapName;

        }

        public Dictionary<string, string> GetLocatorValue(string logicalName)
        {
            return GetValue(logicalName);
        }


        public Dictionary<string, string> GetValue(string logicalName)
        {
            Dictionary<string, Guimap> guiCollection = guiCollection = GetObjectCollection(_fileName);
            return GetElementFromObjectLocator(GuiMapParser.GetInstance().GetElementValue(guiCollection, logicalName));
        }

        private static Dictionary<string, Guimap> GetObjectCollection(string fileName)
        {
            return GlobalGuiCollection.GetGuimap(fileName);
        }


        private Dictionary<string, string> GetElementFromObjectLocator(Dictionary<string, string> objectLocator)
        {

            //objectLocator = ExtractObjectLocator(objectLocator);
            return objectLocator;
        }


        private string ExtractObjectLocator(string objectLocator)
        {
            if (objectLocator.StartsWith("id"))
            {
                _identifier = objectLocator.Substring(0, 2);
                objectLocator = objectLocator.Substring(2, objectLocator.Length - 2);
            }
            else if (objectLocator.StartsWith("name"))
            {
                _identifier = objectLocator.Substring(0, 4);
                objectLocator = objectLocator.Substring(4, objectLocator.Length - 4);
            }
            else if (objectLocator.StartsWith("xpath"))
            {
                _identifier = objectLocator.Substring(0, 5);
                objectLocator = objectLocator.Substring(5, objectLocator.Length - 5);
            }
            else if (objectLocator.StartsWith("tagname"))
            {
                _identifier = objectLocator.Substring(0, 7);
                objectLocator = objectLocator.Substring(7, objectLocator.Length - 7);

            }
            else if (objectLocator.StartsWith("linktext"))
            {
                _identifier = objectLocator.Substring(0, 8);
                objectLocator = objectLocator.Substring(8, objectLocator.Length - 8);
            }

            else if (objectLocator.StartsWith("partiallinktext"))
            {
                _identifier = objectLocator.Substring(0, 15);
                objectLocator = objectLocator.Substring(15, objectLocator.Length - 15);
            }

            else if (objectLocator.StartsWith("class"))
            {
                _identifier = objectLocator.Substring(0, 5);
                objectLocator = objectLocator.Substring(5, objectLocator.Length - 5);
            }
            return objectLocator;
        }
    }
}