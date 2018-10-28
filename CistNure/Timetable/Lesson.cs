using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure.Timetable
{
    /// <summary>
    /// Описания события расписания - т.е. собственно занятия того или иного вида.
    /// </summary>
    public class Lesson
    {
        /// <summary>
        /// Название дисциплины.
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Тип занятия (лекция, лабораторная и т.д.).
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Время начала занятия.
        /// </summary>
        public DateTime DateTimeBegin { get; private set; }

        /// <summary>
        /// Время окончания занятия.
        /// </summary>
        public DateTime DateTimeEnd { get; private set; }

        /// <summary>
        /// Номер пары, на которой проводится занятие.
        /// </summary>
        public int PairNumber { get; private set; }

        /// <summary>
        /// Аудитория, в которой проводится занятие.
        /// </summary>
        public string Auditory { get; private set; }

        /// <summary>
        /// Группа, у которой проводится занятие.
        /// </summary>
        /// <remarks>В качестве группы часто указывается поток - множество групп через запятую.</remarks>
        public string Groups { get; private set; }

        /// <summary>
        /// Конструктор, создание занятия (события расписания).
        /// </summary>
        /// <param name="subject">Название дисциплины.</param>
        /// <param name="type">Тип занятия.</param>
        /// <param name="dateTimeBegin">Время начала занятия.</param>
        /// <param name="dateTimeEnd">Время окончания занятия.</param>
        /// <param name="pairNumber">Номер пары.</param>
        /// <param name="auditory">Аудитория, в которой проводится занятие.</param>
        /// <param name="groups">Группы, у которых проводится занятие.</param>
        public Lesson(string subject, string type, DateTime dateTimeBegin, DateTime dateTimeEnd, int pairNumber, string auditory, string groups)
        {
            Subject = subject;
            Type = type;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            PairNumber = pairNumber;
            Auditory = auditory;
            Groups = groups;
        }

        /// <summary>
        /// Закрытый конструктор по умолчанию.
        /// </summary>
        private Lesson()
        {
        }

        /// <summary>
        /// Строковое описание события расписания в особом - подходящем для файлов почасовки - формате.
        /// </summary>
        /// <returns>Строка, включающая в себя дату проведения, время занятия, набор групп.</returns>
        public string ToTimesheetString()
        {
            return DateTimeBegin.ToShortDateString() 
                + "\t" + Settings.PairTimeByNumber(PairNumber) 
                + ",\t" + Settings.GetAliasGroups(Groups);
        }

        /// <summary>
        /// Строковое описание события расписания в формате для списка задач.
        /// </summary>
        /// <returns>Строка вида "время_начала-время_окончания, аудитория, дисциплина, вид_работы (группа).".</returns>
        public string ToTasklistString()
        {
            string groups = Settings.GetAliasGroups(Groups);
            return Settings.PairTimeByNumber(PairNumber) + ", " 
                + Settings.GetAliasAuditory(Auditory) + ", " 
                + Settings.GetAliasSubject(Subject) + ", " 
                + Settings.GetAliasType(Type) 
                + " (" + groups + ").";
        }
    }
}
