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
            //facultyComboBox.Focus(); // not work!
            //facultyComboBox.Items.Add("--- Select --- ");
            //facultyComboBox.SelectedIndex = 0;
            facultyComboBox.SelectedIndexChanged += facultyComboBox_SelectedIndexChanged;

            // инициализация пустого выпадающего списка кафедр.
            departmentComboBox.Items.Add("--- Select faculty --- ");
            departmentComboBox.SelectedIndex = 0;
            //departmentComboBox.SelectedIndexChanged += departmentComboBox_SelectedIndexChanged;

            // инициализация пустого выпадающего списка преподавателей.
            teacherComboBox.Items.Add("--- Select department --- ");
            teacherComboBox.SelectedIndex = 0;
            //teacherComboBox.SelectedIndexChanged += teacherComboBox_SelectedIndexChanged;

            label3.Enabled = false;
            teacherComboBox.Enabled = false;
            getTimesheetButton.Enabled = false;
        }

        #endregion

        #region События.

        private void facultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStatus(true);
            //if (facultyComboBox.SelectedIndex != 0)
            //{
            UTSController.ClearCollections();
                departmentComboBox.Items.Clear();
                string selectedFaculty = facultyComboBox.SelectedItem.ToString();
                string[] departments = UTSController.GetDepartments(selectedFaculty);
                Array.Sort(departments);
                departmentComboBox.Items.AddRange(departments);
                departmentComboBox.SelectedIndexChanged += departmentComboBox_SelectedIndexChanged; 
            
            label3.Enabled = false;
                teacherComboBox.Enabled = false;
                getTimesheetButton.Enabled = false;


                label6.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = false;
                filterSubjectComboBox.Enabled = false;
                filterTypeComboBox.Enabled = false;
                timeSheetTextBox.Enabled = false;
                //filterSubjectComboBox.Items.Clear();
           // }
           // else
           // {
                // }
                SetStatus(false);
        }

        /// <summary>
        /// заглушка для отладки, автовыбор факультета, кафедры и преподавателя.
        /// </summary>
        internal void InitForDebagLyashenko()
        {
            facultyComboBox.SelectedIndex = 8;      // КИУ
            departmentComboBox.SelectedIndex = 2;   // ЭВМ
            teacherComboBox.SelectedIndex = 23;     // Ляшенко
            setDatesButton.PerformClick();          // текущий месяц для отчетности.
        }

        /// <summary>
        /// заглушка для отладки, автовыбор факультета, кафедры и преподавателя.
        /// </summary>
        internal void InitForDebag()
        {
            facultyComboBox.SelectedIndex = 8;      // КИУ
            departmentComboBox.SelectedIndex = 2;   // ЭВМ
            teacherComboBox.SelectedIndex = 16;     // Иващенко
            setDatesButton.PerformClick();          // текущий месяц для отчетности.
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStatus(true);
            //if (departmentComboBox.SelectedIndex != 0)
            //{
            teacherComboBox.Items.Clear();
            string selectedDepartment = departmentComboBox.SelectedItem.ToString();
            string[] teachers = UTSController.GetTeachers(selectedDepartment);
            Array.Sort(teachers);
            teacherComboBox.Items.AddRange(teachers);
                label3.Enabled = true;
                teacherComboBox.Enabled = true;
                getTimesheetButton.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = false;
                filterSubjectComboBox.Enabled = false;
                filterTypeComboBox.Enabled = false;
                timeSheetTextBox.Enabled = false;
           // }
           // else
           // {
                // }
                SetStatus(false);
        }

        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTimesheetButton.Enabled = true;
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            filterSubjectComboBox.Enabled = false;
            filterTypeComboBox.Enabled = false;
            timeSheetTextBox.Enabled = false;
        }

        private void setDatesCurrentMonthButton_Click(object sender, EventArgs e)
        {
            AssumeDates(DateTime.Now.Year, DateTime.Now.Month);

            // for test
            //List<string> list = new List<string>(12);
            //for (int i = 1; i < 13; i++)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    AssumeDates(DateTime.Now.Year, i);
            //    list.Add(fromDatePicker.Value.ToShortDateString() + " " + toDatePicker.Value.ToShortDateString());
            //}
            //timeSheetTextBox.Lines = list.ToArray();
        }

        private void setDatesNextMonthButton_Click(object sender, EventArgs e)
        {
            int nextMonth = DateTime.Now.Month == 12 ? 1 : DateTime.Now.Month + 1;
            int nextYear = nextMonth == 1 ? DateTime.Now.Year + 1 : DateTime.Now.Year;
            AssumeDates(nextYear, nextMonth);
        }

        private void setDatesButton_Click(object sender, EventArgs e)
        {
            AssumeDateForCurrentMonth();
        }

        private void filterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSubject = filterSubjectComboBox.SelectedItem.ToString();
            string selectedType = filterTypeComboBox.SelectedItem.ToString();

            var table = m_timetable.Events.Where(ev => ev.Subject == selectedSubject && ev.Type == selectedType).ToArray();

            timeSheetTextBox.Text = "";
            foreach (Lesson ttEvent in table)
                timeSheetTextBox.Text += ttEvent.ToString() + "\r\n";
        }

        private void filterSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterTypeComboBox.Items.Clear();
            filterTypeComboBox.Items.AddRange(m_timetable.Subjects.First(subj => subj.NameFull == filterSubjectComboBox.SelectedItem.ToString()).Types);
            timeSheetTextBox.Text = "";
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

        #endregion

        #region Логика.

        /// <summary>
        /// Инициализация выпадающего списка факультетов заданной коллекцией.
        /// </summary>
        /// <param name="faculties">Коллекция </param>
        public void FillFaculties(IEnumerable<string> faculties)
        {
            facultyComboBox.Items.AddRange(faculties.ToArray<string>());
            facultyComboBox.SelectedIndexChanged += facultyComboBox_SelectedIndexChanged;
            facultyComboBox.Focus();
        }

        /// <summary>
        /// Предложить значения полей выбора дат, как для временных рамок типичного отчетного месяца.
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
        private void AssumeDateForCurrentMonth()
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

        Timetable m_timetable;

        private void FillTimetable(Timetable timetable)
        {
            m_timetable = timetable;

            filterSubjectComboBox.Items.Clear();
            filterSubjectComboBox.Items.AddRange(timetable.Subjects);
            timeSheetTextBox.Text = "";

            //foreach (TimetableEvent ttEvent in timetable.Events)
            //    timeSheetTextBox.Text += ttEvent.ToString() + "\r\n";

            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            filterSubjectComboBox.Enabled = true;
            filterTypeComboBox.Enabled = true;
            timeSheetTextBox.Enabled = true;
        }

        #endregion
    }
}
