using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UTSHelper.CistNure.Timetable;

namespace UTSHelper
{
    /// <summary>
    /// Элемент управления для получения данных о расписании.
    /// </summary>
    public partial class UTSControl : UserControl
    {
        #region Свойства и переменные.

        /// <summary>
        /// Контроллер, управляющий данным элементом (общий контроллер).
        /// </summary>
        public UTSController UTSController { get; set; }

        #endregion

        #region Конструктор.

        /// <summary>
        /// Конструктор.
        /// </summary>
        public UTSControl()
        {
            InitializeComponent();

            // инициализация пустого выпадающего списка факультетов.
            facultyComboBox.SelectedIndexChanged += facultyComboBox_SelectedIndexChanged;

            // инициализация пустого выпадающего списка кафедр.
            departmentComboBox.Items.Add("--- Select faculty --- ");
            departmentComboBox.SelectedIndex = 0;
            
            // инициализация пустого выпадающего списка преподавателей.
            teacherComboBox.Items.Add("--- Select department --- ");
            teacherComboBox.SelectedIndex = 0;
            
            teacherLabel.Enabled = false;
            teacherComboBox.Enabled = false;
            getTimesheetButton.Enabled = false;
        }

        #endregion

        #region События.

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStatus(true);

            UTSController.ClearCollections();
            departmentComboBox.Items.Clear();

            string selectedFaculty = Settings.GetFacultyFullName(facultyComboBox.SelectedItem.ToString());
            string[] departments = UTSController.GetDepartments(selectedFaculty);
            Array.Sort(departments);
            departmentComboBox.Items.AddRange(departments);
            departmentComboBox.SelectedIndexChanged += departmentComboBox_SelectedIndexChanged;

            teacherLabel.Enabled = false;
            teacherComboBox.Enabled = false;
            getTimesheetButton.Enabled = false;


            subjectLabel.Enabled = false;
            timesheetLabel.Enabled = false;
            typeLabel.Enabled = false;
            filterSubjectComboBox.Enabled = false;
            filterTypeComboBox.Enabled = false;
            timesheetTextBox.Enabled = false;
            SetStatus(false);
        }

