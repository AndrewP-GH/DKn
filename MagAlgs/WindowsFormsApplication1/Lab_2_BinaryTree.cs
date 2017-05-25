using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Lab_2_BinaryTree : Form, ILab
    {
        public Lab_2_BinaryTree()
        {
            InitializeComponent();
        }

        public static string ItemText() => "Бинарное дерево";

        string ILab.ItemText()
        {
            return ItemText();
        }

        private void canvasPaint(object sender, PaintEventArgs e)
        {
            var gObject = canvas.CreateGraphics();

        }
    }
}