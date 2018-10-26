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
        /// Группы, у которых проводится занятие.
        /// </summary>
        public string Groups { get; private set; }

        /// <summary>
        /// Конструктор, создание занятия (события расписания).
        /// </summary>
        /// <param name="subject">Название дисциплины.</param>
        /// <param name="type">Тип занятия.</param>
        /// <param name="dateTimeBegin">Время начала занятия.</param>
        /// <param name="dateTimeEnd">Время окончания занятия.</param>
        /// <param name="pairNumber">Номер пары.</param>
        /// <param name="groups">Группы, у которых проводится занятие.</param>
        public Lesson(string subject, string type, DateTime dateTimeBegin, DateTime dateTimeEnd, int pairNumber, string groups)
        {
            Subject = subject;
            Type = type;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            PairNumber = pairNumber;
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
        public override string ToString()
        {
            return DateTimeBegin.ToShortDateString() + "\t" + PairTimeByNumber(PairNumber) + ",\t" + Groups;
        }
        
        public string ToTaskListString()
        {
            string groups = GetGroupsAlias(Groups);
            return PairTimeByNumber(PairNumber) + ", " + 229 + ", " + GetSubjectAlias(Subject) + ", " + GetTypeAlias(Type) + " (" + groups + ").";
        }

        private string GetSubjectAlias(string subject)
        {
            string alias = subject;
            switch(subject)
            {
                case "INTERNET-технологіі":
                    alias = "ИТех";
                    break;
            }
            return alias;
        }

        private string GetTypeAlias(string type)
        {
            string alias = type;
            switch (type)
            {
                case "Лабораторна робота":
                    alias = "лабораторная работа №0";
                    break;
                case "Лекція":
                    alias = "лекция №0";
                    break;
            }
            return alias;
        }

        private string GetGroupsAlias(string group)
        {
            string alias = group;
            switch (group)
            {
                case "КІУКІ - 16 - 1, КІУКІ - 16 - 4, КІУКІ - 16 - 2, КІУКІ - 16 - 3, КІУКІ - 16 - 5, КІУКІи - 16 - 1, ":
                    alias = "КИУКИи-16-1; КИУКИ-16-1, 2, 3, 4, 5";
                    break;
                case "КІУКІ-16-1, КІУКІ-16-4, КІУКІ-16-2, КІУКІ-16-3, КІУКІ-16-5, КІУКІи-16-1, ":
                    alias = "КИУКИи-16-1; КИУКИ-16-1, 2, 3, 4, 5";
                    break;
                case "КІУКІу-17-9, КІУКІу-17-10, ":
                    alias = "КИУКИу-17-9, 10";
                    break;
                case "КІУКІу-17-9, ":
                    alias = "КИУКИу-17-9";
                    break;
                case "КІУКІу-17-10, ":
                    alias = "КИУКИу-17-10";
                    break;
                case "КІУКІ-16-5, ":
                    alias = "КИУКИ-16-5";
                    break;
                case "КІУКІ-16-4, ":
                    alias = "КИУКИ-16-4";
                    break;
                case "КІУКІ-16-3, ":
                    alias = "КИУКИ-16-3";
                    break;
                case "КІУКІ-16-2, ":
                    alias = "КИУКИ-16-2";
                    break;
                case "КІУКІ-16-1, КІУКІи-16-1, ":
                    alias = "КИУКИ-16-1, КИУКИи-16-1";
                    break;
            }
            return alias;
        }

        private string PairTimeByNumber(int pairNumber)
        {
            switch (pairNumber)
            {
                case 1:
                    return "7:45-9:20";
                case 2:
                    return "9:30-11:05";
                case 3:
                    return "11:15-12:50";
                case 4:
                    return "13:10-14:45";
                case 5:
                    return "14:55-16:30";
                case 6:
                    return "16:40-18:15";
                case 7:
                    return "18:25-20:00";
                case 8:
                    return "20:10-21:45";
                default:
                    return "0:00-00:00";
            }
        }
    }
}
