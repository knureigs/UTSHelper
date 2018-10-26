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
                }
            }
        }

        public static string GetAliasSubject(string subject)
        {
            string alias = subject;
            switch (subject)
            {
                case "INTERNET-технологіі":
                    alias = "ИТех";
                    break;
            }
            return alias;
        }

        public static string GetAliasType(string type)
        {
            string alias = type;
            switch (type)
            {
                case "Лабораторна робота":
                    alias = "лабораторная работа №0";
                    break;
                case "Лекція":
                    alias = "лекция №0";
                    break;
            }
            return alias;
        }

        public static string GetAliasGroups(string group)
        {
            string alias = group;
            switch (group)
            {
                case "КІУКІ - 16 - 1, КІУКІ - 16 - 4, КІУКІ - 16 - 2, КІУКІ - 16 - 3, КІУКІ - 16 - 5, КІУКІи - 16 - 1, ":
                    alias = "КИУКИи-16-1; КИУКИ-16-1, 2, 3, 4, 5";
                    break;
                case "КІУКІ-16-1, КІУКІ-16-4, КІУКІ-16-2, КІУКІ-16-3, КІУКІ-16-5, КІУКІи-16-1, ":
                    alias = "КИУКИи-16-1; КИУКИ-16-1, 2, 3, 4, 5";
                    break;
                case "КІУКІу-17-9, КІУКІу-17-10, ":
                    alias = "КИУКИу-17-9, 10";
                    break;
                case "КІУКІу-17-9, ":
                    alias = "КИУКИу-17-9";
                    break;
                case "КІУКІу-17-10, ":
                    alias = "КИУКИу-17-10";
                    break;
                case "КІУКІ-16-5, ":
                    alias = "КИУКИ-16-5";
                    break;
                case "КІУКІ-16-4, ":
                    alias = "КИУКИ-16-4";
                    break;
                case "КІУКІ-16-3, ":
                    alias = "КИУКИ-16-3";
                    break;
                case "КІУКІ-16-2, ":
                    alias = "КИУКИ-16-2";
                    break;
                case "КІУКІ-16-1, КІУКІи-16-1, ":
                    alias = "КИУКИ-16-1, КИУКИи-16-1";
                    break;
            }
            return alias;
        }

        public static string GetAliasAuditory(string auditory)
        {
            string alias = auditory;
            //switch (auditory)
            //{
            //    case "INTERNET-технологіі":
            //        alias = "ИТех";
            //        break;
            //}
            return alias;
        }
    }
}
