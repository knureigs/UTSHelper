using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure
{
    static public class CsvJsonConverter
    {
        /// <summary>
        /// Часть джейсон-строки, описывающая все группы факультета. Взята из рабочей части АПИ сайта расписания.
        /// </summary>
        static private string jsonStringGroups = "\"groups\":[{\"name\":\"КІ-13-5\",\"id\":4460126},{\"name\":\"КІ-13-2\",\"id\":4307124},{\"name\":\"КІ-13-3\",\"id\":4307148},{\"name\":\"БІКС-13-2\",\"id\":4307160},{\"name\":\"КІ-13-4\",\"id\":4307166},{\"name\":\"БІКС-13-1\",\"id\":4307202},{\"name\":\"КІ-13-1\",\"id\":4307206},{\"name\":\"КІу-13-7\",\"id\":4308036},{\"name\":\"КІ-14-1\",\"id\":4801912},{\"name\":\"КІ-14-2\",\"id\":4801932},{\"name\":\"КІ-13-6\",\"id\":4539179},{\"name\":\"БІКС-14-2\",\"id\":4801952},{\"name\":\"КІ-14-4\",\"id\":4802000},{\"name\":\"БІКС-14-1\",\"id\":4802020},{\"name\":\"КІ-14-3\",\"id\":4802022},{\"name\":\"КІ-14-5\",\"id\":5007826},{\"name\":\"КІу-14-6\",\"id\":5007828},{\"name\":\"КІ-15-2\",\"id\":5259280},{\"name\":\"КІу-15-6\",\"id\":5451501},{\"name\":\"КІ-15-1\",\"id\":5259302},{\"name\":\"КІ-15-3\",\"id\":5259340},{\"name\":\"КІ-15-4\",\"id\":5259360},{\"name\":\"КІ-15-5\",\"id\":5259362},{\"name\":\"БІКС-15-2\",\"id\":5259370},{\"name\":\"БІКС-15-1\",\"id\":5259436},{\"name\":\"КІУКІ-16-1\",\"id\":5721651},{\"name\":\"КІУКІу-16-9\",\"id\":5721669},{\"name\":\"КІУКІ-16-6\",\"id\":5721671},{\"name\":\"КІУКІ-16-4\",\"id\":5721679},{\"name\":\"КБІКС-16-1\",\"id\":5721689},{\"name\":\"КІУКІ-16-2\",\"id\":5721697},{\"name\":\"КІ-14-7\",\"id\":5721711},{\"name\":\"КІУКІ-16-3\",\"id\":5721763},{\"name\":\"КБІКС-16-2\",\"id\":5721769},{\"name\":\"БІКСм-17-1\",\"id\":6329209},{\"name\":\"СПм-18-2\",\"id\":6963554},{\"name\":\"СПм-18-1\",\"id\":6963570},{\"name\":\"БІКСм-18-1\",\"id\":6963594},{\"name\":\"БДІРм-18-1\",\"id\":6963606},{\"name\":\"СКСм-18-1\",\"id\":6963608},{\"name\":\"КІУКІ-17-3\",\"id\":6283377},{\"name\":\"КІ-15-6\",\"id\":6283399},{\"name\":\"КІУКІ-17-1\",\"id\":6283403},{\"name\":\"КІУКІ-17-4\",\"id\":6283405},{\"name\":\"КБІКС-17-2\",\"id\":6283413},{\"name\":\"КІУКІ-17-2\",\"id\":6283429},{\"name\":\"КІУКІ-17-5\",\"id\":6283461},{\"name\":\"КБІКС-17-1\",\"id\":6283469},{\"name\":\"КІУКІу-17-9\",\"id\":6283477},{\"name\":\"КБІКС-17-3\",\"id\":6500294},{\"name\":\"КСМм-18-1\",\"id\":6963528},{\"name\":\"БДІРм-17-1\",\"id\":6290384},{\"name\":\"СПм-17-1\",\"id\":6290416},{\"name\":\"СПм-17-2\",\"id\":6290418},{\"name\":\"КСМм-17-1\",\"id\":6290426},{\"name\":\"СКСм-17-1\",\"id\":6290430},{\"name\":\"КІУКІ-18-3\",\"id\":6949642},{\"name\":\"КІУКІ-18-1\",\"id\":6949676},{\"name\":\"КІУКІ-18-7\",\"id\":6949680},{\"name\":\"КБІКС-18-1\",\"id\":6949682},{\"name\":\"КІУКІ-18-5\",\"id\":6949692},{\"name\":\"КІУКІ-18-6\",\"id\":6949710},{\"name\":\"КІУКІ-16-5\",\"id\":5924154},{\"name\":\"КІУКІ-16-7\",\"id\":5924156},{\"name\":\"КІУКІу-16-8\",\"id\":5924158},{\"name\":\"КІУКІ-17-6\",\"id\":6497234},{\"name\":\"КІ-14-1+КІИ-14-1\",\"id\":6009120},{\"name\":\"КІУКІ-17-7\",\"id\":6497245},{\"name\":\"КІУКІ-17-8\",\"id\":6497251},{\"name\":\"КІУКІу-17-10\",\"id\":6497376},{\"name\":\"КСМм-17-2\",\"id\":6497452},{\"name\":\"СКСм-17-2\",\"id\":6497466},{\"name\":\"КБІКСу-18-1\",\"id\":7191238},{\"name\":\"КІи-15-1\",\"id\":6982740},{\"name\":\"КІУКІ-18-4\",\"id\":6949742},{\"name\":\"КБІКС-18-2\",\"id\":7193372},{\"name\":\"КІУКІу-18-1\",\"id\":6949760},{\"name\":\"КБІКС-18-3\",\"id\":7194003},{\"name\":\"КІУКІ-18-2\",\"id\":6949766},{\"name\":\"КІУКІ-18-8\",\"id\":6949770},{\"name\":\"СПм-18-3\",\"id\":7202077},{\"name\":\"СКСм-18-2\",\"id\":7202079},{\"name\":\"КІУКІу-18-2\",\"id\":6949820}]";

        /// <summary>
        /// Часть джейсон-строки, описывающая все типы занятий. Взята из старых джейсонов, типы не меняются.
        /// </summary>
        static private string jsonStringTypes = "\"types\": [{\"id\":0,\"short_name\":\"Лк\",\"full_name\":\"Лекція\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":1,\"short_name\":\"У.Лк (1)\",\"full_name\":\"Уст. Лекція (1)\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":2,\"short_name\":\"У.Лк\",\"full_name\":\"Уст. Лекція\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":10,\"short_name\":\"Пз\",\"full_name\":\"Практичне заняття\",\"id_base\":10, \"type\":\"practice\"},{\"id\":12,\"short_name\":\"У.Пз\",\"full_name\":\"Уст. Практичне заняття\",\"id_base\":10, \"type\":\"practice\"},{\"id\":20,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна робота\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":21,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна ІОЦ\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":22,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна кафедри\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":23,\"short_name\":\"У.Лб\",\"full_name\":\"Уст. Лабораторна ІОЦ\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":24,\"short_name\":\"У.Лб\",\"full_name\":\"Уст. Лабораторна кафедри\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":30,\"short_name\":\"Конс\",\"full_name\":\"Консультація\",\"id_base\":30, \"type\":\"consultation\"},{\"id\":40,\"short_name\":\"Зал\",\"full_name\":\"Залік\",\"id_base\":40, \"type\":\"test\"},{\"id\":41,\"short_name\":\"дзал\",\"full_name\":\"ЗалікД\",\"id_base\":40, \"type\":\"test\"},{\"id\":50,\"short_name\":\"Екз\",\"full_name\":\"Екзамен\",\"id_base\":50, \"type\":\"exam\"},{\"id\":51,\"short_name\":\"ЕкзП\",\"full_name\":\"ЕкзаменП\",\"id_base\":50, \"type\":\"exam\"},{\"id\":52,\"short_name\":\"ЕкзУ\",\"full_name\":\"ЕкзаменУ\",\"id_base\":50, \"type\":\"exam\"},{\"id\":53,\"short_name\":\"ІспКомб\",\"full_name\":\"Іспит комбінований\",\"id_base\":50, \"type\":\"exam\"},{\"id\":54,\"short_name\":\"ІспТест\",\"full_name\":\"Іспит тестовий\",\"id_base\":50, \"type\":\"exam\"},{\"id\":55,\"short_name\":\"мод\",\"full_name\":\"Модуль\",\"id_base\":50, \"type\":\"exam\"},{\"id\":60,\"short_name\":\"КП/КР\",\"full_name\":\"КП/КР\",\"id_base\":60, \"type\":\"course_work\"}]";

        /// <summary>
        /// Словари для получения идентификаторов.
        /// </summary>
        static private Dictionary<string, string> idGroups, idSubjects, idTypes, timePairs;

        static public string ConvertCsvToJson(string responseString)
        {
            PrepareDictionaries();
            string[] csv = GetCorrectCsvArray(responseString);
            string events = GetEventJsonString(csv);

            string teachers = "\"teachers\":[]";
            // Не стал заморачиваться - данные о преподавателях не использовались при формировании данных о занятиях, событиях расписания.
            // Оставил для соответствия нынешнему формату.
            //const string teachersIGS = "\"teachers\":[{ \"id\":4353571,\"full_name\":\"Іващенко Георгій Станіславович\",\"short_name\":\"Іващенко Г. С.\"}]";

            string subjects = GetSubjectsJsonString();
            //const string subjectsIGS = "\"subjects\": [{\"id\":1021621,\"brief\":\"ІТех\",\"title\":\"INTERNET-технологіі\",\"hours\":[{\"type\":40,\"val\":2,\"teachers\":[4353571]},{\"type\":22,\"val\":8,\"teachers\":[4353571]},{\"type\":22,\"val\":16,\"teachers\":[4353571]},{\"type\":22,\"val\":16,\"teachers\":[4353571]},{\"type\":0,\"val\":20,\"teachers\":[4353571]}]}]";

            return "{\"time-zone\":\"Europe/Kiev\"," + events + "," + jsonStringGroups + "," + teachers + "," + subjects + "," + jsonStringTypes + "}";
        }

        private static string GetSubjectsJsonString()
        {
            string jsonStringSubjects = "\"subjects\":[";
            foreach (var subject in idSubjects)
            {
                jsonStringSubjects += "{\"id\":" + subject.Value + ",\"brief\":\"" + subject.Key + "\",\"title\":\"" + subject.Key + "\",\"hours\":[]},";
            }
            jsonStringSubjects = jsonStringSubjects.Remove(jsonStringSubjects.Length - 1, 1);
            jsonStringSubjects += "]";

            return jsonStringSubjects;
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
                string type = idTypes[subjectType];
                string number_pair = timePairs[subjectBeginTime];

                //if (!idGroups.Keys.Contains(subjectGroup))
                //{
                //    idGroups.Add(subjectGroup, rand.Next().ToString());
                //}
                //string group = idGroups[subjectGroup];
                //events += "{ \"subject_id\":" + subject_id + "," + "\"start_time\":" + beginUTC + "," + "\"end_time\":" + endUTC + "," + "\"type\":" + type + "," + "\"number_pair\":" + number_pair + "," + "\"auditory\":" + subjectRoom + "," + "\"teachers\":" + "[]" + "," + "\"groups\":[" + group + "]}";
                jsonStringEvents += "{ \"subject_id\":" + subject_id + "," + "\"start_time\":" + beginUTC + "," + "\"end_time\":" + endUTC + "," + "\"type\":" + type + "," + "\"number_pair\":" + number_pair + "," + "\"auditory\":" + subjectRoom + "," + "\"teachers\":" + "[]" + "," + "\"groups\":[]}";


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

            string subjectRoom = GetCorrectRoomName(themeElements[2]);
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

        /// <summary>
        /// Обработка (с искажением) номеров аудиторий - которые далеко не всегда являются номерами.
        /// </summary>
        /// <param name="room">Название.</param>
        /// <remarks>Набор костылей. Нормально решается изменением требуемого формата для номера аудитории при парсинге джейсона.</remarks>
        /// <returns></returns>
        private static string GetCorrectRoomName(string room)
        {
            string subjectRoom = room.Trim();
            if (subjectRoom.Contains(','))
            {
                string[] rooms = subjectRoom.Split(',');
                subjectRoom = GetCorrectRoomName(rooms[0]) + GetCorrectRoomName(rooms[1]);// номер аудитории с "and" не проходит.
            }

            if (subjectRoom.EndsWith("*Soft"))
            {
                subjectRoom = subjectRoom.Remove(subjectRoom.Length - 5, 5);
            }

            // костыль из-за странных проблем с 34з. Именно она не принималась - может, что-то из символов не то, чем кажется.
            if (subjectRoom.StartsWith("34"))
                subjectRoom = "34";

            if (subjectRoom.EndsWith("аз") || subjectRoom.EndsWith("иб"))
            {
                subjectRoom = subjectRoom.Remove(subjectRoom.Length - 2, 2);
            }
            if (subjectRoom.EndsWith("з") || subjectRoom.EndsWith("и") || subjectRoom.EndsWith("а") || subjectRoom.EndsWith("б") || subjectRoom.EndsWith("в") || subjectRoom.EndsWith("е") || subjectRoom.EndsWith("к"))
            {
                subjectRoom = subjectRoom.Remove(subjectRoom.Length - 1, 1);
            }

            // общий костыль - специфических аудиторий много, поэтому все, что остались "нечисловыми", делаем несуществующими. 
            // Львиная доля ошибок при разборе CSV всплывала именно из-за аудиторий.
            if (!Int32.TryParse(subjectRoom, out int res))
            {
                subjectRoom = "228";
            }
            #region spec. rooms.
            /*Акт.зал
             каф.СІ
             спорт
             спорт1
             спорт2
             ФІЛІЯ
             ФІЛІЯ_1
             ___0
             ___1
             __1
             113.1и
             113.2и
             151 - 2
             151 - 3
             151 - 4
             156 - 1
             160 - 1
             160 - 2
             162 - 1
             162 - 2
             162 - 3
             165 - 1
             165 - 2
             165 - 3
             165 - 5
             165 - 6
             166вц
             167вц
             326філія
             346_філія
             55 / 1з*/
            #endregion

            return subjectRoom;
        }

        private static void PrepareDictionaries()
        {
            // Подготовка словаря для поиска идентификаторов групп по их названиям. Часть данных указал по имеющимся. 
            // Вообще словарь можно формировать весь, на основе глобально заданной строки, описывающей этот джейсон-объект. 
            // Но это не решит проблему с идентификаторами потоков (много особых случаев, не стал возиться), потому костыль. 
            idGroups = new Dictionary<string, string>
            {
                { "КІУКІи-16-1;КІУКІ-16-1", "5721651,5966217" },
                { "КІУКІу-17-9;КІУКІу-17-10", "6283477,6497376" },
                { "КІУКІи-16-1;КІУКІ-16-1,2,3,4,5", "5721651,5721679,5721697,5721763,5924154,5966217" },
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
                { "ІТех", "1021621" }
            };

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