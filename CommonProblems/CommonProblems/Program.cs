using CommonProblems.Maths;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems
{
	public class Program
	{
		public static void Main(string[] args)
		{
			EfficientPower ep = new EfficientPower();
			Console.WriteLine("Enter x:");
			double x = Double.Parse(Console.ReadLine());
			Console.WriteLine("Enter power: ");
			int toPower = Int32.Parse(Console.ReadLine());
			Stopwatch timer = new Stopwatch();
			timer.Start();
			Console.WriteLine(string.Format("{0} to the power of {1}= {2}", x,toPower, ep.NormalPowerMethod(x,toPower)));
			timer.Stop();
			Console.WriteLine("Normal power time =" + timer.ElapsedTicks);
			
			//-------------- efficient
			timer.Reset();
			timer.Start();
			Console.WriteLine(string.Format("Efficient power: {0} to the power of {1}= {2}", x, toPower, ep.EfficientPowerMethod(x, toPower)));
			timer.Stop();
			Console.WriteLine("Efficient power time =" + timer.ElapsedTicks);

			Console.ReadLine();
		}
	}
}
