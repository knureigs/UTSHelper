using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure.Timetable
{
    /// <summary>
    /// Описание типа занятия.
    /// </summary>
    public class TimetableEventTypes
    {
        /// <summary>
        /// Идентификатор типа.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Идентификатор базового типа для текущего.
        /// </summary>
        public int IdBase { get; private set; }

        /// <summary>
        /// Полное название типа занятия.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Конструктор, создание события расписания.
        /// </summary>
        /// <param name="id">Идентификатор типа.</param>
        /// <param name="idBase">Идентификатор базового типа для текущего.</param>
        /// <param name="fullName">Полное название типа занятия.</param>
        public TimetableEventTypes(int id, int idBase, string fullName)
        {
            Id = id;
            IdBase = idBase;
            FullName = fullName;
        }

        /// <summary>
        /// Закрытый конструктор по умолчанию.
        /// </summary>
        private TimetableEventTypes()
        {
        }

        /// <summary>
        /// Строковое описание типа занятия, его полное название.
        /// </summary>
        /// <returns>Полное название типа занятия.</returns>
        public override string ToString()
        {
            return FullName;
        }
    }
}