        /// <summary>
        /// заглушка для отладки, автовыбор факультета, кафедры и преподавателя.
        /// </summary>
        internal void InitForDebag()
        {
            facultyComboBox.SelectedIndex = 8;      // КИУ
            departmentComboBox.SelectedIndex = 2;   // ЭВМ
            teacherComboBox.SelectedIndex = 16;     // Иващенко
            setDatesCurrentMonthButton.PerformClick();          // текущий месяц
            getTimesheetButton.PerformClick();          // получить заготовку для почасовки
            getTasklistButton.PerformClick();          // получить список дел
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStatus(true);
            teacherComboBox.Items.Clear();
            string selectedDepartment = departmentComboBox.SelectedItem.ToString();
            string[] teachers = UTSController.GetTeachers(selectedDepartment);
            Array.Sort(teachers);
            teacherComboBox.Items.AddRange(teachers);
            teacherLabel.Enabled = true;
            teacherComboBox.Enabled = true;
            getTimesheetButton.Enabled = false;
            subjectLabel.Enabled = false;
            timesheetLabel.Enabled = false;
            typeLabel.Enabled = false;
            filterSubjectComboBox.Enabled = false;
            filterTypeComboBox.Enabled = false;
            timesheetTextBox.Enabled = false;
            SetStatus(false);
        }

        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTimesheetButton.Enabled = true;
            subjectLabel.Enabled = false;
            timesheetLabel.Enabled = false;
            typeLabel.Enabled = false;
            filterSubjectComboBox.Enabled = false;
            filterTypeComboBox.Enabled = false;
            timesheetTextBox.Enabled = false;
        }

        private void setDatesCurrentMonthButton_Click(object sender, EventArgs e)
        {
            AssumeDates(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void setDatesNextMonthButton_Click(object sender, EventArgs e)
        {
            int nextMonth = DateTime.Now.Month == 12 ? 1 : DateTime.Now.Month + 1;
            int nextYear = nextMonth == 1 ? DateTime.Now.Year + 1 : DateTime.Now.Year;
            AssumeDates(nextYear, nextMonth);
        }

        private void setDatesButton_Click(object sender, EventArgs e)
        {
            AssumeDatesForCurrentMonth();
        }

        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSubject = filterSubjectComboBox.SelectedItem.ToString();
            string selectedType = filterTypeComboBox.SelectedItem.ToString();

            var table = _timetable.Events.Where(ev => ev.Subject == selectedSubject && ev.Type == selectedType).ToArray();

            timesheetTextBox.Text = "";
            foreach (Lesson ttEvent in table)
                timesheetTextBox.Text += ttEvent.ToTimesheetString() + "\r\n";
        }

        private void filterSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTypeComboBox.Items.Clear();
            filterTypeComboBox.Items.AddRange(_timetable.Subjects.First(subj => subj.NameFull == filterSubjectComboBox.SelectedItem.ToString()).Types);
            timesheetTextBox.Text = "";
        }

        private void getTimesheetButton_Click(object sender, EventArgs e)
        {
            DateTime begin = fromDatePicker.Value; 
            // добавление одного дня, для включения верхней границы в диапазон
            DateTime end = toDatePicker.Value.AddDays(1);
            string teacher = teacherComboBox.SelectedItem.ToString();
            
            Timetable timetable = UTSController.GetTimetable(teacher, begin, end);
            FillTimetable(timetable);
        }

        private void getTasklistButton_Click(object sender, EventArgs e)
        {
            DateTime begin = fromDatePicker.Value;
            // добавление одного дня, для включения верхней границы в диапазон
            DateTime end = toDatePicker.Value.AddDays(1);
            string teacher = teacherComboBox.SelectedItem.ToString();

            Timetable timetable = UTSController.GetTimetable(teacher, begin, end);
            FillTasklist(timetable);
        }

        #endregion

        #region Логика.

        /// <summary>
        /// Инициализация выпадающего списка факультетов заданной коллекцией.
        /// </summary>
        /// <param name="faculties">Коллекция </param>
        public void FillFaculties(IEnumerable<string> faculties)
        {
            // linq!!!
            foreach (string faculty in faculties)
            {
                facultyComboBox.Items.Add(Settings.GetFacultyShortName(faculty));
            }
            //facultyComboBox.Items.AddRange(faculties.ToArray<string>());
            facultyComboBox.SelectedIndexChanged += facultyComboBox_SelectedIndexChanged;
            facultyComboBox.Focus();
        }

        #region Предлагаемые даты

        /// <summary>
        /// Предложить значения полей выбора дат.
        /// </summary>
        /// <param name="yearNumber">Номер требуемого года.</param>
        /// <param name="monthNumber">Номер требуемого месяца.</param>
        private void AssumeDates(int yearNumber, int monthNumber)
        {
            DateTime now = DateTime.Now;
            int daysInMonth = DateTime.DaysInMonth(yearNumber, monthNumber);
            DateTime begin = new DateTime(now.Year, monthNumber, 1);
            DateTime end = new DateTime(now.Year, monthNumber, daysInMonth);
            
            fromDatePicker.Value = begin;
            toDatePicker.Value = end;
        }

        /// <summary>
        /// Предложить значения полей выбора дат, как для временных рамок типичного отчетного месяца.
        /// </summary>
        /// <remarks>Deprecated.</remarks>
        private void AssumeDatesForCurrentMonth()
        {
            DateTime begin;
            DateTime now = DateTime.Now;
            DateTime end;
            const int MonthFirst = 1;
            const int MonthLast = 12;
            const int DayFirst = 1;
            const int DayLast = 31;
            const int DayBegin = 26;
            const int DayEnd = 25;

            // текущая дата. Год нам не нужен - там граница по концу декабря обычно.
            int curMonthNumber = now.Month;
            int curDayNumber = now.Day;

            // месяцы расчетного периода. Особые случаи для декабря и января.
            int beginAccountingMonthNumber;
            int endAccountingMonthNumber;
            if (curDayNumber >= DayBegin)
            {
                beginAccountingMonthNumber = curMonthNumber == MonthLast ? curMonthNumber - 1 : curMonthNumber;
                endAccountingMonthNumber = curMonthNumber == MonthLast ? MonthLast : curMonthNumber + 1;
            }
            else
            {
                beginAccountingMonthNumber = curMonthNumber == MonthFirst ? MonthFirst : curMonthNumber - 1;
                endAccountingMonthNumber = curMonthNumber;
            }

            //  определение полных дат рассчетного периода
            if (endAccountingMonthNumber == MonthLast)
            {
                begin = new DateTime(now.Year, beginAccountingMonthNumber, DayBegin);
                end = new DateTime(now.Year, endAccountingMonthNumber, DayLast);
            }
            else
            {
                if (endAccountingMonthNumber == MonthFirst)
                {
                    begin = new DateTime(now.Year, beginAccountingMonthNumber, DayFirst);
                    end = new DateTime(now.Year, endAccountingMonthNumber, DayEnd);
                }
                else
                {
                    begin = new DateTime(now.Year, beginAccountingMonthNumber, DayBegin);
                    end = new DateTime(now.Year, endAccountingMonthNumber, DayEnd);
                }
            }

            fromDatePicker.Value = begin;
            toDatePicker.Value = end;
        }

        #endregion

        /// <summary>
        /// Переключение текста строки состояния.
        /// </summary>
        /// <param name="waiting">Флаг занятости приложения.</param>
        private void SetStatus(bool waiting)
        {
            string wait = "Обработка запроса...";
            string ready = "";

            if (waiting)
            {
                statusStripLabel.Text = wait;
            }
            else
            {
                statusStripLabel.Text = ready;
            }
        }

        Timetable _timetable;

        private void FillTimetable(Timetable timetable)
        {
            _timetable = timetable;

            filterSubjectComboBox.Items.Clear();
            filterSubjectComboBox.Items.AddRange(timetable.Subjects);
            timesheetTextBox.Text = "";

            subjectLabel.Enabled = true;
            timesheetLabel.Enabled = true;
            typeLabel.Enabled = true;
            filterSubjectComboBox.Enabled = true;
            filterTypeComboBox.Enabled = true;
            timesheetTextBox.Enabled = true;
        }

        // for dual pair
        // private Lesson _previousPair;

        private void FillTasklist(Timetable timetable)
        {
            tasklistTextBox.Text = "";

            const string dayTasklistTitleBegin = "Задачи на ";

            int daysAmount = (toDatePicker.Value - fromDatePicker.Value).Days;
            DateTime currentDate = fromDatePicker.Value.Date;
            for (int i = 0; i <= daysAmount; i++)
            {
                // подготовка заголовка списка дел на текущий день
                string currentDay = currentDate.ToString("yyyy.MM.dd") + ", " + currentDate.ToString("dddd");
                string dayTasklistTitle = dayTasklistTitleBegin + currentDay + ":";
                tasklistTextBox.Text += dayTasklistTitle + "\r\n";

                // добавление задач на текущий день
                foreach (Lesson lesson in timetable.Events)
                {
                    // если занятие не на требуемую дату, не рассматриваем.
                    DateTime lessonDate = lesson.DateTimeBegin.Date;
                    if (lessonDate != currentDate)
                    {
                        continue;
                    }

                    //if (_previousPair.DateTimeBegin.Date == )
                    //string temp = ttEvent.ToTaskListString();
                    //_previousPair = temp.Remove(0, temp.IndexOf(","));

                    //string date = ttEvent.DateTimeBegin.ToString("YYYY.MM.dd") + ", " + now.ToString("dddd") + ":";
                    tasklistTextBox.Text += "- " + lesson.ToTasklistString() + "\r\n";
                }

                currentDate = currentDate.AddDays(1);
            }
        }

        #endregion
    }
}
