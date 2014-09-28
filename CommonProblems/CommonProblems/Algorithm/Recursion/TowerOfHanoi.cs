using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Algorithm.Recursion {
	public class TowerOfHanoi {
	
		public void MoveTower(int disks, Tower source, Tower dest, Tower temp){
		
			if (disks == 1) {
				dest.Push(source.Pop()); //move one disk from source to dest
				Console.WriteLine("Moving {0} from {1} to {2}", dest.Peek(), source.Name, dest.Name); 
			}
			
			else {
				//move all top disks, except largest one, source --> temp
				MoveTower(disks - 1, source, temp, dest);
				
				//move the largest disk : source --> dest
				dest.Push(source.Pop());
				Console.WriteLine("Moving {0} from {1} to {2}", dest.Peek(), source.Name, dest.Name);
				
				//move the rest: temp --> dest
				MoveTower(disks - 1, temp, dest, source);							
			}
		}
	}
	
	public class Tower {
		public int Count { get { return pegs.Count; } }
		Stack<Int32> pegs {get;set;}
		public string Name {get;set;}
		
		public Tower(string name) {
			pegs = new Stack<Int32>();
			Name = name;
		}
		
		public void Push(int i){
			pegs.Push(i);
		}		
		
		public int Pop() {
			return pegs.Pop();
		}
		
		public int Peek() {
			return pegs.Peek();
		}
	}
}
