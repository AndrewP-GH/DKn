using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuickGraph;
using WinFormsGraphSharp;

namespace WindowsFormsApplication1
{
    public partial class Lab_2_BinaryTree : Form, ILab
    {
        private readonly BidirectionalGraph<object, IEdge<object>> _graph;
        private readonly GraphSharpControl _graphControl = new GraphSharpControl();
        private BinaryTree _root;
        private string _fileName;

        private BinaryTree ptr;

        public Lab_2_BinaryTree()
        {
            InitializeComponent();
            elementHost1.Child = _graphControl;
            _graph = new BidirectionalGraph<object, IEdge<object>>();
            _graphControl.Layout.Graph = _graph;
            _graphControl.Layout.AnimationLength = new TimeSpan(0);
        }

        public static string ItemText() => "Бинарное дерево";

        string ILab.ItemText()
        {
            return ItemText();
        }

        private void button_Clear_Click(object sender, System.EventArgs e)
        {
            ClearGraph();
        }

        private void button_Rand_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                int count = int.Parse(textBox2.Text);
                ClearGraph();
                _root = new BinaryTree();
                var rand = new Random();
                for (int i = 0; i < count; ++i)
                    _root.FindOrAdd(rand.Next(10000));
                DrawGraph();
            }
        }

        private void button_Optimal_Click(object sender, EventArgs e)
        {

        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Text data(*.txt) | *.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ClearGraph();
                    _root = new BinaryTree();
                    GC.Collect();
                    openFileDialog.RestoreDirectory = true;
                    using (var streamReader = new StreamReader(openFileDialog.FileName, Encoding.UTF8))
                    {
                        _fileName = openFileDialog.SafeFileName;
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            var parts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length < 2)
                                continue;
                            _root.FindOrAdd(int.Parse(parts[0]), parts[1]);
                        }
                    }
                    DrawGraph();
                }
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Text data(*.txt) | *.txt";
                saveFileDialog.FileName = _fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var streamWriter = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8))
                    {
                        _root?.PreOrderTreeTraversal((parent, child) => streamWriter.WriteLine($"{child.Key}|{child.Value}"));
                    }
                }
            }

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            var key = int.Parse(textBox_key_FAD.Text.Trim());
            var value = textBox_val_FA.Text.Trim();
            ClearGraph();
            var result = _root.FindOrAdd(key, value);
            DrawGraph();
            MessageBox.Show(result, "Значение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            var key = int.Parse(textBox_key_FAD.Text.Trim());
            ClearGraph();
            _root.Delete(key);
            DrawGraph();
        }

        private void ClearGraph()
        {
            _root?.PostOrderTreeTraversal((parent, child) => _graph.RemoveVertex(child.ToString()));
        }

        private void DrawGraph()
        {
            _root?.PreOrderTreeTraversal((parent, child) =>
            {
                _graph.AddVertex(child.ToString());
                if (parent != null)
                    _graph.AddEdge(new Edge<object>(parent.ToString(), child.ToString()));
            });
        }

        private void UpdateGraph()
        {
            ClearGraph();
            DrawGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}