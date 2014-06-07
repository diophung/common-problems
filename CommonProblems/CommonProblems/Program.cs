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
			var ep = new EfficientPower();
			var timer = new Stopwatch();
			
			int c = 0;
			var r = (Int64)Math.Pow(2, 10);
			var rand = new Random();
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

			Console.WriteLine(Math.Pow(-2, -1.2));
			Console.WriteLine("Run test : " + r + " times");
			Console.WriteLine("EfficientPower slower than NormalPower: " + c + " times");
			Console.WriteLine("Probable reasons being: 1) Math.Pow() impl include several checkings - which incur overheads");
			Console.WriteLine("MSDN: Math.Pow() - http://msdn.microsoft.com/en-us/library/system.math.pow(v=vs.110).aspx");
			Console.WriteLine("MSDN: Math.Exp() - http://msdn.microsoft.com/en-us/library/system.math.exp.aspx");
			Console.WriteLine("2) The Math.Pow() underlying impl uses a slow method compare to Math.Exp()");

		
			Console.ReadLine();
		}
	}
}
