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
        public void GetSubsetSum(List<int> items, int target, List<int> itemsSoFar)
        {
            int s = itemsSoFar.Sum();

            if (s == target){
                Console.WriteLine("sum of [" + string.Join(",", itemsSoFar) + "] = " + target);
                return;
            }

            if (s > target)
                return;

            for (int i = 0; i < items.Count; i++){
                List<int> choices = new List<int>(itemsSoFar);
                choices.Add(items.ElementAt(i));

                List<int> remainders = Sublist(items, i+1);

                GetSubsetSum(remainders, target, choices);
            }
        }

        ///Get sublist start from the index
        List<int> Sublist(List<int> lst, int index){
            List<int> sub = new List<int>();
            for (int i = index; i < lst.Count; i++){
                sub.Add(i);
            }
            return sub;
        }
    }
}
