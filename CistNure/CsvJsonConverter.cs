using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper
{
    static public class CsvJsonConverter
    {
        static public string ConvertToJson(string[] csv)
        {
            string groups = "\"groups\":[{\"name\":\"КІ-13-5\",\"id\":4460126},{\"name\":\"КІ-13-2\",\"id\":4307124},{\"name\":\"КІ-13-3\",\"id\":4307148},{\"name\":\"БІКС-13-2\",\"id\":4307160},{\"name\":\"КІ-13-4\",\"id\":4307166},{\"name\":\"БІКС-13-1\",\"id\":4307202},{\"name\":\"КІ-13-1\",\"id\":4307206},{\"name\":\"КІу-13-7\",\"id\":4308036},{\"name\":\"КІ-14-1\",\"id\":4801912},{\"name\":\"КІ-14-2\",\"id\":4801932},{\"name\":\"КІ-13-6\",\"id\":4539179},{\"name\":\"БІКС-14-2\",\"id\":4801952},{\"name\":\"КІ-14-4\",\"id\":4802000},{\"name\":\"БІКС-14-1\",\"id\":4802020},{\"name\":\"КІ-14-3\",\"id\":4802022},{\"name\":\"КІ-14-5\",\"id\":5007826},{\"name\":\"КІу-14-6\",\"id\":5007828},{\"name\":\"КІ-15-2\",\"id\":5259280},{\"name\":\"КІу-15-6\",\"id\":5451501},{\"name\":\"КІ-15-1\",\"id\":5259302},{\"name\":\"КІ-15-3\",\"id\":5259340},{\"name\":\"КІ-15-4\",\"id\":5259360},{\"name\":\"КІ-15-5\",\"id\":5259362},{\"name\":\"БІКС-15-2\",\"id\":5259370},{\"name\":\"БІКС-15-1\",\"id\":5259436},{\"name\":\"КІУКІ-16-1\",\"id\":5721651},{\"name\":\"КІУКІу-16-9\",\"id\":5721669},{\"name\":\"КІУКІ-16-6\",\"id\":5721671},{\"name\":\"КІУКІ-16-4\",\"id\":5721679},{\"name\":\"КБІКС-16-1\",\"id\":5721689},{\"name\":\"КІУКІ-16-2\",\"id\":5721697},{\"name\":\"КІ-14-7\",\"id\":5721711},{\"name\":\"КІУКІ-16-3\",\"id\":5721763},{\"name\":\"КБІКС-16-2\",\"id\":5721769},{\"name\":\"БІКСм-17-1\",\"id\":6329209},{\"name\":\"СПм-18-2\",\"id\":6963554},{\"name\":\"СПм-18-1\",\"id\":6963570},{\"name\":\"БІКСм-18-1\",\"id\":6963594},{\"name\":\"БДІРм-18-1\",\"id\":6963606},{\"name\":\"СКСм-18-1\",\"id\":6963608},{\"name\":\"КІУКІ-17-3\",\"id\":6283377},{\"name\":\"КІ-15-6\",\"id\":6283399},{\"name\":\"КІУКІ-17-1\",\"id\":6283403},{\"name\":\"КІУКІ-17-4\",\"id\":6283405},{\"name\":\"КБІКС-17-2\",\"id\":6283413},{\"name\":\"КІУКІ-17-2\",\"id\":6283429},{\"name\":\"КІУКІ-17-5\",\"id\":6283461},{\"name\":\"КБІКС-17-1\",\"id\":6283469},{\"name\":\"КІУКІу-17-9\",\"id\":6283477},{\"name\":\"КБІКС-17-3\",\"id\":6500294},{\"name\":\"КСМм-18-1\",\"id\":6963528},{\"name\":\"БДІРм-17-1\",\"id\":6290384},{\"name\":\"СПм-17-1\",\"id\":6290416},{\"name\":\"СПм-17-2\",\"id\":6290418},{\"name\":\"КСМм-17-1\",\"id\":6290426},{\"name\":\"СКСм-17-1\",\"id\":6290430},{\"name\":\"КІУКІ-18-3\",\"id\":6949642},{\"name\":\"КІУКІ-18-1\",\"id\":6949676},{\"name\":\"КІУКІ-18-7\",\"id\":6949680},{\"name\":\"КБІКС-18-1\",\"id\":6949682},{\"name\":\"КІУКІ-18-5\",\"id\":6949692},{\"name\":\"КІУКІ-18-6\",\"id\":6949710},{\"name\":\"КІУКІ-16-5\",\"id\":5924154},{\"name\":\"КІУКІ-16-7\",\"id\":5924156},{\"name\":\"КІУКІу-16-8\",\"id\":5924158},{\"name\":\"КІУКІ-17-6\",\"id\":6497234},{\"name\":\"КІ-14-1+КІИ-14-1\",\"id\":6009120},{\"name\":\"КІУКІ-17-7\",\"id\":6497245},{\"name\":\"КІУКІ-17-8\",\"id\":6497251},{\"name\":\"КІУКІу-17-10\",\"id\":6497376},{\"name\":\"КСМм-17-2\",\"id\":6497452},{\"name\":\"СКСм-17-2\",\"id\":6497466},{\"name\":\"КБІКСу-18-1\",\"id\":7191238},{\"name\":\"КІи-15-1\",\"id\":6982740},{\"name\":\"КІУКІ-18-4\",\"id\":6949742},{\"name\":\"КБІКС-18-2\",\"id\":7193372},{\"name\":\"КІУКІу-18-1\",\"id\":6949760},{\"name\":\"КБІКС-18-3\",\"id\":7194003},{\"name\":\"КІУКІ-18-2\",\"id\":6949766},{\"name\":\"КІУКІ-18-8\",\"id\":6949770},{\"name\":\"СПм-18-3\",\"id\":7202077},{\"name\":\"СКСм-18-2\",\"id\":7202079},{\"name\":\"КІУКІу-18-2\",\"id\":6949820}]";
            Dictionary<string, string> myGroups = new Dictionary<string, string>();
            myGroups.Add("КІУКІи-16-1;КІУКІ-16-1", "5721651,5966217");
            myGroups.Add("КІУКІу-17-9;КІУКІу-17-10", "6283477,6497376");
            myGroups.Add("КІУКІи-16-1;КІУКІ-16-1,2,3,4,5", "5721651,5721679,5721697,5721763,5924154,5966217");
            myGroups.Add("КІУКІ-16-1", "5721651");
            myGroups.Add("КІУКІ-16-2", "5721697");
            myGroups.Add("КІУКІ-16-3", "5721763");
            myGroups.Add("КІУКІ-16-4", "5721679");
            myGroups.Add("КІУКІ-16-5", "5924154");
            myGroups.Add("КІУКІу-17-9", "6283477");
            myGroups.Add("КІУКІу-17-10", "6497376");
            // for groups... Add for them.

            //string teachers = "";// need  calc!!!!
            const string teachersIGS = "\"teachers\":[{\"id\":4353571,\"full_name\":\"Іващенко Георгій Станіславович\",\"short_name\":\"Іващенко Г. С.\"}]";
            
            //string subjects = "";// need  calc!!!! For groups - NEED NOW!
            const string subjectsIGS = "\"subjects\": [{\"id\":1021621,\"brief\":\"ІТех\",\"title\":\"INTERNET-технологіі\",\"hours\":[{\"type\":40,\"val\":2,\"teachers\":[4353571]},{\"type\":22,\"val\":8,\"teachers\":[4353571]},{\"type\":22,\"val\":16,\"teachers\":[4353571]},{\"type\":22,\"val\":16,\"teachers\":[4353571]},{\"type\":0,\"val\":20,\"teachers\":[4353571]}]}]";
            Dictionary<string, string> mySubjects = new Dictionary<string, string>();
            mySubjects.Add("ІТех", "1021621");

            const string types = "\"types\": [{\"id\":0,\"short_name\":\"Лк\",\"full_name\":\"Лекція\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":1,\"short_name\":\"У.Лк (1)\",\"full_name\":\"Уст. Лекція (1)\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":2,\"short_name\":\"У.Лк\",\"full_name\":\"Уст. Лекція\",\"id_base\":0, \"type\":\"lecture\"},{\"id\":10,\"short_name\":\"Пз\",\"full_name\":\"Практичне заняття\",\"id_base\":10, \"type\":\"practice\"},{\"id\":12,\"short_name\":\"У.Пз\",\"full_name\":\"Уст. Практичне заняття\",\"id_base\":10, \"type\":\"practice\"},{\"id\":20,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна робота\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":21,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна ІОЦ\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":22,\"short_name\":\"Лб\",\"full_name\":\"Лабораторна кафедри\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":23,\"short_name\":\"У.Лб\",\"full_name\":\"Уст. Лабораторна ІОЦ\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":24,\"short_name\":\"У.Лб\",\"full_name\":\"Уст. Лабораторна кафедри\",\"id_base\":20, \"type\":\"laboratory\"},{\"id\":30,\"short_name\":\"Конс\",\"full_name\":\"Консультація\",\"id_base\":30, \"type\":\"consultation\"},{\"id\":40,\"short_name\":\"Зал\",\"full_name\":\"Залік\",\"id_base\":40, \"type\":\"test\"},{\"id\":41,\"short_name\":\"дзал\",\"full_name\":\"ЗалікД\",\"id_base\":40, \"type\":\"test\"},{\"id\":50,\"short_name\":\"Екз\",\"full_name\":\"Екзамен\",\"id_base\":50, \"type\":\"exam\"},{\"id\":51,\"short_name\":\"ЕкзП\",\"full_name\":\"ЕкзаменП\",\"id_base\":50, \"type\":\"exam\"},{\"id\":52,\"short_name\":\"ЕкзУ\",\"full_name\":\"ЕкзаменУ\",\"id_base\":50, \"type\":\"exam\"},{\"id\":53,\"short_name\":\"ІспКомб\",\"full_name\":\"Іспит комбінований\",\"id_base\":50, \"type\":\"exam\"},{\"id\":54,\"short_name\":\"ІспТест\",\"full_name\":\"Іспит тестовий\",\"id_base\":50, \"type\":\"exam\"},{\"id\":55,\"short_name\":\"мод\",\"full_name\":\"Модуль\",\"id_base\":50, \"type\":\"exam\"},{\"id\":60,\"short_name\":\"КП/КР\",\"full_name\":\"КП/КР\",\"id_base\":60, \"type\":\"course_work\"}]";
            Dictionary<string, string> myTypes = new Dictionary<string, string>();
            myTypes.Add("Лк", "0");
            myTypes.Add("У.Лк (1)", "1");
            myTypes.Add("У.Лк", "2");
            myTypes.Add("Пз", "10");
            myTypes.Add("У.Пз", "12");
            //myTypes.Add("Лб", "20");
            //myTypes.Add("Лб", "21");
            myTypes.Add("Лб", "22");
            //myTypes.Add("У.Лб", "23");
            myTypes.Add("У.Лб", "24");
            myTypes.Add("Конс", "30");
            myTypes.Add("Зал", "40");
            myTypes.Add("дзал", "41");
            myTypes.Add("Екз", "50");
            myTypes.Add("ЕкзП", "51");
            myTypes.Add("ЕкзУ", "52");
            myTypes.Add("ІспКомб", "53");
            myTypes.Add("ІспТест", "54");
            myTypes.Add("мод", "55");
            myTypes.Add("КП/КР", "60");


            string json = "{\"time-zone\":\"Europe/Kiev\",";

            string events = "\"events\":[";
            string[] teachEvent;
            for (int i = 1; i < csv.Length-1; i++)
            {
                string theme = csv[i].Substring(0, csv[i].IndexOf('\"',1));
                theme = theme.Replace("\"", "");
                string csvStringWithoutTheme = csv[i].Remove(0, csv[i].IndexOf('\"',1)+2);
                teachEvent = csvStringWithoutTheme.Split(',');
                for (int j = 0; j < teachEvent.Length; j++)
                {
                    teachEvent[j] = teachEvent[j].Replace("\"", "");
                }

                string[] themeElements = theme.Split(' ');
                string subjectName = themeElements[0];
                string subjectType = themeElements[1];
                string subjectRoom = themeElements[2];
                string subjectGroup = themeElements[3];

                DateTime begin = Convert.ToDateTime(teachEvent[0] + " " + teachEvent[1]);
                long beginUTC = (begin.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                long endUTC = beginUTC + 5700;

                Dictionary<string, string> pairs = new Dictionary<string, string>(8);
                pairs.Add("07:45:00", "1");
                pairs.Add("09:30:00", "2");
                pairs.Add("11:15:00", "3");
                pairs.Add("13:10:00", "4");
                pairs.Add("14:55:00", "5");
                pairs.Add("16:40:00", "6");
                pairs.Add("18:25:00", "7");
                pairs.Add("20:10:00", "8");

                string subject_id = mySubjects[subjectName];
                string type = myTypes[subjectType];
                string number_pair = pairs[teachEvent[1]];
                string group = myGroups[subjectGroup];
                events += "{ \"subject_id\":" + subject_id + "," + "\"start_time\":" + beginUTC + "," + "\"end_time\":" + endUTC + "," + "\"type\":" + type + "," + "\"number_pair\":" + number_pair + "," + "\"auditory\":" + subjectRoom + "," + "\"teachers\":" + "[]" + "," + "\"groups\":[" + group + "]}";
                events += ",";
            }
            events += "]";


            return json + events + "," + groups + "," + teachersIGS + "," + subjectsIGS + "," + types +"}";
        }
    }
}
