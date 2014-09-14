using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseStruct;

namespace CommonProblems.Graph
{
	public class Graph
	{
		public string GraphName { get; set; }

		ICollection<Vertex> Vertices { get; set; }

		ICollection<Edge> Edges { get; set; } 
	}
}
