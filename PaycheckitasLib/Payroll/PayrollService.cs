using System;
using System.Linq;

namespace PaycheckitasLib
{
	public static class PayrollService
	{
		const bool SUPPRESS_NEGAT = true;

		const bool MANDATORY_DUTY = true;

		public const Int32 NUMBER_ONE_HUNDRED = 100;

		public static decimal DecRoundUpHundreds (decimal valueDec)
		{
			return RoundingOperations.NearRoundUp (valueDec, NUMBER_ONE_HUNDRED);
		}

		public static decimal DecFactorResult (decimal valueDec, decimal factor)
		{
			return DecimalOperations.MultiplyAndDivide (valueDec, factor, 100m);
		}

		public static decimal DecSuppressNegative (bool suppress, decimal valueDec)
		{
			if (suppress && valueDec < decimal.Zero) {
				return decimal.Zero;
			}
			return valueDec;
		}

		public static int WorkingHoursResult (Period period)
		{
			Int32 secondsWeekly = TimeSheetService.HoursToSeconds(8 * 5);

			Int32 workdaysWeekly = 5;

			Int32 [] weekSchedule = TimeSheetService.WeekSchedule (secondsWeekly, workdaysWeekly);

			Int32 [] monthSchedule = TimeSheetService.MonthSchedule (period, weekSchedule);

			int timesheetHours = TimeSheetService.TotalTimesheetHours (monthSchedule);

			return timesheetHours;
		}

		public static decimal SalaryResult (Period period, decimal salaryAmount, Int32 workingHours, Int32 workedHours)
		{
			decimal scheduleFactor = 1.0m;

			decimal amountFactor = DecimalOperations.Multiply (salaryAmount, scheduleFactor);

			Int32 salariedHours = Math.Max (0, workedHours);

			decimal salaryResult = DecimalOperations.MultiplyAndDivide(salariedHours, amountFactor, workingHours);

			return RoundingOperations.RoundUp(salaryResult);
		}

		public static decimal BonusResult (decimal bonusAmount, decimal bonusFactor)
		{
			decimal bonusResult = DecimalOperations.Multiply (bonusAmount, bonusFactor);

			return RoundingOperations.RoundUp (bonusResult);
		}

		public static decimal HealthInsuranceFactor (Period period)
		{
			return DecimalOperations.Divide (135m, 1000m);
		}

		public static decimal HealthMandatoryBasis (Period period, bool dutyMandatory)
		{
			return dutyMandatory ? 9500m : 0m;
		}

		public static decimal HealthInsuranceResult (Period period, decimal employeeBase)
		{
			decimal mandatoryBasis = BasisMandatoryBalance (period, MANDATORY_DUTY, employeeBase);

			decimal compoundFactor = HealthInsuranceFactor (period);

			decimal calculatedBase = DecSuppressNegative (SUPPRESS_NEGAT, employeeBase);

			Int32 insuranceResult = EmployeeHealthInsuranceWithFactor (calculatedBase, mandatoryBasis, compoundFactor);

			return insuranceResult;
		}

		private static Int32 EmployeeHealthInsuranceWithFactor (decimal employeeBase, decimal mandatoryEmpee, decimal compoundFactor)
		{
			decimal decimalResult1 = DecFactorResult (mandatoryEmpee, compoundFactor);

			decimal decimalResult2 = DecFactorResult (employeeBase, compoundFactor);

			decimal decimalResult3 = DecimalOperations.Divide (decimalResult2, 3);

			Int32 insuranceResult = RoundingOperations.RoundUpInt (decimal.Add (decimalResult1, decimalResult3));

			return insuranceResult;
		}

		public static decimal BasisMandatoryBalance (Period period, bool dutyMandatory, decimal valResult)
		{
			decimal minHealthLimit = HealthMandatoryBasis (period, dutyMandatory);

			decimal calculatedBase = Math.Max (0m, valResult);

			decimal balancedResult = MinMaxOperations.MinValueAlign (calculatedBase, minHealthLimit);

			decimal mandatoryBasis = Math.Max (0, decimal.Subtract (balancedResult, calculatedBase));

			return mandatoryBasis;
		}

		static decimal SocialInsuranceFactor (Period period)
		{
			return DecimalOperations.Divide (65m, 1000m);
		}

		public static decimal SocialInsuranceResult (Period period, decimal employeeBase)
		{
			decimal employeeFactor = SocialInsuranceFactor (period);

			decimal calculatedBase = DecSuppressNegative (SUPPRESS_NEGAT, employeeBase);

			decimal decimalResult = DecFactorResult (employeeBase, employeeFactor);

			Int32 insuranceResult = RoundingOperations.RoundUpInt (decimalResult);

			return insuranceResult;
		}

		static decimal HealthIncreaseFactor (Period period)
		{
			return DecimalOperations.Divide (135m, 1000m);
		}

