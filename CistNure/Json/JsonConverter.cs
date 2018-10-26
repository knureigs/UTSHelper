using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace UTSHelper.CistNure.Json
{
    public class JsonConverter
    {
        public static JsonObjectCISTResponseTSEvent[] GetEventsFromObject(Newtonsoft.Json.Linq.JObject obj)
        {
            return JsonConvert.DeserializeObject<JsonObjectCISTResponseTSEvent[]>(obj["events"].ToString());
        }

        public static JsonObjectCISTResponseTSGroup[] GetGroupsFromObject(Newtonsoft.Json.Linq.JObject obj)
        {
            return JsonConvert.DeserializeObject<JsonObjectCISTResponseTSGroup[]>(obj["groups"].ToString());
        }

        public static JsonObjectCISTResponseTSSubject[] GetSubjectsFromObject(Newtonsoft.Json.Linq.JObject obj)
        {
            return JsonConvert.DeserializeObject<JsonObjectCISTResponseTSSubject[]>(obj["subjects"].ToString());
        }

        public static JsonObjectCISTResponseTSType[] GetTypesFromObject(Newtonsoft.Json.Linq.JObject obj)
        {
            return JsonConvert.DeserializeObject<JsonObjectCISTResponseTSType[]>(obj["types"].ToString());
        }

        /// <summary>
        /// Десериализовать Json-ответ от сервера.
        /// </summary>
        /// <typeparam name="T">Тип, в который происходит десериализация.</typeparam>
        /// <param name="json">Строка json-ответа от сервера.</param>
        /// <param name="values">Набор параметров для доступа к вложенным объектам при десериализации.</param>
        /// <returns>Объект заданного типа, полученный после десериализации.</returns>
        internal static T ParseResponse<T>(string json, params string[] values)
        {
            var obj = Newtonsoft.Json.Linq.JObject.Parse(json);

            // параметры для доступа к десериализуемым объектам json-ответа.
            string param = "";
            switch (values.Length)
            {
                case 1:
                    param = obj[values[0]].ToString(); // objFaculties["faculties"].ToString()
                    break;
                case 2:
                    param = obj[values[0]][values[1]].ToString(); // objTeachers["department"]["teachers"].ToString()
                    break;
                case 3:
                    param = obj[values[0]][values[1]][values[2]].ToString();
                    break;
            }

            return JsonConvert.DeserializeObject<T>(param);
            //return JsonDeserialize<T>(param);
        }

        public static JsonObjectError ParseError(string json)
        {
            var obj = Newtonsoft.Json.Linq.JObject.Parse(json);
            return JsonConvert.DeserializeObject<JsonObjectError>(obj.ToString());
        }



        /// <summary>
        /// Десериализация JSON-строки в объект заданного типа.
        /// </summary>
        /// <typeparam name="T">Тип, в который происходит десериализация.</typeparam>
        /// <param name="jsonObjString">Десериализуемая строка.</param>
        /// <returns>Объект указанного типа.</returns>
        /*private static T JsonDeserialize<T>(string jsonObjString)
        {
            return JsonConvert.DeserializeObject<T>(jsonObjString);
        }*/
    }
}
