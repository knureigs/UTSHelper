using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure.Timetable
{
    /// <summary>
    /// Доступ к настройкам приложения.
    /// </summary>
    public static class Settings
    {
        private static Dictionary<string, string> _aliasSubject = new Dictionary<string, string>();
        private static Dictionary<string, string> _aliasType = new Dictionary<string, string>();
        private static Dictionary<string, string> _aliasAuditory = new Dictionary<string, string>();
        private static Dictionary<string, string> _aliasGroups = new Dictionary<string, string>();
        private static Dictionary<string, string> _aliasPair = new Dictionary<string, string>();
        private static Dictionary<string, string> _aliasFacultyToFull = new Dictionary<string, string>();
        private static Dictionary<string, string> _aliasFacultyToShort = new Dictionary<string, string>();

        /// <summary>
        /// Загружает сохраненные настройки из xml.
        /// </summary>
        public static void Load()
        {
            string path = Directory.GetCurrentDirectory() + "\\settings.xml";
            if (File.Exists(path))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                XmlElement root = xmlDocument.DocumentElement; // корень файла настроек, элемент settings
                
                foreach (XmlNode childNodeSettings in root.ChildNodes)
                {
                    if (childNodeSettings.Name == "alias")
                    {
                        foreach (XmlNode childNodeSettingsAlias in childNodeSettings.ChildNodes)
                        {
                            Dictionary<string, string> aliasDictionary = new Dictionary<string, string>(0);
                            switch (childNodeSettingsAlias.Name)
                            {
                                case "subject":
                                    aliasDictionary = _aliasSubject;
                                    break;
                                case "type":
                                    aliasDictionary = _aliasType;
                                    break;
                                case "groups":
                                    aliasDictionary = _aliasGroups;
                                    break;
                                case "auditory":
                                    aliasDictionary = _aliasAuditory;
                                    break;
                                case "pair":
                                    aliasDictionary = _aliasPair;
                                    break;
                                case "facultyToFull":
                                    aliasDictionary = _aliasFacultyToFull;
                                    break;
                                case "facultyToShort":
                                    aliasDictionary = _aliasFacultyToShort;
                                    break;
                            }
                            foreach (XmlNode childNode in childNodeSettingsAlias.ChildNodes)
                            {
                                XmlNode attr = childNode.Attributes.GetNamedItem("key");
                                string key = attr.Value;
                                attr = childNode.Attributes.GetNamedItem("value");
                                string alias = attr.Value;
                                aliasDictionary.Add(key, alias);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает короткое название факультета по его полному названию.
        /// </summary>
        /// <param name="facultyFullName">Полное название факультета.</param>
        /// <returns>Короткое название факультета.</returns>
        public static string GetFacultyShortName(string facultyFullName)
        {
            string alias = facultyFullName;
            if (_aliasFacultyToShort.ContainsKey(facultyFullName))
            {
                alias = _aliasFacultyToShort[facultyFullName];
            }
            return alias;
        }

        /// <summary>
        /// Возвращает полное название факультета по его короткому названию.
        /// </summary>
        /// <param name="facultyShortName">Короткое название факультета.</param>
        /// <returns>Полное название факультета.</returns>
        public static string GetFacultyFullName(string facultyShortName)
        {
            string alias = facultyShortName;
            if (_aliasFacultyToFull.ContainsKey(facultyShortName))
            {
                alias = _aliasFacultyToFull[facultyShortName];
            }
            return alias;
        }

        /// <summary>
        /// Возвращает строку со временем проведения указанной пары.
        /// </summary>
        /// <param name="pairNumber">Номер пары, 1-8.</param>
        /// <returns></returns>
        public static string PairTimeByNumber(int pairNumber)
        {
            string alias = pairNumber.ToString();
            if (_aliasPair.ContainsKey(alias))
            {
                alias = _aliasPair[alias];
            }
            return alias;
        }

        /// <summary>
        /// Возвращает определенный в настройках псевдоним для указанной дисциплины.
        /// </summary>
        /// <param name="subject">Дисциплина, для именования которой возможно использование псевдонима.</param>
        /// <returns>Псевдоним, если он определен в настройках. Иначе - идентичное значение.</returns>
        public static string GetAliasSubject(string subject)
        {
            string alias = subject;
            if(_aliasSubject.ContainsKey(subject))
            {
                alias = _aliasSubject[subject];
            }
            return alias;
        }

        /// <summary>
        /// Возвращает определенный в настройках псевдоним для указанного типа занятия.
        /// </summary>
        /// <param name="type">Тип, для именования которого возможно использование псевдонима.</param>
        /// <returns>Псевдоним, если он определен в настройках. Иначе - идентичное значение.</returns>
        public static string GetAliasType(string type)
        {
            string alias = type;
            if (_aliasType.ContainsKey(type))
            {
                alias = _aliasType[type];
            }
            return alias;
        }

        /// <summary>
        /// Возвращает определенный в настройках псевдоним для указанной студенческой группы.
        /// </summary>
        /// <param name="group">Группа, для именования которой возможно использование псевдонима.</param>
        /// <returns>Псевдоним, если он определен в настройках. Иначе - идентичное значение.</returns>
        public static string GetAliasGroups(string group)
        {
            string alias = group;
            if (_aliasGroups.ContainsKey(group))
            {
                alias = _aliasGroups[group];
            }
            return alias;
        }

        /// <summary>
        /// Возвращает определенный в настройках псевдоним для указанной аудитории.
        /// </summary>
        /// <param name="auditory">Аудитория, для именования которой возможно использование псевдонима.</param>
        /// <returns>Псевдоним, если он определен в настройках. Иначе - идентичное значение.</returns>
        public static string GetAliasAuditory(string auditory)
        {
            string alias = auditory;
            if (_aliasAuditory.ContainsKey(auditory))
            {
                alias = _aliasAuditory[auditory];
            }
            return alias;
        }
    }
}
