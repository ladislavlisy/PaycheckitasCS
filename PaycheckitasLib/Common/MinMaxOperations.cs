using System;
namespace PaycheckitasLib
{
	public static class MinMaxOperations
	{
		public static decimal MinValueAlign (decimal valueToMin, decimal minLimitTo)
		{
			return MinIncValue (valueToMin, minLimitTo);
		}

		public static decimal MinIncValue (decimal valueToMin, decimal minLimitTo)
		{
			if (minLimitTo > 0m) {
				if (minLimitTo > valueToMin) {
					return minLimitTo;
				}
			}
			return valueToMin;
		}
	}
}
