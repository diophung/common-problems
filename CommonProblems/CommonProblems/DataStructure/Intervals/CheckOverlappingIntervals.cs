using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.DataStructure.Intervals {
	public class CheckOverlappingIntervals {
		//O(N^2) for checking
		public static bool HasConflict(List<Interval> intervals) {
			foreach (Interval i1 in intervals) {
				foreach (Interval i2 in intervals) {
					if (IsOverlap(i1, i2)) {
						return true;
					}
				}
			}
			return false;
		}

		//O(NlogN) for sorting, O(N) for checking
		public static bool HasConflictOpt(List<Interval> intervals) {
			intervals = intervals.OrderBy(x => x.Start).ToList();
			for (int i = 0; i < intervals.Count - 1; i++) {
				if (IsOverlap(intervals.ElementAt(i), intervals.ElementAt(i + 1))) {
					return true;
				}
			}
			return false;
		}
		
		static bool IsOverlap(Interval i1, Interval i2) {
			if (i1.Start < i2.Start) {
				return i1.End > i2.Start;
			}
			if (i1.Start > i2.Start) {
				return i1.End < i2.End;
			}
			return false;
		}
	}
}
