using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.DynamicProgramming
{
	public class SubSum
	{
		///problems: given a set of integer [itemsPool] and a targetSum, find all subset of itemsPool that adds up to targetSum.
		///algo: 
		///		GetSubSetSum (itemsPool, target, itemsSoFar)
		///			if sum(itemsSoFar) == target //we found it;
		///				print(itemsSoFar) & stop;
		///			
		///			if sum(itemSoFar) > target //exceed it
		///				stop, return;
		/// 
		///			for each item in itemsPool
		///				partial = itemSoFar + item;
		///				remaining = the tail of itemsPool; //(excluding [partial])
		///				GetSubSetSum(remaining, target, partial);
		///
		/// Analysis:	
		///				time complexity : exponential since it will try all subset of the itemsPool
		///				space complexity: exponential : in each loop: create a new List, the list contains all items (remaining + partial = itemsPool)
		public void GetSubsetSum(List<int> itemsPool, int targetSum, List<int> itemsSoFar)
		{
			int sumSoFar = itemsSoFar.Sum();

			if (sumSoFar == targetSum) //found it subset
			{
				Console.WriteLine("sum of [" + string.Join(",", itemsSoFar) + "] = " + targetSum);
				return;
			}

			if (sumSoFar > targetSum)
				return; //no more

			for (int i = 0; i < itemsPool.Count; i++)
			{
				List<int> remaining = new List<int>();
				for (int j = i + 1; j < itemsPool.Count; j++)
				{
					remaining.Add(itemsPool.ElementAt(j));
				}

				var partial = new List<int>();
				partial.AddRange(itemsSoFar);
				partial.Add(itemsPool.ElementAt(i));
				GetSubsetSum(remaining, targetSum, partial);
			}
		}
	}
}
