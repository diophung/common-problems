using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.DataStructure.Graphs;

namespace CommonProblems.Algorithm.GraphBased {
	public class Dijkstra {
		/*
		pseudo code:
		----------
		function Dijkstra(Graph, source):
			dist[source]  := 0                     // Distance from source to source
			for each vertex v in Graph:            // Initializations
				if v ≠ source
					dist[v]  := infinity           // Unknown distance function from source to v
					previous[v]  := undefined      // Previous node in optimal path from source
				end if 
				add v to Q                         // All nodes initially in Q (unvisited nodes)
			end for
    
			while Q is not empty:                  // The main loop
				u := vertex in Q with min dist[u]  // Source node in first case
				remove u from Q 
        
				for each neighbor v of u:           // where v has not yet been removed from Q.
					alt := dist[u] + length(u, v)
					if alt < dist[v]:               // A shorter path to v has been found
						dist[v]  := alt 
						previous[v]  := u 
					end if
				end for
			end while
			return dist[], previous[]
		end function
		 */

		public void ShortestPathDijkstra(Graph graph, Vertex source) {
			var distance = new Dictionary<Vertex, int>();
			var previous = new Dictionary<Vertex, Vertex>();

			distance[source] = 0; //distance to source = 0;
			previous[source] = null; //previous vertex in the optimal path from source
			Queue<Vertex> Q = new Queue<Vertex>();

			foreach (var v in graph.Vertices) {
				if (v != source) {
					distance[v] = int.MaxValue;
					previous[v] = null;
				}

				Q.Enqueue(v);
			}

			while (Q.Count > 0) {
				Vertex u = getMinDistance(distance); //find the shortest
				foreach (var v in u.Neighbours) {
					int alt = distance[u] + getLength(u, v, graph); //dist[u] + length(u, v)

					//find all path available
					//if to find only 1 path, can terminate if v == destination
					if (alt < distance[v]) {
						distance[v] = alt;
						previous[v] = u;
					}
				}
			}

			displayPath(source, graph, previous);
		}

		private void displayPath(Vertex startVertex, Graph graph, Dictionary<Vertex, Vertex> previous) {
			Console.WriteLine("Start from [{0}]", startVertex.Id);
			foreach (var p in previous) {
				Console.WriteLine("From: [{0}] to {1}, \t distance: [{2}]", 
									p.Key.Id, p.Value.Id, getLength(p.Key, p.Value, graph));
			}
		}

		private int getLength(Vertex from, Vertex to, Graph graph) {
			foreach (var e in graph.Edges) {
				if (e.StartVertex == from && e.EndVertext == to) {
					return e.Distance;
				}
			}
			return 0;
		}

		private Vertex getMinDistance(Dictionary<Vertex, int> distance) {
			Vertex smallest = distance.FirstOrDefault().Key;
			foreach (var k in distance.Keys) {
				if (distance[k] <= distance[smallest]) {
					smallest = k;
				}
			}
			return smallest;
		}
	}
}
