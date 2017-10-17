using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace XMLParser
{
    public class GlobalGuiCollection
    {
        private static Dictionary<string, Dictionary<string, Guimap>> _globalPageCollection;
        public GlobalGuiCollection()
        {

        }
        public static Dictionary<string, Dictionary<string, Guimap>> GlobalPageCollection
        {
            get
            {
                if (null == _globalPageCollection)
                {
                    _globalPageCollection = new Dictionary<string, Dictionary<string, Guimap>>();
                }
                return _globalPageCollection;
            }
        }

        public static Dictionary<string, Guimap> GetGuimap(string fileName)
        {
            string originalFilePath = fileName;
            Dictionary<string, Dictionary<string, Guimap>> collection = null;
            //string filename = Path.GetFileName(filepath);
            fileName = fileName.Substring(0, fileName.Length - 4);
            collection = GlobalPageCollection;
            if (collection != null && collection.ContainsKey(originalFilePath))
            {
                collection = _globalPageCollection;
                collection[originalFilePath].FirstOrDefault().Value.LastUsedTime = DateTime.Now;
            }
            else
            {
                AddNewGuiMap(originalFilePath);
            }
            // QueueCleanup();
            return collection[originalFilePath];
        }

        private static void AddNewGuiMap(string fileName)
        {
            lock (_globalPageCollection)
            {
                GlobalPageCollection.Add(fileName, GuiMapParser.GetInstance().LoadGuiMap(fileName));
            }
        }

        private static void QueueCleanup()
        {
            ThreadPool.QueueUserWorkItem(Cleanup);
        }

        private static void Cleanup(object value)
        {
            Dictionary<string, Dictionary<string, Guimap>> temp = _globalPageCollection;
            lock (_globalPageCollection)
            {
                if (_globalPageCollection != null && _globalPageCollection.Count > 0)
                {
                    foreach (KeyValuePair<string, Dictionary<string, Guimap>> guiMap in _globalPageCollection)
                    {
                        if (((TimeSpan)(DateTime.Now - guiMap.Value.Values.FirstOrDefault().LastUsedTime)).Minutes > 5)
                        {
                            temp.Remove(guiMap.Key);
                        }
                    }
                }

                _globalPageCollection = temp;
            }
        }
    }
}