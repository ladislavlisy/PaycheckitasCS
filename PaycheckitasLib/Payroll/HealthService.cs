using System;
namespace PaycheckitasLib
{
	public static class HealthService
	{
		const bool HEALTH_SUPPRESS_NEGAT = true;

		const bool HEALTH_MANDATORY_DUTY = true;

		public static decimal HealthInsuranceFactor(Period period)
		{
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return HealthCzConstants2011.FACTOR_COMPOUND;
				case 2012:
					return HealthCzConstants2012.FACTOR_COMPOUND;
				case 2013:
					return HealthCzConstants2013.FACTOR_COMPOUND;
				case 2014:
					return HealthCzConstants2014.FACTOR_COMPOUND;
				case 2015:
					return HealthCzConstants2015.FACTOR_COMPOUND;
				case 2016:
					return HealthCzConstants2016.FACTOR_COMPOUND;
				default:
					return HealthCzConstants2016.FACTOR_COMPOUND;
			}

		}

		public static decimal HealthMandatoryBasis(Period period, bool dutyMandatory)
		{
			if (!dutyMandatory)
			{
				return 0;
			}
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return HealthCzConstants2011.BASIS_MANDATORY;
				case 2012:
					return HealthCzConstants2012.BASIS_MANDATORY;
				case 2013:
					return HealthCzConstants2013.BASIS_MANDATORY;
				case 2014:
					return HealthCzConstants2014.BASIS_MANDATORY;
				case 2015:
					return HealthCzConstants2015.BASIS_MANDATORY;
				case 2016:
					return HealthCzConstants2016.BASIS_MANDATORY;
				default:
					return HealthCzConstants2016.BASIS_MANDATORY;
			}
		}

		public static decimal BasisMandatoryBalance(Period period, bool dutyMandatory, decimal valResult)
		{
			decimal minHealthLimit = HealthMandatoryBasis(period, dutyMandatory);

			decimal calculatedBase = Math.Max(0m, valResult);

			decimal balancedResult = MinMaxOperations.MinValueAlign(calculatedBase, minHealthLimit);

			decimal mandatoryBasis = Math.Max(0, decimal.Subtract(balancedResult, calculatedBase));

			return mandatoryBasis;
		}

		public static decimal HealthInsuranceResult(Period period, decimal employeeBase)
		{
			decimal mandatoryBasis = BasisMandatoryBalance(period, HEALTH_MANDATORY_DUTY, employeeBase);

			decimal compoundFactor = HealthInsuranceFactor(period);

			decimal calculatedBase = DecimalOperations.DecSuppressNegative(HEALTH_SUPPRESS_NEGAT, employeeBase);

			Int32 insuranceResult = EmployeeHealthInsuranceWithFactor(calculatedBase, mandatoryBasis, compoundFactor);

			return insuranceResult;
		}

		private static Int32 EmployeeHealthInsuranceWithFactor(decimal employeeBase, decimal mandatoryEmpee, decimal compoundFactor)
		{
			decimal decimalResult1 = DecimalOperations.DecFactorResult(mandatoryEmpee, compoundFactor);

			decimal decimalResult2 = DecimalOperations.DecFactorResult(employeeBase, compoundFactor);

			decimal decimalResult3 = DecimalOperations.Divide(decimalResult2, 3);

			Int32 insuranceResult = RoundingOperations.RoundUpInt(decimal.Add(decimalResult1, decimalResult3));

			return insuranceResult;
		}

		public static decimal HealthIncreaseFactor(Period period)
		{
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return HealthCzConstants2011.FACTOR_COMPOUND;
				case 2012:
					return HealthCzConstants2012.FACTOR_COMPOUND;
				case 2013:
					return HealthCzConstants2013.FACTOR_COMPOUND;
				case 2014:
					return HealthCzConstants2014.FACTOR_COMPOUND;
				case 2015:
					return HealthCzConstants2015.FACTOR_COMPOUND;
				case 2016:
					return HealthCzConstants2016.FACTOR_COMPOUND;
				default:
					return HealthCzConstants2016.FACTOR_COMPOUND;
			}

		}

	}
}