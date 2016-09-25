using System;
namespace PaycheckitasLib
{
	public static class RoundingOperations
	{
		public static decimal RoundUp (decimal valueDec)
		{
			decimal roundRet = decimal.Ceiling (Math.Abs (valueDec));

			return (valueDec < 0m ? decimal.Negate (roundRet) : roundRet);
		}

		public static decimal RoundDown (decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec));

			return (valueDec < 0m ? decimal.Negate (roundRet) : roundRet);
		}

		public static decimal NearRoundUp (decimal valueDec, Int32 nearest = 100)
		{
			decimal dividRet = DecimalOperations.Divide (valueDec, nearest);

			decimal multiRet = DecimalOperations.Multiply (RoundUp (dividRet), nearest);

			return multiRet;
		}

		public static decimal NearRoundDown (decimal valueDec, Int32 nearest = 100)
		{
			decimal dividRet = DecimalOperations.Divide (valueDec, nearest);

			decimal multiRet = DecimalOperations.Multiply (RoundDown (dividRet), nearest);

			return multiRet;
		}
		private static readonly decimal INT_ROUNDING_CONST = 0.5m;

		public static Int32 RoundToInt (decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec) + INT_ROUNDING_CONST);

			return decimal.ToInt32 (valueDec < 0m ? decimal.Negate (roundRet) : roundRet);
		}

		public static Int32 RoundUpInt (decimal valueDec)
		{
			decimal roundRet = decimal.Ceiling (Math.Abs (valueDec));

			return decimal.ToInt32 (valueDec < 0m ? decimal.Negate (roundRet) : roundRet);
		}

		public static Int32 RoundDownInt (decimal valueDec)
		{
			decimal roundRet = decimal.Floor (Math.Abs (valueDec));

			return decimal.ToInt32 (valueDec < 0m ? decimal.Negate (roundRet) : roundRet);
		}

		public static Int32 NearRoundUpInt (decimal valueDec, Int32 nearest = 100)
		{
			decimal dividRet = DecimalOperations.Divide (valueDec, nearest);

			decimal multiRet = DecimalOperations.Multiply (RoundUp (dividRet), nearest);

			return RoundToInt (multiRet);
		}


		public static Int32 NearRoundDownInt (decimal valueDec, Int32 nearest = 100)
		{
			decimal dividRet = DecimalOperations.Divide (valueDec, nearest);

			decimal multiRet = DecimalOperations.Multiply (RoundDown (dividRet), nearest);

			return RoundToInt (multiRet);
		}
	}
}