		static decimal SocialIncreaseFactor (Period period)
		{
			return DecimalOperations.Divide (250m, 1000m);
		}

		static decimal MinimumIncomeToApplySolidaryIncrease (Period period)
		{
			return 106444m;
		}

		static decimal TaxAdvancesFactor (Period period)
		{
			return 15.0m;
		}

		static decimal TaxSolidaryFactor (Period period)
		{
			return 7.0m;
		}

		public static decimal AdvancesTaxableHealth (Period period, bool advancesSubject, decimal taxableHealthIncome)
		{
			if (advancesSubject) {
				decimal compoundFactor = HealthIncreaseFactor (period);

				Int32 resultGeneralValue = HealthIncreaseWithFactor (taxableHealthIncome, compoundFactor);

				return resultGeneralValue;
			}
			return 0m;
		}

		public static decimal AdvancesTaxableSocial (Period period, bool advancesSubject, decimal taxableSocialIncome)
		{
			if (advancesSubject) {
				decimal employerFactor = SocialIncreaseFactor (period);

				Int32 resultGeneralValue = SocialIncreaseWithFactor (taxableSocialIncome, employerFactor);

				return resultGeneralValue;
			}
			return 0m;
		}

		private static Int32 HealthIncreaseWithFactor (decimal taxableIncome, decimal compoundFactor)
		{
			decimal compoundPaymentValue = HealthCompoundIncreaseWithFactor (taxableIncome, compoundFactor);

			decimal employeePaymentValue = DecimalOperations.Divide (compoundPaymentValue, 3);

			Int32 resultCompoundValue = RoundingOperations.RoundUpInt (compoundPaymentValue);

			Int32 resultEmployeeValue = RoundingOperations.RoundUpInt (employeePaymentValue);

			Int32 resultPaymentValue = (resultCompoundValue - resultEmployeeValue);

			return resultPaymentValue;
		}

		private static Int32 HealthCompoundIncreaseWithFactor (decimal taxableBasis, decimal compoundFactor)
		{
			decimal taxableResult = DecFactorResult (taxableBasis, compoundFactor);

			Int32 resultPaymentValue = RoundingOperations.RoundUpInt (taxableResult);

			return resultPaymentValue;
		}

		private static Int32 SocialIncreaseWithFactor (decimal taxableBasis, decimal increaseFactor)
		{
			decimal taxableResult = DecFactorResult (taxableBasis, increaseFactor);

			Int32 resultPaymentValue = RoundingOperations.RoundUpInt (taxableResult);

			return resultPaymentValue;
		}

		public static decimal AdvancesRoundedBasis (Period period, decimal taxableIncome)
		{
			decimal amountForCalc = DecSuppressNegative (SUPPRESS_NEGAT, taxableIncome);

			decimal advancesBasis = DecRoundUpHundreds (amountForCalc);

			return advancesBasis;
		}

		public static decimal AdvancesSolidaryBasis (Period period, decimal taxableIncome)
		{
			decimal solidaryLimit = MinimumIncomeToApplySolidaryIncrease (period);

			decimal solidaryBasis = Math.Max (0, taxableIncome - solidaryLimit);

			return solidaryBasis;
		}

		public static Int32 AdvancesRegularyTax (Period period, decimal generalBasis)
		{
			decimal advancesFactor = TaxAdvancesFactor (period);

			decimal advancesResult = DecFactorResult (generalBasis, advancesFactor);

			Int32 taxRegulary = RoundingOperations.RoundUpInt (advancesResult);

			return taxRegulary;
		}

		public static Int32 AdvancesSolidaryTax (Period period, decimal solidaryBasis)
		{
			decimal solidaryFactor = TaxSolidaryFactor (period);

			decimal solidaryResult = DecFactorResult (solidaryBasis, solidaryFactor);

			Int32 taxSolidary = RoundingOperations.RoundUpInt (solidaryResult);

			return taxSolidary;
		}

		public static decimal TaxComputedResult (Period period, decimal generalBasis)
		{
			decimal taxableHealth = AdvancesTaxableHealth(period, true, generalBasis);

			decimal taxableSocial = AdvancesTaxableSocial(period, true, generalBasis);

			decimal taxableSuper = generalBasis + taxableHealth + taxableSocial;

			decimal advancesBasis = AdvancesRoundedBasis(period, generalBasis);

			decimal solidaryBasis = AdvancesSolidaryBasis(period, generalBasis);

			Int32 taxStandard = AdvancesRegularyTax (period, advancesBasis);

			Int32 taxSolidary = AdvancesSolidaryTax (period, solidaryBasis);

			return (taxStandard + taxSolidary);
		}

		public static decimal TaxAdvanceResult (Period period, decimal taxComputed, decimal taxAllowance)
		{
			return 0m;
		}
	}
}
