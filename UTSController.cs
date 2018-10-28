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
        private UTSControl _utsControl;

        /// <summary>
        /// Работа с API сайта расписания университета.
        /// </summary>
        private CISTHandler _cistHandler;

        /// <summary>
        /// Факультеты университета. Словарь включает в себя идентификатор (строковый) и полное название.
        /// </summary>
        private Dictionary<string, string> _faculties;

        /// <summary>
        /// Кафедры выбранного факультета. Словарь включает в себя идентификатор и краткое название.
        /// </summary>
        private Dictionary<string, string> _departments;

        /// <summary>
        /// Преподаватели выбранной кафедры. Словарь включает в себя идентификатор и Фамилия И.О.
        /// </summary>
        private Dictionary<string, string> _teachers;
        
        #endregion

        #region Конструктор.

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="utsControl">Общий элемент управления системы.</param>
        public UTSController(UTSControl utsControl)
        {
            _utsControl = utsControl;
            _utsControl.UTSController = this;

            _cistHandler = new CISTHandler();
        }

        #endregion

        #region Логика.

        /// <summary>
        /// Начало работы системы.
        /// </summary>
        public void Init()
        {
            // получить факультеты университета и передать их список элементу управления для начала работы.
            _faculties = _cistHandler.GetFaculties();
            _utsControl.FillFaculties(_faculties.Select(f => f.Value).ToArray());

            _departments = new Dictionary<string, string>();
            _teachers = new Dictionary<string, string>();

            _utsControl.InitForDebag();
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
            string id = _faculties.FirstOrDefault(x => x.Value == faculty).Key;
            _departments = _cistHandler.GetDepartments(id);
            departments = _departments.Select(d => d.Value).ToArray();

            return departments;
        }

        public string[] GetTeachers(string department)
        {
            string[] teachers;
            if (_teachers.Count == 0)
            {
                _teachers = _cistHandler.GetTeachers(_departments.FirstOrDefault(x => x.Value == department).Key);
            }
            else
            {
                teachers = new string[_teachers.Count];
            }
            teachers = _teachers.Select(d => d.Value).ToArray();

            return teachers;
        }

        public Timetable GetTimetable(string teacher, DateTime begin, DateTime end)
        {
            string teacherId = _teachers.FirstOrDefault(x => x.Value == teacher).Key;
            return _cistHandler.GetTimetable(teacherId, begin, end);
        }

        internal void ClearCollections()
        {
            _departments.Clear();
            _teachers.Clear();
        }
    }
}
