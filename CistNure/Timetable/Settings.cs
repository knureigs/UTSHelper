using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure.Timetable
{
    static public class Settings
    {
        static private Dictionary<string, string> AliasSubject = new Dictionary<string, string>();
        static private Dictionary<string, string> AliasType = new Dictionary<string, string>();
        static private Dictionary<string, string> AliasAuditory = new Dictionary<string, string>();
        static private Dictionary<string, string> AliasGroups = new Dictionary<string, string>();

        public static void Load()
        {
            string path = Directory.GetCurrentDirectory() + "\\settings.xml";
            if (File.Exists(path))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                XmlElement root = xmlDocument.DocumentElement;
                foreach (XmlNode xnode in root.FirstChild)
                {
                    if (xnode.Name == "subject")
                    {
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            XmlNode attr = childNode.Attributes.GetNamedItem("key");
                            string key = attr.Value;
                            attr = childNode.Attributes.GetNamedItem("value");
                            string alias = attr.Value;
                            AliasSubject.Add(key, alias);
                        }
                    }
                    if (xnode.Name == "type")
                    {
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            XmlNode attr = childNode.Attributes.GetNamedItem("key");
                            string key = attr.Value;
                            attr = childNode.Attributes.GetNamedItem("value");
                            string alias = attr.Value;
                            AliasType.Add(key, alias);
                        }
                    }
                    if (xnode.Name == "groups")
                    {
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            XmlNode attr = childNode.Attributes.GetNamedItem("key");
                            string key = attr.Value;
                            attr = childNode.Attributes.GetNamedItem("value");
                            string alias = attr.Value;
                            AliasGroups.Add(key, alias);
                        }
                    }
                }
            }
        }

        public static string GetAliasSubject(string subject)
        {
            string alias = subject;
            if(AliasSubject.ContainsKey(subject))
            {
                alias = AliasSubject[subject];
            }
            return alias;
        }

        public static string GetAliasType(string type)
        {
            string alias = type;
            if (AliasType.ContainsKey(type))
            {
                alias = AliasType[type];
            }
            return alias;
        }

        public static string GetAliasGroups(string group)
        {
            string alias = group;
            if (AliasGroups.ContainsKey(group))
            {
                alias = AliasGroups[group];
            }
            return alias;
        }

        public static string GetAliasAuditory(string auditory)
        {
            string alias = auditory;

            return alias;
        }
    }
}
