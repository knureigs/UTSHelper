﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UTSHelper
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Общий контроллер для системы.
        /// </summary>
        private UTSController _utsController;

        public MainForm()
        {
            InitializeComponent();
        }

        #region События

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartWork();
        }

        #endregion

        #region Логика.

        /// <summary>
        /// Начало работы программы, инициализация основных компонентов.
        /// </summary>
        private void StartWork()
        {
            _utsController = new UTSController(utsControl);
            _utsController.Init();
        }

        #endregion
    }
}
