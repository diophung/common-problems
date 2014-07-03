using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.BaseDataStructure
{
	public class Interval
	{
		public int Start { get; set; }
		public int End { get; set; }

		public Interval(int start, int end)
		{
			Start = start;
			End = end;
		}
	}
}
