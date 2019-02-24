using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure
{
    static public class CsvJsonConverter
    {
        /// <summary>
        /// Часть джейсон-строки, описывающая все типы занятий. Взята из старых джейсонов, типы не меняются.
        /// </summary>
        static private string jsonStringTypes = "\"types\": [{\"id\":0,\"short_name\":\"Лк\",\"full_name\":\"Лекція\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":1,\"short_name\":\"У.Лк (1)\",\"full_name\":\"Уст. Лекція (1)\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":2,\"short_name\":\"У.Лк\",\"full_name\":\"Уст. Лекція\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":10,\"short_name\":\"Пз\",\"full_name\":\"Практичне заняття\",\"id_base\":10, \"type\":\"practice\"},{\"id\":12,\"short_name\":\"У.Пз\",\"full_name\":\"Уст. Практичне заняття\",\"id_base\":10, \"type\":\"practice\"},{\"id\":20,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна робота\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":21,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна ІОЦ\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":22,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна кафедри\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":23,\"short_name\":\"У.Лб\",\"full_name\":\"Уст. Лабораторна ІОЦ\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":24,\"short_name\":\"У.Лб\",\"full_name\":\"Уст. Лабораторна кафедри\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":30,\"short_name\":\"Конс\",\"full_name\":\"Консультація\",\"id_base\":30, \"type\":\"consultation\"},{\"id\":40,\"short_name\":\"Зал\",\"full_name\":\"Залік\",\"id_base\":40, \"type\":\"test\"},{\"id\":41,\"short_name\":\"дзал\",\"full_name\":\"ЗалікД\",\"id_base\":40, \"type\":\"test\"},{\"id\":50,\"short_name\":\"Екз\",\"full_name\":\"Екзамен\",\"id_base\":50, \"type\":\"exam\"},{\"id\":51,\"short_name\":\"ЕкзП\",\"full_name\":\"ЕкзаменП\",\"id_base\":50, \"type\":\"exam\"},{\"id\":52,\"short_name\":\"ЕкзУ\",\"full_name\":\"ЕкзаменУ\",\"id_base\":50, \"type\":\"exam\"},{\"id\":53,\"short_name\":\"ІспКомб\",\"full_name\":\"Іспит комбінований\",\"id_base\":50, \"type\":\"exam\"},{\"id\":54,\"short_name\":\"ІспТест\",\"full_name\":\"Іспит тестовий\",\"id_base\":50, \"type\":\"exam\"},{\"id\":55,\"short_name\":\"мод\",\"full_name\":\"Модуль\",\"id_base\":50, \"type\":\"exam\"},{\"id\":60,\"short_name\":\"КП/КР\",\"full_name\":\"КП/КР\",\"id_base\":60, \"type\":\"course_work\"}]";

        /// <summary>
        /// Словари для получения идентификаторов.
        /// </summary>
        static private Dictionary<string, string> idGroups, idSubjects, idTypes, timePairs;
        static private Dictionary<string, List<string>> subjectsHours; 

        static public string ConvertCsvToJson(string responseString)
        {
            PrepareDictionaries();
            string[] csv = GetCorrectCsvArray(responseString);
            string events = GetEventJsonString(csv);

            string groups = GetGroupsJsonString();

            string teachers = "\"teachers\":[]";
            // Не стал заморачиваться - данные о преподавателях не использовались при формировании данных о занятиях, событиях расписания.
            // Оставил для соответствия нынешнему формату.
            //const string teachersIGS = "\"teachers\":[{ \"id\":4353571,\"full_name\":\"Іващенко Георгій Станіславович\",\"short_name\":\"Іващенко Г. С.\"}]";

            string subjects = GetSubjectsJsonString();
            
            return "{\"time-zone\":\"Europe/Kiev\"," + events + "," + groups + "," + teachers + "," + subjects + "," + jsonStringTypes + "}";
        }

        private static string GetGroupsJsonString()
        {
            string jsonStringGroups = "\"groups\":[";
            foreach (var group in idGroups)
            {
                jsonStringGroups += "{\"name\":\"" + group.Key + "\",\"id\":" + group.Value + "},";
            }
            jsonStringGroups = jsonStringGroups.Remove(jsonStringGroups.Length - 1, 1);
            jsonStringGroups += "]";

            return jsonStringGroups;
        }

        private static string GetSubjectsJsonString()
        {
            string jsonStringSubjects = "\"subjects\":[";
            foreach (var subject in idSubjects)
            {
                jsonStringSubjects += "{\"id\":" + subject.Value + ",\"brief\":\"" + subject.Key + "\",\"title\":\"" + subject.Key + "\"," + GetHoursJsonString(subject.Key) + "},";
            }
            jsonStringSubjects = jsonStringSubjects.Remove(jsonStringSubjects.Length - 1, 1);
            jsonStringSubjects += "]";

            return jsonStringSubjects;
        }

        private static string GetHoursJsonString(string key)
        {
            string jsonStringHours = "\"hours\":[";
            foreach (var type in subjectsHours[key])
            {
                jsonStringHours += "{ \"type\":" + type + ",\"val\":0,\"teachers\":[]},";
            }
            jsonStringHours = jsonStringHours.Remove(jsonStringHours.Length - 1, 1);
            jsonStringHours += "]";

            return jsonStringHours;
        }

        /// <summary>
        /// Получить корректный csv, разделенный по строкам и отсортированный.
        /// </summary>
        /// <param name="responseString"></param>
        /// <remarks>Таблица в расписании некорректно работает, если события идут не подряд.</remarks>
        /// <returns></returns>
        private static string[] GetCorrectCsvArray(string responseString)
        {
            string[] csv = responseString.Split('\r');
            SortedList<DateTime, string> events = new SortedList<DateTime, string>();
            for (int i = 1; i < csv.Length - 1; i++)
            {
                string csvStringWithoutTheme = csv[i].Remove(0, csv[i].IndexOf('\"', 1) + 2);
                string[] csvStringElements = csvStringWithoutTheme.Split(',');
                for (int j = 0; j < csvStringElements.Length; j++)
                {
                    csvStringElements[j] = csvStringElements[j].Replace("\"", "");
                }
                DateTime begin = Convert.ToDateTime(csvStringElements[0] + " " + csvStringElements[1]);
                events.Add(begin, csv[i]);
            }
            return events.Values.ToArray();
        }

        /// <summary>
        /// Формирование элемента джейсон-строки, описывающего набор событий расписания - разнообразных учебных занятий.
        /// Используются данных CSV построчно.
        /// </summary>
        /// <param name="csv">Содержимое CSV-файла без мусора.</param>
        /// <returns></returns>
        private static string GetEventJsonString(string[] csv)
        {
            Random rand = new Random(0);
            string jsonStringEvents = "\"events\":[";
            string[] eventProperties;
            for (int i = 0; i < csv.Length; i++)
            {
                eventProperties = GetEventProperties(csv[i]);
                string subjectName = eventProperties[0];
                string subjectType = eventProperties[1];
                string subjectRoom = eventProperties[2];
                string subjectGroup = eventProperties[3];
                string subjectBeginDate = eventProperties[4];
                string subjectBeginTime = eventProperties[5];

                DateTime begin = Convert.ToDateTime(subjectBeginDate + " " + subjectBeginTime);
                long beginUTC = (begin.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                long endUTC = beginUTC + 5700;

                if (!idSubjects.Keys.Contains(subjectName))
                {
                    idSubjects.Add(subjectName, rand.Next().ToString());
                }
                string subject_id = idSubjects[subjectName];

                // если такого предмета раньше не встречали - а внчале так и будет - то надо его добавить в набор описаний дисциплин.
                if (!subjectsHours.Keys.Contains(subjectName))
                {
                    subjectsHours.Add(subjectName, new List<string>());
                }

                string type = idTypes[subjectType];
                // для данного предмета, в его описании, могло не быть указано этого типа работы. Надо добавить тогда.
                if (!subjectsHours[subjectName].Contains(type))
                {
                    subjectsHours[subjectName].Add(type);
                }

                string number_pair = timePairs[subjectBeginTime];

                if (!idGroups.Keys.Contains(subjectGroup))
                {
                    idGroups.Add(subjectGroup, rand.Next().ToString());
                }
                string group = idGroups[subjectGroup];
                jsonStringEvents += "{ \"subject_id\":" + subject_id + "," + "\"start_time\":" + beginUTC + "," + "\"end_time\":" + endUTC + "," + "\"type\":" + type + "," + "\"number_pair\":" + number_pair + "," + "\"auditory\":\"" + subjectRoom + "\"," + "\"teachers\":" + "[]" + "," + "\"groups\":[" + group + "]}";
                
                if (i < csv.Length - 1)
                {
                    jsonStringEvents += ",";
                }
            }
            jsonStringEvents += "]";

            return jsonStringEvents;
        }

        private static string[] GetEventProperties(string csvString)
        {
            List<string> eventProperties = new List<string>();

            // отделяем "тему" от остальной (почти все остальное - нам не нужно)
            string theme = csvString.Substring(0, csvString.IndexOf('\"', 1)).Replace("\"", "");

            //костыль для предмета с пробелом в названии
            if (theme.StartsWith("*Soft skills"))
            {
                theme = theme.Remove(theme.IndexOf(" "), 1);
            }

            string[] themeElements = theme.Split(' ');
            if (themeElements.Length == 5)
            {
                themeElements[2] += themeElements[3];
                themeElements[3] = themeElements[4];
            }
            eventProperties.Add(themeElements[0]);//name
            eventProperties.Add(themeElements[1]);//type

            string subjectRoom = themeElements[2];
            eventProperties.Add(subjectRoom);

            if (themeElements.Length >= 4)
            {
                eventProperties.Add(themeElements[3]);//group
            }
            else
            {
                eventProperties.Add("Students"); //группы иногда может не быть вообще указано.
            }

            string csvStringWithoutTheme = csvString.Remove(0, csvString.IndexOf('\"', 1) + 2);
            string[] csvStringWithoutThemeElements = csvStringWithoutTheme.Split(',');
            for (int i = 0; i < csvStringWithoutThemeElements.Length; i++)
            {
                eventProperties.Add(csvStringWithoutThemeElements[i].Replace("\"", ""));
            }

            return eventProperties.ToArray();
        }

        private static void PrepareDictionaries()
        {
            // Подготовка словаря для поиска идентификаторов групп по их названиям. Часть данных указал по имеющимся. 
            // Вообще словарь можно формировать весь, на основе глобально заданной строки, описывающей этот джейсон-объект. 
            // Но это не решит проблему с идентификаторами потоков (много особых случаев, не стал возиться), потому костыль. 
            idGroups = new Dictionary<string, string>
            {
                //{ "КІУКІи-16-1;КІУКІ-16-1", "5721651,5966217" },
                //{ "КІУКІу-17-9;КІУКІу-17-10", "6283477,6497376" },
                //{ "КІУКІи-16-1;КІУКІ-16-1,2,3,4,5", "5721651,5721679,5721697,5721763,5924154,5966217" },
                { "КІУКІ-16-1", "5721651" },
                { "КІУКІ-16-2", "5721697" },
                { "КІУКІ-16-3", "5721763" },
                { "КІУКІ-16-4", "5721679" },
                { "КІУКІ-16-5", "5924154" },
                { "КІУКІу-17-9", "6283477" },
                { "КІУКІу-17-10", "6497376" }
            };

            idSubjects = new Dictionary<string, string>
            {
                //{ "ІТех", "1021621" }
            };

            subjectsHours = new Dictionary<string, List<string>>();

            idTypes = new Dictionary<string, string>
            {
                { "Лк", "0" },
                { "У.Лк (1)", "1" },
                { "У.Лк", "2" },
                { "Пз", "10" },
                { "У.Пз", "12" },
                //idTypes.Add("Лб", "20");
                //idTypes.Add("Лб", "21");
                { "Лб", "22" },
                //myTypes.Add("У.Лб", "23");
                { "У.Лб", "24" },
                { "Конс", "30" },
                { "Зал", "40" },
                { "дзал", "41" },
                { "Екз", "50" },
                { "ЕкзП", "51" },
                { "ЕкзУ", "52" },
                { "ІспКомб", "53" },
                { "ІспТест", "54" },
                { "мод", "55" },
                { "КП/КР", "60" }
            };

            timePairs = new Dictionary<string, string>(8)
            {
                { "07:45:00", "1" },
                { "09:30:00", "2" },
                { "11:15:00", "3" },
                { "13:10:00", "4" },
                { "14:55:00", "5" },
                { "16:40:00", "6" },
                { "18:25:00", "7" },
                { "20:10:00", "8" }
            };
        }
    }
}