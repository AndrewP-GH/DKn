﻿using System;
using System.Globalization;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private readonly Type[] _works = { typeof(Lab_1_SelfOrgFile), typeof(Lab_2_BinaryTree) };

        public MainForm()
        {
            InitializeComponent();
            Resources.Culture = CultureInfo.CurrentCulture;
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            foreach (var work in _works)
            {
                comboBox1.Items.Add(work.GetMethod("ItemText").Invoke(null, null));
            }  
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(Resources.Form1_оПрограммеToolStripMenuItem_Click_Лабораторная_работа_2017__0_Выполнил__Парамонов_А_А__1_Т3О___101М___16, Environment.NewLine), Resources.Form1_оПрограммеToolStripMenuItem_Click_О_программе, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedForm = (Form)Activator.CreateInstance(_works[comboBox1.SelectedIndex]);
            selectedForm.StartPosition = FormStartPosition.CenterScreen;
            //selectedForm.MaximizeBox = false;
            selectedForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            selectedForm.Show();
        }
    }
}