//Dynamic programming: optimal sub-problems and overlapping sub-problems
//Divide and conquer: non-overlapping sub-problems

using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonProblems.Algorithm.DynamicProgramming {
	public class Scheduler {
		public List<Event> intervals { get; set; }

		public List<Event> Init() {
			if (intervals == null) {
				intervals = new List<Event>();
				intervals.Add(new Event(1, 6));
				intervals.Add(new Event(2, 7));
				intervals.Add(new Event(2, 5));
				intervals.Add(new Event(6, 10));
				intervals.Add(new Event(6, 8));
				intervals.Add(new Event(6, 9));
				intervals.Add(new Event(7, 11));
				intervals.Add(new Event(11, 24));
			}

			return intervals;
		}

		int Sum(List<Event> list) {
			int sum = 0;
			foreach (var i in list) {
				sum += i.Duration;
			}
			return sum;
		}

		public static bool ContainsOverlapped(List<Event> list) {
			var sortedList = list.OrderBy(x => x.Start).ToList();
			for (int i = 0; i < sortedList.Count; i++) {
				for (int j = i + 1; j < sortedList.Count; j++) {
					if (sortedList[i].IsOverlap(sortedList[j]))
						return true;
				}
			}
			return false;
		}

		//soFar: always contain non-overlap events.
		//toPick: the remaining event to choose. Remove those overlap with the first event in "soFar"
		//Algo: arrange the list by its end, try to greedily pick the item that last longest (with earliest start)
		//Keep being greedy until no more choice
		public List<Event> GreedyOptimize(List<Event> toPick, List<Event> soFar) {
			//no more choice
			if (toPick == null || toPick.Count == 0) {
				return soFar;
			}

			soFar = soFar.OrderByDescending(x => x.End).ThenBy(x => x.Start).ToList();
			toPick = toPick.OrderByDescending(x => x.End).ThenBy(x => x.Start).ToList();

			var choice = toPick.ElementAt(0); //add the event finish last
			toPick = Cleanup(toPick, choice.Start); //those end after this --> removed

			toPick.Remove(choice);
			soFar.Add(choice);
			
			//greedy pick the earliest 
			return GreedyOptimize(toPick, soFar);
		}

		bool BacktrackOptimize(List<Event> toPick, List<Event> soFar )
		{
			//no more choice, and soFar is optimal
			if (Sum(soFar) >= 24)
				return true;

			for(int i =0;i < toPick.Count;i++)
			{
				var eventToTry = toPick.ElementAt(i);
				soFar.Add(eventToTry);
				toPick.Remove(eventToTry);

				toPick.Remove(toPick.ElementAt(i));
				if (BacktrackOptimize(toPick, soFar))
					return true;
			}

			return false;
		}
		List<Event> Cleanup(List<Event> events, int endByThisHour) {
			List<Event> output = new List<Event>();
			foreach (var e in events) {
				//only allow those event end before this
				if (e.End <= endByThisHour) {
					output.Add(e);
				}
			}
			return output;
		}
		private static Event FindEarliestStart(List<Event> toPick, int byThisHour) {
			//find the earliest interval that can start out of this list
			for (int i = 0; i < toPick.Count; i++) {
				var earliestStart = toPick[i];
				if (earliestStart.Start <= byThisHour) {
					for (int j = 1; j < toPick.Count; j++) {
						if (toPick[j].Start <= earliestStart.Start) {
							earliestStart = toPick[j];
						}
					}
				}

				return earliestStart;
			}
			return null;
		}
	}

	public class Event {
		public bool IsOverlap(Event other) {
			return !(this.End <= other.Start ||
					this.Start >= other.End);
		}
		public override bool Equals(object obj) {
			var i = (Event)obj;
			return base.Equals(obj) && i.Start == this.Start && i.End == this.End;
		}
		public int Start { get; set; }
		public int End { get; set; }
		public Event(int start, int end) {
			Start = start;
			End = end;
		}
		public int Duration {
			get {
				return End - Start;
			}
		}
	}


}
