using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Dotter.Compilers;
using Dotter.Compilers.Contents;
using Dotter.Objects;

namespace Dotter
{
    class Program
    {
        static void Main(string[] args)
        {
            var a0 = new Node {Name = "a0"};
            var a1 = new Node {Name = "a1"};
            var a2 = new Node {Name = "a2"};
            var a3 = new Node {Name = "a3"};

            var b0 = new Node { Name = "b0" };
            var b1 = new Node { Name = "b1" };
            var b2 = new Node { Name = "b2" };
            var b3 = new Node { Name = "b3" };

            var start = new Node {Name = "start", Shape = new Shape {Name = "Mdiamond"}};
            var end = new Node {Name = "end", Shape = new Shape {Name = "Msquare"}};

            var arr1 = new Arrow {Origin = a0, Destination = a1};
            var arr2 = new Arrow {Origin = a1, Destination = a2};
            var arr3 = new Arrow {Origin = a2, Destination = a3};

            var arr4 = new Arrow { Origin = b0, Destination = b1 };
            var arr5 = new Arrow { Origin = b1, Destination = b2 };
            var arr6 = new Arrow { Origin = b2, Destination = b3 };

            var firstNodeCollection = new NodeCollection();
            firstNodeCollection.AddNodes(a0, a1, a2, a3);
            firstNodeCollection.AddArrows(arr1, arr2, arr3);
            firstNodeCollection.Style = new Style {Name = "filled"};
            firstNodeCollection.Color = new Color {Name = "white"};

            var secondNodeCollection = new NodeCollection();
            secondNodeCollection.AddNodes(b0, b1, b2, b3);
            secondNodeCollection.AddArrows(arr4, arr5, arr6);
            secondNodeCollection.Style = new Style {Name = "filled"};

            var graph = new Graph()
            {
                Name = "G",
                SubGraphs = new List<SubGraph>
                {
                    new SubGraph()
                    {
                        Style = new Style { Name = "filled" },
                        Color = new Color {Name = "lightgrey"},
                        Label = new Label {Text = "process #1"},
                        Name = "cluster_0",
                        Nodes = firstNodeCollection
                    },
                    new SubGraph()
                    {
                        Color = new Color { Name = "blue" },
                        Label = new Label { Text = "process #2" },
                        Name = "cluster_1",
                        Nodes = secondNodeCollection

                    }
                },
                IsDirected = true
            };

            var arrows = new List<Arrow>
            {
                new Arrow {Origin = start, Destination = a0},
                new Arrow {Origin = start, Destination = b0},
                new Arrow {Origin = a1, Destination = b3},
                new Arrow {Origin = b2, Destination = a3},
                new Arrow {Origin = a3, Destination = a0},
                new Arrow {Origin = a3, Destination = end},
                new Arrow {Origin = b3, Destination = end},
            };

            graph.NodeCollection.AddNodes(start, end);
            foreach (var arrow in arrows)
            {
                graph.NodeCollection.AddArrows(arrow);
            }


            var graphCompiler = new GraphCompiler();
            var contentBuilder = new ContentBuilder();
            graphCompiler.Compile(graph, contentBuilder);

            Console.WriteLine(contentBuilder);

            Console.ReadLine();
        }
    }
}
