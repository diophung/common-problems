using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace CommonProblems.Maths
{
	public class EfficientPower
	{
		public double NormalPowerMethod(double x, double toPower)
		{
			return Math.Pow(x, toPower);
			
		}

		public double EfficientPowerMethod(double x, double toPower)
		{
			return Math.Exp(Math.Log(x) * toPower);
		}
	}
}
