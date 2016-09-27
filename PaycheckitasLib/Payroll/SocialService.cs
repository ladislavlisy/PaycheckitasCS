using System;
namespace PaycheckitasLib
{
	public static class SocialService
	{
		const bool SUPPRESS_NEGAT = true;

		const bool MANDATORY_DUTY = true;

		public static decimal DecSuppressNegative(bool suppress, decimal valueDec)
		{
			if (suppress && valueDec < decimal.Zero)
			{
				return decimal.Zero;
			}
			return valueDec;
		}

		static decimal SocialInsuranceFactor(Period period)
		{
			return DecimalOperations.Divide(65m, 1000m);
		}

		public static decimal SocialInsuranceResult(Period period, decimal employeeBase)
		{
			decimal employeeFactor = SocialInsuranceFactor(period);

			decimal calculatedBase = DecSuppressNegative(SUPPRESS_NEGAT, employeeBase);

			decimal decimalResult = DecimalOperations.DecFactorResult(calculatedBase, employeeFactor);

			Int32 insuranceResult = RoundingOperations.RoundUpInt(decimalResult);

			return insuranceResult;
		}

		public static decimal SocialIncreaseFactor(Period period)
		{
			return DecimalOperations.Divide(250m, 1000m);
		}

	}
}
