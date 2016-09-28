using System;
namespace PaycheckitasLib
{
	public static class DecimalOperations
	{
		public const decimal NUMBER_ONE_HUNDRED = 100m;

		public static decimal DecFactorResult(decimal valueDec, decimal factor)
		{
			return DecimalOperations.MultiplyAndDivide(valueDec, factor, NUMBER_ONE_HUNDRED);
		}

		public static decimal Multiply (decimal op1, decimal op2)
		{
			return decimal.Multiply (op1, op2);
		}

		public static decimal Divide (decimal op1, decimal div)
		{
			if (div == 0m) {
				return 0m;
			}
			return decimal.Divide (op1, div);
		}

		public static decimal MultiplyAndDivide (decimal op1, decimal op2, decimal div)
		{
			if (div == 0m) {
				return 0m;
			}
			decimal multiRet = decimal.Multiply (op1, op2);

			decimal dividRet = decimal.Divide (multiRet, div);

			return dividRet;
		}

		public static decimal DecimalCast (Int32 number)
		{
			return new decimal (number);
		}

		public static decimal DecSuppressNegative(bool suppress, decimal valueDec)
		{
			if (suppress && valueDec < decimal.Zero)
			{
				return decimal.Zero;
			}
			return valueDec;
		}
	}
}
