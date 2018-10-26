using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UTSHelper.CistNure.Timetable;

namespace UTSHelper
{
    /// <summary>
    /// Общий контроллер для системы.
    /// </summary>
    public class UTSController
    {
        #region Свойства и переменные.

        /// <summary>
        /// Контролируемый общий элемент управления системы.
        /// </summary>
        private UTSControl m_utsControl;

        /// <summary>
        /// Работа с API сайта расписания университета.
        /// </summary>
        private CISTHandler m_cistHandler;

        /// <summary>
        /// Факультету университета. Словарь включает в себя идентификатор (строковый) и полное название.
        /// </summary>
        private Dictionary<string, string> m_faculties;

        /// <summary>
        /// Кафедры выбранного факультета. Словарь включает в себя идентификатор и краткое название.
        /// </summary>
        private Dictionary<string, string> m_departments;

        /// <summary>
        /// Преподаватели выбранной кафедры. Словарь включает в себя идентификатор и Фамилия И.О.
        /// </summary>
        private Dictionary<string, string> m_teachers;


        #endregion

        #region Конструктор.

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="utsControl">Общий элемент управления системы.</param>
        public UTSController(UTSControl utsControl)
        {
            m_utsControl = utsControl;
            m_utsControl.UTSController = this;

            m_cistHandler = new CISTHandler();

            //m_faculties = new Dictionary<int, string>();
        }

        #endregion

        #region Логика.

        /// <summary>
        /// Начало работы системы.
        /// </summary>
        public void Init()
        {
            // получить факультеты университета и передать их список элементу управления для начала работы.
            m_faculties = m_cistHandler.GetFaculties();
            m_utsControl.FillFaculties(m_faculties.Select(f => f.Value).ToArray());

            m_departments = new Dictionary<string, string>();
            m_teachers = new Dictionary<string, string>();

            m_utsControl.InitForDebag();
        }

        #endregion

        /// <summary>
        /// Получить кафедры факультета.
        /// </summary>
        /// <param name="faculty">Название факультета.</param>
        /// <returns>Массив кратких названий кафедр.</returns>
        /// <remarks>Функция кроме возврата значения, еще заполняет глобальную коллекцию кафедр текущего факультета.</remarks>
        public string[] GetDepartments(string faculty)
        {
            string[] departments;
           // if (m_departments.Count == 0)
            //{
                string id = m_faculties.FirstOrDefault(x => x.Value == faculty).Key;
                m_departments = m_cistHandler.GetDepartments(id);
            //}
            //else
            //{
            //    departments = new string[m_departments.Count];
            //}
            departments = m_departments.Select(d => d.Value).ToArray();

            return departments;
        }

        public string[] GetTeachers(string department)
        {
            string[] teachers;
            if (m_teachers.Count == 0)
            {
                m_teachers = m_cistHandler.GetTeachers(m_departments.FirstOrDefault(x => x.Value == department).Key);
            }
            else
            {
                teachers = new string[m_teachers.Count];
            }
            teachers = m_teachers.Select(d => d.Value).ToArray();

            return teachers;
        }

        public Timetable GetTimetable(string teacher, DateTime begin, DateTime end)
        {
            string teacherId = m_teachers.FirstOrDefault(x => x.Value == teacher).Key;
            return m_cistHandler.GetTimetable(teacherId, begin, end);
        }

        internal void ClearCollections()
        {
            m_departments.Clear();
            m_teachers.Clear();
        }
    }
}
