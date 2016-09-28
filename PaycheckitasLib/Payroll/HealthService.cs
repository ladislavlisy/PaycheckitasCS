using System;
namespace PaycheckitasLib
{
	public static class HealthService
	{
		const bool HEALTH_SUPPRESS_NEGAT = true;

		const bool HEALTH_MANDATORY_DUTY = true;

		public static decimal HealthInsuranceFactor(Period period)
		{
			return DecimalOperations.Divide(135m, 1000m);
		}

		public static decimal HealthMandatoryBasis(Period period, bool dutyMandatory)
		{
			return dutyMandatory ? 9500m : 0m;
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
			return DecimalOperations.Divide(135m, 1000m);
		}

	}
}