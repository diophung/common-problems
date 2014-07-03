using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseDataStructure;

namespace CommonProblems.Algorithm
{
	public class MergeIntervals
	{
		private List<Interval> _intervals;

		public MergeIntervals()
		{
			MergedIntervals = new Stack<Interval>();
			Intervals  = new List<Interval>();
		}
		public Stack<Interval> MergedIntervals { get; set; } 
		public List<Interval> Intervals
		{
			get
			{
				if (_intervals == null) _intervals = new List<Interval>();
				return _intervals;
			}
			set
			{
				_intervals = value;
			}
		}

		public void Add(int start, int end)
		{
			Interval i = new Interval(start,end);
			Intervals.Add(i);

			Intervals = Sort(Intervals);
		}

		public int Compute()
		{
			int covered = 0;
			Intervals = Merge(Intervals);
			foreach (var i in Intervals)
			{
				covered += Math.Abs(i.End - i.Start);
			}

			return covered;
		}


		public List<Interval> Sort(List<Interval> itv )
		{			
			itv = itv.OrderBy(x => x.Start).ToList();
			return itv;
		}
		public List<Interval> Merge(List<Interval> currentSets)
		{
			//Merge all itv, if overlapping
			currentSets = Sort(currentSets);
			Stack<Interval> stack = new Stack<Interval>();
			if (currentSets != null && currentSets.Count > 0)
			{
				stack.Push(currentSets.ElementAt(0));
				foreach (var i in currentSets)
				{
					if (!IsOverlap(i, stack.Peek()))
					{
						stack.Push(i);
					}
					else
					{
						if (i.End >= stack.Peek().End)
						{
							//update the top of the stack
							var topStack = stack.Pop();
							topStack.End = i.End;
							stack.Push(topStack);
						}
					}
				}
			}

			//now the stack contains merged intervals
			List<Interval> mergedIntervals = new List<Interval>();
			while (stack.Count > 0)
			{
				mergedIntervals.Add(stack.Pop());
			}

			return mergedIntervals;
		}

		bool IsOverlap(Interval a, Interval b)
		{
			return (a.Start >= b.Start && a.Start <= b.End) ||
			       (b.Start >= a.Start && b.Start <= a.End);

		}
	}
}
	