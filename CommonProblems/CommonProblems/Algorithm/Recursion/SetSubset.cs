using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.Recursion {
	public class SetSubset {

		public List<List<string>> GetAllSubset(List<string> set, int index) {
			List<List<string>> allSubsets;

			//Print all subset of this set

			if (set.Count == index) {
				allSubsets = new List<List<string>>();
				allSubsets.Add(new List<string>());//empty set;
			}
			else {
				allSubsets = GetAllSubset(set, index + 1);

				var item = set[index]; //first items

				var crossJoinSets = new List<List<string>>();
				
                
				foreach (var subset in allSubsets) {
					var crossjoinSet = new List<string>();
					crossjoinSet.Add(item);
					crossjoinSet.AddRange(subset);
					crossJoinSets.Add(crossjoinSet);
				}

				allSubsets.AddRange(crossJoinSets);
			}
			return allSubsets;
		}

		//non recursive approach
		public List<List<string>> GetAllSubsetIterative(List<string> set, int index) {
			List<List<string>> allsubsets = new List<List<string>>();

			if (set.Count == 0) {
				allsubsets.Add(new List<string>());//empty set
			}
			else {
				for (int i = 1; i < set.Count; i++) {
						
				}
			}

			return allsubsets;
		}
	}
}
