using System;
using System.Collections.Generic;
using System.Linq;
using CommonProblems.Algorithm.DynamicProgramming;

namespace CommonProblems.Algorithm.Helper
{
	public static class ListExtension
	{
		public static bool ContainsOverlapped(this List<Event> list)
		{
			var sortedList = list.OrderBy(x => x.Start).ToList();
			for (int i = 0; i < sortedList.Count; i++)
			{
				for (int j = i + 1; j < sortedList.Count; j++)
				{
					if (sortedList[i].IsOverlap(sortedList[j]))
						return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Sort in ascending order of ending time
		/// </summary>
		/// <param name="events"></param>
		/// <returns></returns>
		public static List<Event> SortByEndTime(this List<Event> events)
		{
			if (events == null) return new List<Event>();

			return events.OrderBy(x => x.End).ToList();
		}
	}
}
