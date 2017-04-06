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