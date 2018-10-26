using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using UTSHelper.CistNure;
using UTSHelper.CistNure.Timetable;
using UTSHelper.CistNure.Json;

namespace UTSHelper
{
    /// <summary>
    /// Класс для работы с API сайта расписания университета, получения информации о структуре и событиях.
    /// </summary>
    public class CISTHandler
    {
        /// <summary>
        /// Получение коллекции всех факультетов университета.
        /// </summary>
        /// <returns>Словарь, в котором по строковому ключу можно получить название факультета.</returns>
        public Dictionary<string, string> GetFaculties()
        {
            // путь к сохраненным результатам запроса.
            string savedData = "SavedData/faculties.json";
            // коллекция объектов на основе JSON-ответа. Для работы нужно не все.
            string json = GetResponse(savedData, CistRequests.Faculties);
            var faculties = JsonConverter.ParseResponse<JsonObjectCISTResponseFacultyInList[]>(json, "faculties");

            // словарь, созданный на основе коллекции объектов.
            var dictionary = faculties.Select(f => new { id = f.faculty_id, name = f.faculty_name }).ToDictionary(x => x.id, x => x.name);

            return dictionary;
        }

        public Dictionary<string, string> GetDepartments(string facultyId)
        {
            // путь к сохраненным результатам запроса.
            string savedData = "SavedData/departments" + facultyId + ".json";
            // коллекция объектов на основе JSON-ответа. Для работы нужно не все.
            string json = GetResponse(savedData, CistRequests.GetDepartments(facultyId));
            var departments = JsonConverter.ParseResponse<JsonObjectCISTResponseDepartment[]>(json, "faculty", "departments");

            // словарь, созданный на основе коллекции объектов.
            var dictionary = departments.Select(d => new { id = d.id.ToString(), short_name = d.short_name }).ToDictionary(x => x.id, x => x.short_name);

            return dictionary;
        }

        public Dictionary<string, string> GetTeachers(string department)
        {
            // путь к сохраненным результатам запроса.
            string savedData = "SavedData/teachers" + department + ".json";
            // коллекция объектов на основе JSON-ответа. Для дальнейшей работы ведь нужно не все, что есть в ответе от сервера.
            string json = GetResponse(savedData, CistRequests.GetTeachers(department));
            var teachers = JsonConverter.ParseResponse<JsonObjectCISTResponseTeacher[]>(json, "department", "teachers");
            
            var dictionary = teachers.Select(t => new { id = t.id, short_name = t.short_name }).ToDictionary(x => x.id, x => x.short_name);

            return dictionary;
        }

