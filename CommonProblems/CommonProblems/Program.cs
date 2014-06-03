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
			Stopwatch timer = new Stopwatch();
			
			int c = 0;
			Int64 r = (Int64)Math.Pow(2, 24);
			Random rand = new Random();
			for (int i = 0; i < r; i++)
			{
				//Normal
				timer.Reset();
				int x = rand.Next();
				int toPower = rand.Next();
				timer.Start();
				ep.NormalPowerMethod(x, toPower);
				timer.Stop();
				long normalPowerTime = timer.ElapsedTicks;
				

				//Efficient
				timer.Start();
				timer.Reset();
				ep.EfficientPowerMethod(x, toPower);
				timer.Stop();
				long efficientPowerTime = timer.ElapsedTicks;

				if (efficientPowerTime > normalPowerTime)
				{
					c++;
				}
			}
			Console.WriteLine("Run test : " + r + " times");
			Console.WriteLine("EfficientPower slower than NormalPower: " + c + " times");
			Console.ReadLine();
		}
	}
}
