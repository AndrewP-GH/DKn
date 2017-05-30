using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using QuickGraph;
using GraphSharp;
using GraphSharp.Controls;
using QuickGraph.Serialization;

namespace WinFormsGraphSharp
{
    /// <summary>
    /// Interaction logic for GraphSharpControl.xaml
    /// </summary>
    public partial class GraphSharpControl : UserControl
    {
        public GraphSharpControl()
        {
            InitializeComponent();

            layout.LayoutMode = LayoutMode.Automatic;
            layout.LayoutAlgorithmType = "EfficientSugiyama";
            layout.OverlapRemovalConstraint = AlgorithmConstraints.Automatic;
            layout.OverlapRemovalAlgorithmType = "FSA";
            layout.HighlightAlgorithmType = "Simple";
        }
        public void OpenFile(string fileName)
        {
            //graph where the vertices and edges should be put in
            var graph = new CompoundGraph<object, IEdge<object>>();
        
            try
            {
                //open the file of the graph
                var reader = XmlReader.Create(fileName);

                //create the serializer
                var serializer = new GraphMLDeserializer<object, IEdge<object>, CompoundGraph<object, IEdge<object>>>();


                //deserialize the graph
                serializer.Deserialize(reader, graph,
                                       id => id, (source, target, id) => new Edge<object>(source, target)
                    );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            layout.Graph = graph;
            layout.UpdateLayout();

        }

        private void Relayout_Click(object sender, RoutedEventArgs e)
        {
            layout.Relayout();
        }

        public GraphLayout Layout
        {
            get => layout;
            set => layout = value;
        }
    }
}
