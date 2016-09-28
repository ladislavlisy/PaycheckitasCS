using System;
namespace PaycheckitasLib
{
	public static class SocialService
	{
		const bool SOCIAL_SUPPRESS_NEGAT = true;

		static decimal SocialInsuranceFactor(Period period)
		{
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return SocialCzConstants2011.FACTOR_EMPLOYEE;
				case 2012:
					return SocialCzConstants2012.FACTOR_EMPLOYEE;
				case 2013:
					return SocialCzConstants2013.FACTOR_EMPLOYEE;
				case 2014:
					return SocialCzConstants2014.FACTOR_EMPLOYEE;
				case 2015:
					return SocialCzConstants2015.FACTOR_EMPLOYEE;
				case 2016:
					return SocialCzConstants2016.FACTOR_EMPLOYEE;
				default:
					return SocialCzConstants2016.FACTOR_EMPLOYEE;
			}

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
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return SocialCzConstants2011.FACTOR_EMPLOYER;
				case 2012:									 
					return SocialCzConstants2012.FACTOR_EMPLOYER;
				case 2013:									 
					return SocialCzConstants2013.FACTOR_EMPLOYER;
				case 2014:									 
					return SocialCzConstants2014.FACTOR_EMPLOYER;
				case 2015:									 
					return SocialCzConstants2015.FACTOR_EMPLOYER;
				case 2016:									 
					return SocialCzConstants2016.FACTOR_EMPLOYER;
				default:									   
					return SocialCzConstants2016.FACTOR_EMPLOYER;
			}

		}

	}
}