        public Timetable GetTimetable(string teacherId, DateTime begin, DateTime end)
        {
            string json="";
            string utBegin = begin.ToUnixTimestamp().ToString();
            string utEnd = end.ToUnixTimestamp().ToString();

            //string savedData = "SavedData/timetable" + teacherId + utBegin + utEnd + ".json";
            // заглушка для проверки при неработающем ЦИСТе
            string savedData = "SavedData/timetable435357115383304001541012400.json";

            json = GetResponse(savedData, CistRequests.GetTimeSheetRequestString(teacherId, utBegin, utEnd));
                            
            // перевести на использование исключений.
            if (JsonIsError(json))
            {
                return new Timetable(new Lesson[0], new SubjectDescription[0]);
            }

            var obj = Newtonsoft.Json.Linq.JObject.Parse(json);

            JsonObjectCISTResponseTSEvent[] objEvents = JsonConverter.GetEventsFromObject(obj);
            JsonObjectCISTResponseTSGroup[] objGroups = JsonConverter.GetGroupsFromObject(obj);
            JsonObjectCISTResponseTSSubject[] objSubjects = JsonConverter.GetSubjectsFromObject(obj);
            JsonObjectCISTResponseTSType[] objTypes = JsonConverter.GetTypesFromObject(obj);

            // получаем словарь всех групп
            Dictionary<int, string> groups = objGroups.ToDictionary(x => x.id, x => x.name);

            // получаем все возможные типы занятий.
            TimetableEventTypes[] eventTypesAll = objTypes.Select(type => new TimetableEventTypes(type.id, type.id_base, type.full_name)).ToArray();
            Dictionary<int, string> eventTypesBase = eventTypesAll.Where(type => type.Id == type.IdBase).ToDictionary(x => x.Id, x => x.FullName);
            Dictionary<int, int> eventTypesToBaseTypes = eventTypesAll.ToDictionary(x => x.Id, x => x.IdBase);
            // общие перечень предметов с их описанием, включающим список видов работ по этим дисциплинам.
            SubjectDescription[] subjectsDescription = objSubjects.Select(subj => new SubjectDescription(subj.title, subj.brief,
                subj.hours.Select(h => h.type).Distinct().Select(i => eventTypesBase[eventTypesToBaseTypes[i]]).ToArray<string>())).ToArray();

            Lesson[] timetableEvents = objEvents.Select(e => new Lesson(objSubjects.First(s => s.id == e.subject_id).title,
                eventTypesBase[eventTypesToBaseTypes[e.type]],
                ((long)e.start_time).FromUnixTimestamp(),
                ((long)e.end_time).FromUnixTimestamp(), 
                e.number_pair,
                e.auditory,
                String.Concat(e.groups.Select(g => groups[g] + ", ").ToArray()))).ToArray();

            return new Timetable(timetableEvents, subjectsDescription);
        }

        private bool JsonIsError(string json)// перевести на использование исключений. это лишний метод
        {
            if (json.StartsWith("Error"))
            {
                System.Windows.Forms.MessageBox.Show("json");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Получить ответ от сервера в виде Json.
        /// </summary>
        /// <param name="savedData">Путь к возможно сохраненному результату запроса в прошлом.</param>
        /// <param name="request">Строка запроса к серверу для получения ответа в виде Json.</param>
        /// <returns>JSON-ответ от сервера.</returns>
        private string GetResponse(string savedData, string request)
        {
            string json;          

            if (File.Exists(savedData))
            {
                // если такой запрос уже выполнялся, вероятно, его данные
                // уже были сохранены и незачем опрашивать сайт снова.
                json = File.ReadAllText(savedData);
            }
            else
            {
                // иначе опрашиваем сайт и сохраняем на будущее ответ. Если он вообще пришел.
                json = SendRequest(request);
                if(!json.StartsWith("{ \"Error"))// перевести на использование исключений.
                {
                    File.WriteAllText(savedData, json);
                }
                else
                {
                    string error = JsonConverter.ParseError(json).Error;
                    return "Error:" + error;
                }
            }

            return json;            
        }

        /// <summary>
        /// Отправка запроса.
        /// </summary>
        /// <param name="request">Строка запроса.</param>
        /// <returns>Ответ сервера.</returns>
        private string SendRequest(string request)
        {
            WebRequest webRequest = WebRequest.Create(request);
            HttpWebResponse response = null;
            string responseData = "";
            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException we)
            {
                response = (HttpWebResponse)we.Response;
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:        //HTTP 200 - всё ОК
                    Stream responseStream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                    responseData = streamReader.ReadToEnd();
                    break;
                /*case HttpStatusCode.Forbidden: //HTTP 403 - доступ запрещён
                    break;
                case HttpStatusCode.NotFound:  //HTTP 404 - документ не найден
                    break;
                case HttpStatusCode.Moved:     //HTTP 301 - документ перемещён
                    break;
                case HttpStatusCode.GatewayTimeout:
                    responseData = "Error: GatewayTimeout";
                    break;*/
                default:                       //другие ошибки
                    responseData = GetJsonErrorRequestData(response.StatusCode.ToString()); // перевести на использование исключений.
                    break;
            }

            return responseData;
        }

        private string GetJsonErrorRequestData(string errorCode)
        {
            string json = "{ \"Error\": " + "\"" + errorCode + "\"}";
            return json;
        }
    }
}
