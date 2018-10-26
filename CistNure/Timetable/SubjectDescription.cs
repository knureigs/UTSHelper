using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure.Timetable
{
    /// <summary>
    /// Класс, описывающий одну учебную дисциплину - варианты 
    /// ее названия и список возможных видов занятий.
    /// </summary>
    public class SubjectDescription
    {
        /// <summary>
        /// Полное название дисциплины.
        /// </summary>
        public readonly string NameFull;

        /// <summary>
        /// Сокращенное название дисциплины.
        /// </summary>
        public readonly string NameShort;

        /// <summary>
        /// Типы занятий по данной дисциплине.
        /// </summary>
        public readonly string[] Types;

        /// <summary>
        /// Конструктор, создание описания дисциплины.
        /// </summary>
        /// <param name="nameFull">Полное название дисциплины.</param>
        /// <param name="nameShort">Сокращенное название дисциплины.</param>
        /// <param name="types">Типы занятий по данной дисциплине.</param>
        public SubjectDescription(string nameFull, string nameShort, string[] types)
        {
            NameFull = nameFull;
            NameShort = nameShort;
            Types = types;
        }

        /// <summary>
        /// Закрытый конструктор по умолчанию.
        /// </summary>
        private SubjectDescription()
        {
        }

        /// <summary>
        /// Строковое описание дисциплины, ее полное название.
        /// </summary>
        /// <returns>Полное название дисциплиниы.</returns>
        public override string ToString()
        {
            return NameFull;
        }
    }

    //public enum TimetableEventTypes
    //{
    //}
}
