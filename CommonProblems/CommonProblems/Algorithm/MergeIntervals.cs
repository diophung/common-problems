using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProblems.BaseStruct;

namespace CommonProblems.Algorithm
{
	/// <summary>
	/// Problem: given a list of intervals, find the total length which were covered by this list of intervals.
	/// 
	/// For e.g: { (1,3), (2,4), (8,10) } --> covered = (1,4) + (8,10) = 6.
	/// </summary>
	public class MergeIntervals
	{
		private List<Interval> _intervals;

		public MergeIntervals()
		{
			Intervals  = new List<Interval>();
		}
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
			//Intervals = Sort(Intervals);
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
		public List<Interval> Merge(List<Interval> intervalsToMerge)
		{
			//Sort all interval by its starting time (ascending order)
			intervalsToMerge = Sort(intervalsToMerge);
			Stack<Interval> stack = new Stack<Interval>();
			if (intervalsToMerge != null && intervalsToMerge.Count > 0)
			{
				stack.Push(intervalsToMerge.ElementAt(0));
				
				//Algo: 
				//for each interval, if it overlap with the stacktop --> update the stack top.
				//else, push to stack
				foreach (var i in intervalsToMerge)
				{
					//if NOT overlap --> keep it in stack
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
	