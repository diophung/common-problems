using System.Collections.Generic;

namespace CommonProblems.DataStructure.Graphs
{
	public class Vertex
	{
		protected bool Equals(Vertex other)
		{
			return Id == other.Id && string.Equals(NodeName, other.NodeName) 
				&& NodeValue.Equals(other.NodeValue) 
				&& Equals(IncomingNeighbours, other.IncomingNeighbours) 
				&& Equals(OutgoingNeighbours, other.OutgoingNeighbours);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id;
				hashCode = (hashCode*397) ^ (NodeName != null ? NodeName.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ NodeValue.GetHashCode();
				hashCode = (hashCode*397) ^ (IncomingNeighbours != null ? IncomingNeighbours.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (OutgoingNeighbours != null ? OutgoingNeighbours.GetHashCode() : 0);
				return hashCode;
			}
		}

		public int Id { get; set; }
		public string NodeName { get; set; }
		public double NodeValue { get; set; }

		public IList<Vertex> IncomingNeighbours { get; set; }

		public IList<Vertex> OutgoingNeighbours { get; set; } 
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Vertex) obj);
		}

	}
}
