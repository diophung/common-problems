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

		public double EfficientPowerWithLogN(double baseNum, int power)
		{
			if (baseNum == 0) return 0;
			if (power == 0) return 1;
			if (power < 0) return 1/(EfficientPowerWithLogN(baseNum, -power));
			if (power % 2 == 0)
			{
				var halfPow = EfficientPowerWithLogN(baseNum, power/2);
				return halfPow*halfPow;
			}
			return EfficientPowerWithLogN(baseNum, power/2) * EfficientPowerWithLogN(baseNum, power/2) * baseNum;
		}
	}
}
