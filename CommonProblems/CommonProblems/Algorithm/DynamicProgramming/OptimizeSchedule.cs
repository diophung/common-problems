//Dynamic programming: optimal sub-problems and overlapping sub-problems
//Divide and conquer: non-overlapping sub-problems

using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems.Algorithm.DynamicProgramming
{
	public class OptimizeSchedule
	{
		IList<Interval> _intervals { get; set; }


		void Init()
		{
			if (_intervals == null)
			{
				_intervals = new List<Interval>();
				_intervals.Add(new Interval(1, 2));
				_intervals.Add(new Interval(3, 6));
				_intervals.Add(new Interval(1, 4));
				_intervals.Add(new Interval(1, 3));
				_intervals.Add(new Interval(5, 10));
				_intervals.Add(new Interval(7, 12));
			}
		}

		public int Optimize(Interval[] intervals, int Limit)
		{
			int sumSoFar = 0;
			Interval[] results = new Interval[intervals.Length];

			if (intervals == null || intervals.Length == 0)
			{
				return 0;
			}

			if (Limit == 0)
			{
				return 0;
			}

			foreach (var iv in intervals)
			{
				if (!results.Contains(iv))
				{
					sumSoFar = Math.Max(sumSoFar, Optimize(results.ToArray(), Limit - iv.Duration));
				}
				else
				{
					sumSoFar = Math.Max(sumSoFar, iv.Duration + Optimize(results, Limit - iv.Duration));
				}
			}

			return sumSoFar;
		}
	}

	public class Interval
	{
		public int Start { get; set; }
		public int End { get; set; }

		public Interval(int start, int end)
		{
			Start = start;
			End = end;
		}

		public int Duration
		{
			get
			{
				return End - Start;
			}

		}
	}
}
