using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Lab_1_SelfOrgFile : Form, ILab
    {
        private List<ElementInSelfOrganaziList> _items = new List<ElementInSelfOrganaziList>();
        private string _fileName;
        private string _filePath;
        public Lab_1_SelfOrgFile()
        {
            InitializeComponent();
        }

        public static string ItemText() => "Самоорганизующийся файл";

        string ILab.ItemText()
        {
            return ItemText();
        }

        private void Load_Click(object sender, System.EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Text data(*.txt) | *.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _items.Clear();
                    openFileDialog.RestoreDirectory = true;
                    using (var streamReader = new StreamReader(openFileDialog.FileName))
                    {
                        _fileName = openFileDialog.SafeFileName;
                        _filePath = openFileDialog.FileName.Replace(_fileName, string.Empty);
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            var parts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length < 2)
                                continue;
                            var valueString = new StringBuilder(parts[1]);
                            for (var i = 2; i < parts.Length; ++i)
                                valueString.Append("|" + parts[i]);
                            _items.Add(new ElementInSelfOrganaziList(int.Parse(parts[0]), valueString.ToString()));
                        }
                    }
                }
            }
            UpdateTreeView();
        }

        private void Save_Click(object sender, System.EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = @"Text data(*.txt) | *.txt";
                saveFileDialog.FileName = _fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var streamWriter = new StreamWriter(_fileName))
                    {
                        foreach (var item in _items)
                        {
                            streamWriter.WriteLine($"{item.Key}|{item.Value}");
                        }
                    }
                }
            }
        }

        private void Find_Click(object sender, System.EventArgs e)
        {
            var findKeyText = textFind.Text.Trim();
            int findKey;
            if (!string.IsNullOrWhiteSpace(findKeyText) && int.TryParse(findKeyText, out findKey))
            {
                for (var i = 0; i < _items.Count; ++i)
                {
                    if (_items[i].Key == findKey)
                    {
                        var item = _items[i];
                        _items.RemoveAt(i);
                        _items.Insert(0, item);
                        UpdateTreeView();
                        treeView1.Nodes[0].BackColor = Color.Chartreuse;
                        return;
                    }
                }
                MessageBox.Show("Элемент не найден.");
            }
            else
                MessageBox.Show("Некорректное значение для поиска.");
        }

        private void Add_Click(object sender, System.EventArgs e)
        {
            var addKeyText = textBox1.Text.Trim();
            var addVal = textBox2.Text.Trim();
            int findKey;
            if (!string.IsNullOrWhiteSpace(addKeyText) && !string.IsNullOrWhiteSpace(addVal) &&
                int.TryParse(addKeyText, out findKey))
            {
                var elem = _items.Where(el => el.Key == findKey).ToArray();
                if (elem.Any())
                {
                    elem[0].Value = addVal;
                }
                else
                {
                    _items.Add(new ElementInSelfOrganaziList(findKey, addVal));
                }
                UpdateTreeView();
            }
            else
                MessageBox.Show("Некорректные входные значения.");
        }

        private struct ElementInSelfOrganaziList
        {
            private int _key;
            private string _value;

            public ElementInSelfOrganaziList(int k, string val)
            {
                _key = k;
                _value = val;
            }

            public int Key => _key;
            public string Value
            {
                get => _value;
                set => _value = value;
            }
        }

        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            foreach (var item in _items)
            {
                var node = treeView1.Nodes.Add(item.Key.ToString());
                node.Nodes.Add(item.Value);
            }
            treeView1.EndUpdate();
            treeView1.ExpandAll();
        }

    }
}