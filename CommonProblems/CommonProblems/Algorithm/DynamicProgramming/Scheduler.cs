//Dynamic programming: optimal sub-problems and overlapping sub-problems
//Divide and conquer: non-overlapping sub-problems

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using CommonProblems.Algorithm.Helper;

namespace CommonProblems.Algorithm.DynamicProgramming
{
	public class Scheduler
	{
		#region init
		public List<Event> intervals { get; set; }

		public List<Event> Init()
		{
			if (intervals == null)
			{
				intervals = new List<Event>();
				intervals.Add(new Event(8, 11));
				intervals.Add(new Event(6, 10));
				intervals.Add(new Event(5, 9));
				intervals.Add(new Event(3, 8));
				intervals.Add(new Event(4, 7));
				intervals.Add(new Event(0, 6));
				intervals.Add(new Event(3, 5));
				intervals.Add(new Event(1, 4));
			}

			return intervals;
		}
		
		#endregion

		#region Dynamic Programming
		public void DisplayOptimizeScheduleViaDp(List<Event> events)
		{
			events.Add(new Event(0, 0));
			events = events.SortByEndTime();

			int[] eventIndexes = findLatestCompatibleEvent(events);

			var optimalValue = getOptimalScheduleValueViaDp(events, eventIndexes);

			var output = DisplayOptimizeSchedule(events, events.Count - 1, optimalValue, eventIndexes);

			foreach (var e in output)
			{
				Console.WriteLine("Event: [{0}- {1}]", e.Start, e.End);
			}
		}

		/// <summary>
		/// Algo: given n events: 1,2...n-th with each finishing time f1, f2...fn
		/// - Sort all events by its finishing time so that f1 less than f2 less than fn.
		/// - Compute the p(n) to get the maximum event index that is not clashing with n-th
		/// - Then compute the optimal solution opt(n):
		///		 
		/// Iterative-Compute-Optimal {
		///		opt(0) = 0
		///		for j = 1 to n
		///			opt(j) = max(length(j-th event) + opt[p(j)], opt[j-1])
		/// }
		/// 
		/// output opt(n)
		/// </summary>
		/// <param name="toPick"></param>
		int[] getOptimalScheduleValueViaDp(List<Event> toPick, int[] latestCompatibleEventsBefore)
		{
			int[] optimal = new int[toPick.Count];
			int n = optimal.Length;

			optimal[0] = 0;
			for (int j = 1; j < n; j++)
			{
				var thisEvent = toPick.ElementAt(j);

				//compare between 2 choices: include or not include this event 

				optimal[j] = Math.Max(
									thisEvent.Duration + optimal[latestCompatibleEventsBefore[j]],  //(NOT INCLUDE)
									optimal[j - 1]);												//(INCLUDE)
			}

			return optimal;
		}

		List<Event> DisplayOptimizeSchedule(List<Event> toPick, int idx, int[] optimalLength, int[] eventIndexes)
		{
			List<Event> output = new List<Event>();
			if (idx == 0)
			{
				//base case: 
				return output;
			}

			else if (toPick[idx].Duration + optimalLength[eventIndexes[idx]] >= optimalLength[idx])
			{
				output.Add(toPick[idx]);
				
				//go back to the latest previous event
				output.AddRange(DisplayOptimizeSchedule(toPick, eventIndexes[idx], optimalLength, eventIndexes));
				return output;
			}
			else
			{
				//move back 1 event
				output.AddRange(DisplayOptimizeSchedule(toPick, idx - 1, optimalLength, eventIndexes));
				return output;
			}
		}

		/// <summary>
		/// In a sorted list by finishing time, find the largest i-th index of the previous event where they are still not clashing.
		/// </summary>
		/// <param name="toPick"></param>
		/// <returns></returns>
		int[] findLatestCompatibleEvent(List<Event> toPick)
		{
			var latestCompatEvents = new int[toPick.Count];

			//get the largest index i < such that i-th job is not overlap with j-th job.
			for (int i = 0; i < toPick.Count; i++)
			{
				for (int j = 0; j <= i; j++)
				{
					//find the largest index of the previous event, which do not overlap with this event
					if (!toPick.ElementAt(j).IsOverlap(toPick.ElementAt(i)))
					{
						latestCompatEvents[i] = j;
					}
				}
			}

			return latestCompatEvents;
		}
		
		#endregion

		#region Greedy programming
		List<Event> Cleanup(List<Event> events, int endByThisHour)
		{
			List<Event> output = new List<Event>();
			foreach (var e in events)
			{
				//only allow those event end before this
				if (e.End <= endByThisHour)
				{
					output.Add(e);
				}
			}
			return output;
		}

		/// <summary>
		///soFar: always contain non-overlap events.
		///toPick: the remaining event to choose. Remove those overlap with the first event in "soFar"
		///Algo: arrange the list by its end, try to greedily pick the item that last longest (with earliest start)
		///Keep being greedy until no more choice
		/// </summary>
		/// <param name="toPick"></param>
		/// <param name="soFar"></param>
		/// <returns></returns>
		public List<Event> GreedyOptimize(List<Event> toPick, List<Event> soFar)
		{
			//no more choice
			if (toPick == null || toPick.Count == 0)
			{
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
		
		#endregion
	}

	public class Event
	{
		public int EventId { get; set; }
		public bool IsOverlap(Event other)
		{
			return !(this.End <= other.Start ||
					this.Start >= other.End);
		}
		public override bool Equals(object obj)
		{
			var i = (Event)obj;
			return base.Equals(obj) && i.Start == this.Start && i.End == this.End;
		}
		public int Start { get; set; }
		public int End { get; set; }
		public Event(int start, int end)
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
