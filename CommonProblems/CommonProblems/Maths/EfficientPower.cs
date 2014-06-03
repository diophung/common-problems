using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProblems.Maths
{
	public class EfficientPower
	{
		public Int64 NormalPowerMethod(double x, int toPower)
		{
			return (Int64)Math.Pow(x, toPower);
		}

		public Int64 EfficientPowerMethod(double x, int toPower)
		{
			return (Int64)Math.Exp(Math.Log(x) * toPower);
		}
	}
}
