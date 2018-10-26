using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTSHelper.CistNure.Timetable
{
    /// <summary>
    /// Расписание.
    /// </summary>
    public class Timetable
    {
        /// <summary>
        /// События расписания - занятия различных видов.
        /// </summary>
        public Lesson[] Events { get; private set; }

        /// <summary>
        /// Дисциплины, вообще присутствующие в расписании.
        /// </summary>
        public SubjectDescription[] Subjects { get; private set; }

        public Timetable(Lesson[] events, SubjectDescription[] subjects)
        {
            Events = events;
            Subjects = subjects;
        }
    }      
}
