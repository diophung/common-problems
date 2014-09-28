using System.Collections.Generic;

namespace CommonProblems.DataStructure.Graphs
{
	public class Graph
	{
		public string GraphName { get; set; }

		public IList<Vertex> Vertices { get; set; }

		public IList<Edge> Edges { get; set; }

		public Graph(string name, IList<Vertex> vertices, IList<Edge> edges   )
		{
			GraphName = name;
			Vertices = vertices;
			Edges = edges;
		}
		public Graph() { }
	}
}
