using System.Collections.Generic;

namespace CommonProblems.DataStructure.Graphs
{
	public class Vertex
	{
		public int Id { get; set; }
		public string NodeName { get; set; }
		public double NodeValue { get; set; }

		public IList<Vertex> IncomingNeighbours { get; set; }

		public IList<Vertex> OutgoingNeighbours { get; set; } 
		public override bool Equals(object obj)
		{
			var other = (Vertex)obj;
			return this.Id == other.Id && this.NodeName == other.NodeName && this.NodeValue == other.NodeValue;
		}

	}
}
