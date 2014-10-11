using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.DataStructure.Graphs {
	public class DirectedGraph:Graph {

		public DirectedGraph(IList<Vertex> vertices, IDictionary<Vertex, IList<Vertex>> directions) {
			this.Directions = directions;
			this.Vertices = vertices;
		}
		public IList<Vertex> Vertices { get; set; }

		public IDictionary<Vertex, IList<Vertex>> Directions { get; set; }

		public void Add(Vertex node, IList<Vertex> neightbors) {
			if (Directions[node] != null) {
				//update directions
				var directions = Directions[node];
				foreach (var n in neightbors) {
					if (!directions.Contains(n)) {
						directions.Add(n);
					}
				}
				Directions[node] = directions;
			}
			else {
				Directions[node] = neightbors;
			}
		}

		public void Remove(Vertex node) {
			if (Directions.ContainsKey(node)) {
				Directions.Keys.Remove(node);
			}
		}
	}
}
