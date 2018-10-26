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

        public TimetableEventTypes(int id, int idBase, string fullName)
        {
            Id = id;
            IdBase = idBase;
            FullName = fullName;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
