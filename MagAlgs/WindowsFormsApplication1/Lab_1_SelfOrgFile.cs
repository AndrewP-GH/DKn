using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Lab_1_SelfOrgFile : Form, ILab
    {
        public Lab_1_SelfOrgFile()
        {
            InitializeComponent();
        }

        public static string ItemText() => "Самоорганизующийся файл";

        string ILab.ItemText()
        {
            return ItemText();
        }
    }
}