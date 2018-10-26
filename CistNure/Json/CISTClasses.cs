using Newtonsoft.Json;

namespace UTSHelper.CistNure
{
    #region Классы, необходимые при получении расписания.

    /// <summary>
    /// Событие - собственно элемент расписания, занятие, одна какая-то пара.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTSEvent
    {
        /// <summary>
        /// Идентификатор учебной дисциплины, по нему можно определить, по какому предмету пара.
        /// </summary>
        [JsonProperty("subject_id")]
        public int subject_id { get; set; }

        /// <summary>
        /// Дата и время начала занятия в UnixTimestamp-формате.
        /// </summary>
        [JsonProperty("start_time")]
        public int start_time { get; set; }

        /// <summary>
        /// Дата и время окончания занятия в UnixTimestamp-формате.
        /// </summary>
        [JsonProperty("end_time")]
        public int end_time { get; set; }

        /// <summary>
        /// Идентификатор типа занятия, по нему можно определить, 
        /// что это - лабораторная, лекция, практическое и т.д.
        /// </summary>
        [JsonProperty("type")]
        public int type { get; set; }

        /// <summary>
        /// Номер пары - от 1 до 8.
        /// </summary>
        [JsonProperty("number_pair")]
        public int number_pair { get; set; }

        /// <summary>
        /// Аудитория, в которой проходит занятие.
        /// </summary>
        [JsonProperty("auditory")]
        public string auditory { get; set; }

        /// <summary>
        /// Набор идентификаторов преподавателей, ведущих данное занятие.
        /// </summary>
        [JsonProperty("teachers")]
        public int[] teachers { get; set; }

        /// <summary>
        /// Набор идентификаторов групп студентов, у которых идет данное занятие.
        /// </summary>
        [JsonProperty("groups")]
        public int[] groups { get; set; }
    }

    /// <summary>
    /// Класс, описывающий группу студентов при формировании расписания.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTSGroup
    {
        /// <summary>
        /// Идентификатор группы.
        /// </summary>
        [JsonProperty("id")]
        public int id { get; set; }

        /// <summary>
        /// Название группы.
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }
    }

    /// <summary>
    /// Класс, описывающий преподавателя при формировании расписания.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTSTeacher
    {
        /// <summary>
        /// Идентификатор преподавателя.
        /// </summary>
        [JsonProperty("id")]
        public int id { get; set; }

        /// <summary>
        /// Полное ФИО преподавателя, на украинском языке.
        /// </summary>
        /// <remarks>Не всегда по факту оказывается таковым.</remarks>
        [JsonProperty("full_name")]
        public string full_name { get; set; }

        /// <summary>
        /// Фамилия и инициалы преподавателя, на украинском языке.
        /// </summary>
        [JsonProperty("short_name")]
        public string short_name { get; set; }
    }

    /// <summary>
    /// Класс, описывающий учебную дисциплину, при формировании расписания.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTSSubject
    {
        /// <summary>
        /// Идентификатор учебной дисциплины.
        /// </summary>
        [JsonProperty("id")]
        public int id { get; set; }

        /// <summary>
        /// Сокращенное название учебной дисциплины.
        /// </summary>
        [JsonProperty("brief")]
        public string brief { get; set; }

        /// <summary>
        /// Полное название учебной дисциплины.
        /// </summary>
        [JsonProperty("title")]
        public string title { get; set; }

        /// <summary>
        /// ??? Описание учебной дисциплины.
        /// </summary>
        [JsonProperty("hours")]
        public JsonObjectCISTResponseTSHour[] hours { get; set; }
    }

    /// <summary>
    /// Класс, описывающий ведение учебной дисциплины, при формировании расписания.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTSHour
    {
        /// <summary>
        /// Идентификатор типа занятия, по нему можно определить, 
        /// что это - лабораторная, лекция, практическое и т.д.
        /// </summary>
        [JsonProperty("type")]
        public int type { get; set; }

        /// <summary>
        /// ??? Количество часов учебной дисциплины.
        /// </summary>
        [JsonProperty("val")]
        public int val { get; set; }

        /// <summary>
        /// Набор идентификаторов преподавателей, ведущих данное занятие.
        /// </summary>
        [JsonProperty("teachers")]
        public int[] teachers { get; set; }
    }

    /// <summary>
    /// Класс, описывающий тип занятия, при формировании расписания.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTSType
    {
        /// <summary>
        /// Идентификатор типа.
        /// </summary>
        [JsonProperty("id")]
        public int id { get; set; }

        /// <summary>
        /// Сокращенное название типа занятия. Так оно приводится в сетке расписания.
        /// </summary>
        [JsonProperty("short_name")]
        public string short_name { get; set; }

        /// <summary>
        /// Полное название типа занятия, так оно в расшифровке под сеткой расписания.
        /// </summary>
        [JsonProperty("full_name")]
        public string full_name { get; set; }

        /// <summary>
        /// Базовый идентификатор типа. 
        /// Например, есть "Лекция" и "Установочная лекция", но и то, и другое относится к базовому типу "Лекция".
        /// </summary>
        [JsonProperty("id_base")]
        public int id_base { get; set; }

        /// <summary>
        /// Название типа занятия.
        /// </summary>
        [JsonProperty("type")]
        public string type { get; set; }
    }

    #endregion

    /// <summary>
    /// Класс, соответствующий факультету при получении их общего списка.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseFacultyInList
    {
        [JsonProperty("faculty_name")]
        public string faculty_name { get; set; }
        [JsonProperty("faculty_id")]
        public string faculty_id { get; set; }
        [JsonProperty("date_start")]
        public string date_start { get; set; }// not error
        [JsonProperty("date_end")]
        public string date_end { get; set; }// not error
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseFaculty
    {
        [JsonProperty("short_name")]
        public string short_name { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
        [JsonProperty("departments")]
        public JsonObjectCISTResponseDepartment[] departments { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseDepartment
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("short_name")]
        public string short_name { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectCISTResponseTeacher
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("short_name")]
        public string short_name { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonObjectError
    {
        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}