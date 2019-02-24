namespace UTSHelper.CistNure
{
    /// <summary>
    /// Статический класс, содержащий типовые запросы к серверу http://cist.nure.ua и методы для их построения.
    /// </summary>
    public static class CistRequests
    {
        /// <summary>
        /// Общая часть всех запросов.
        /// </summary>
        private const string CommonURL = "http://cist.nure.ua/ias/app/tt/";
        
        #region Набор наиболее распространенных запросов.

        /// <summary>
        /// Строка запроса для получения всех факультетов университета.
        /// </summary>
        public const string Faculties = CommonURL + "get_faculties";
        
        /// <summary>
        /// Строка запроса для получения всех кафедр факультета КИУ.
        /// </summary>
        public const string DepartmentsKIU = CommonURL + "P_API_DEPARTMENTS_JSON?p_id_faculty=114";

        /// <summary>
        /// Строка запроса для получения всех преподавателей кафедры ЭВМ.
        /// </summary>
        public const string TeachersEOM = CommonURL + "P_API_TEACHERS_JSON?p_id_department=28";

        /// <summary>
        /// Строка запроса для получения расписания ИващенкоГС.
        /// </summary>
        public const string TimetableIGS = CommonURL + "P_API_EVENTS_TEACHER_JSON?p_id_teacher=4353571";
        
        #endregion

        /// <summary>
        /// Получить кафедры заданного факультета.
        /// </summary>
        /// <param name="facultyId">Идентификатор факультета.</param>
        /// <returns>Строка запроса для получения данных о кафедрах факультета.</returns>
        public static string GetDepartments(string facultyId)
        {
            return CommonURL + "P_API_DEPARTMENTS_JSON?p_id_faculty=" + facultyId;
        }

        /// <summary>
        /// Получить кафедры заданного факультета.
        /// </summary>
        /// <param name="departmentId">Идентификатор кафедры.</param>
        /// <returns>Строка запроса для получения данных о преподавателях кафедры.</returns>
        public static string GetTeachers(string departmentId)
        {
            return CommonURL + "P_API_TEACHERS_JSON?p_id_department=" + departmentId;
        }

        /// <summary>
        /// Построение запроса для получения расписания заданного преподавателя.
        /// </summary>
        /// <param name="idTeacher">Идентификатор преподавателя.</param>
        /// <param name="timeFrom">Временные рамки расписания, Unix epoch, начало.</param>
        /// <param name="timeTo">Временные рамки расписания, Unix epoch, конец.</param>
        /// <returns>Строка запроса для получения расписания.</returns>
        public static string GetTimeSheetRequestString(string idTeacher, string timeFrom, string timeTo)
        {
            return CommonURL + "P_API_EVENTS_TEACHER_JSON?p_id_teacher=" + idTeacher + "&time_from=" + timeFrom + "&time_to=" + timeTo;
        }

        /// <summary>
        /// Построение запроса для получения CSV-расписания заданного преподавателя.
        /// </summary>
        /// <param name="idTeacher">Идентификатор преподавателя.</param>
        /// <param name="dateStart">Временные рамки расписания, дата начала.</param>
        /// <param name="dateEnd">Временные рамки расписания, дата окончания.</param>
        /// <returns>Строка запроса для получения CSV-расписания.</returns>
        public static string GetTimeSheetCsvRequestString(string idTeacher, string dateStart, string dateEnd)
        {
            return CommonURL + "WEB_IAS_TT_GNR_RASP.GEN_TEACHER_KAF_RASP?ATypeDoc=3&Aid_sotr=" + idTeacher + "&Aid_kaf=0&ADateStart=" + dateStart + "&ADateEnd=" + dateEnd + "&AMultiWorkSheet=0";
        }
    }
}
