using System;
using System.Globalization;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private readonly Type[] _works = null;
        public MainForm()
        {
            InitializeComponent();
            Resources.Culture = CultureInfo.CurrentCulture;
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            //for (var i = 0; i != _works.Length; ++i)
            //    comboBox1.Items.Add((string)_works[i].GetMethod("ItemText").Invoke(null, null));
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(Resources.Form1_оПрограммеToolStripMenuItem_Click_Лабораторная_работа_2017__0_Выполнил__Парамонов_А_А__1_Т3О___101М___16, Environment.NewLine), Resources.Form1_оПрограммеToolStripMenuItem_Click_О_программе, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
