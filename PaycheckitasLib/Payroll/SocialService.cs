using System;
namespace PaycheckitasLib
{
	public static class SocialService
	{
		const bool SOCIAL_SUPPRESS_NEGAT = true;

		static decimal SocialInsuranceFactor(Period period)
		{
			return SocialCzConstants2016.FACTOR_EMPLOYEE;
		}

		public static decimal SocialInsuranceResult(Period period, decimal employeeBase)
		{
			decimal employeeFactor = SocialInsuranceFactor(period);

			decimal calculatedBase = DecimalOperations.DecSuppressNegative(SOCIAL_SUPPRESS_NEGAT, employeeBase);

			decimal decimalResult = DecimalOperations.DecFactorResult(calculatedBase, employeeFactor);

			Int32 insuranceResult = RoundingOperations.RoundUpInt(decimalResult);

			return insuranceResult;
		}

		public static decimal SocialIncreaseFactor(Period period)
		{
			return SocialCzConstants2016.FACTOR_EMPLOYER;
		}

	}
}
