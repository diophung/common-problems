using System;

namespace CommonProblems.Algorithm.Maths
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

		public double EfficientPowerWithLogN(double baseNumber, int toPower)
		{
			if (Math.Abs(baseNumber) < 0.000000001) //fix floating point comparison - it's never exact match anyway
			{
				return 0;
			}
			if (toPower == 0)
			{
				return 1;
			}
			if (toPower < 0)
			{
				return 1 / (EfficientPowerWithLogN(baseNumber, toPower));
			}
			if (toPower % 2 == 0)
			{
				var halfPow = EfficientPowerWithLogN(baseNumber, toPower / 2);
				return halfPow * halfPow;
			}
			var halfPow2 = EfficientPowerWithLogN(baseNumber, toPower / 2);

			return halfPow2 * halfPow2 * baseNumber;
		}
	}
}
