using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.DataStructure.Graphs;

namespace CommonProblems.Algorithm.GraphBased {
	public class DirectedAcylicGraph {

		//problem:	given information about runner in a racing, info about who beats whom
		//			build the order of finish.

		public IList<Vertex> CarRaceOrder(DirectedGraph graph) {
			/* To build a topological order of a DAG:
			
			L ← Empty list that will contain the sorted elements
			S ← Set of all nodes with no incoming edges
			while S is non-empty do
				remove a node n from S
				add n to tail of L
				for each node m with an edge e from n to m do
					remove edge e from the graph
					if m has no other incoming edges then
						insert m into S
			if graph has edges then
				return error (graph has at least one cycle)
			else 
				return L (a topologically sorted order)
			 
			 */

			IList<Vertex> output = new List<Vertex>();
			ISet<Vertex> noIncomgingEdge = new HashSet<Vertex>();

			foreach (var n in graph.Vertices) {
				if (n.IncomingNeighbours == null || n.IncomingNeighbours.Count == 0) {
					noIncomgingEdge.Add(n);
				}
			}

			while (noIncomgingEdge.Count > 0) {
				var node = noIncomgingEdge.FirstOrDefault();
				output.Add(node);
				noIncomgingEdge.Remove(node);

				foreach (var m in node.OutgoingNeighbours) {
					m.IncomingNeighbours.Remove(node);
					if (m.IncomingNeighbours == null || m.IncomingNeighbours.Count == 0) {
						noIncomgingEdge.Add(m);
					}
				}
			}

			return output;
		}
	}
}
