using System;
namespace PaycheckitasLib
{
	public static class TaxingService
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

		static decimal MinimumIncomeToApplySolidaryIncrease(Period period)
		{
			return 106444m;
		}

		static decimal TaxAdvancesFactor(Period period)
		{
			return 15.0m;
		}

		static decimal TaxSolidaryFactor(Period period)
		{
			return 7.0m;
		}

		public static decimal AdvancesTaxableHealth(Period period, bool advancesSubject, decimal taxableHealthIncome)
		{
			if (advancesSubject)
			{
				decimal compoundFactor = HealthService.HealthIncreaseFactor(period);

				Int32 resultGeneralValue = HealthIncreaseWithFactor(taxableHealthIncome, compoundFactor);

				return resultGeneralValue;
			}
			return 0m;
		}

		public static decimal AdvancesTaxableSocial(Period period, bool advancesSubject, decimal taxableSocialIncome)
		{
			if (advancesSubject)
			{
				decimal employerFactor = SocialService.SocialIncreaseFactor(period);

				Int32 resultGeneralValue = SocialIncreaseWithFactor(taxableSocialIncome, employerFactor);

				return resultGeneralValue;
			}
			return 0m;
		}

		private static Int32 HealthIncreaseWithFactor(decimal taxableIncome, decimal compoundFactor)
		{
			decimal compoundPaymentValue = HealthCompoundIncreaseWithFactor(taxableIncome, compoundFactor);

			decimal employeePaymentValue = DecimalOperations.Divide(compoundPaymentValue, 3);

			Int32 resultCompoundValue = RoundingOperations.RoundUpInt(compoundPaymentValue);

			Int32 resultEmployeeValue = RoundingOperations.RoundUpInt(employeePaymentValue);

			Int32 resultPaymentValue = (resultCompoundValue - resultEmployeeValue);

			return resultPaymentValue;
		}

		private static Int32 HealthCompoundIncreaseWithFactor(decimal taxableBasis, decimal compoundFactor)
		{
			decimal taxableResult = DecimalOperations.DecFactorResult(taxableBasis, compoundFactor);

			Int32 resultPaymentValue = RoundingOperations.RoundUpInt(taxableResult);

			return resultPaymentValue;
		}

		private static Int32 SocialIncreaseWithFactor(decimal taxableBasis, decimal increaseFactor)
		{
			decimal taxableResult = DecimalOperations.DecFactorResult(taxableBasis, increaseFactor);

			Int32 resultPaymentValue = RoundingOperations.RoundUpInt(taxableResult);

			return resultPaymentValue;
		}

		public static decimal AdvancesRoundedBasis(Period period, decimal taxableIncome)
		{
			decimal amountForCalc = DecSuppressNegative(SUPPRESS_NEGAT, taxableIncome);

			decimal advancesBasis = RoundingOperations.DecRoundUpHundreds(amountForCalc);

			return advancesBasis;
		}

		public static decimal AdvancesSolidaryBasis(Period period, decimal taxableIncome)
		{
			decimal solidaryLimit = MinimumIncomeToApplySolidaryIncrease(period);

			decimal solidaryBasis = Math.Max(0, taxableIncome - solidaryLimit);

			return solidaryBasis;
		}

		public static Int32 AdvancesRegularyTax(Period period, decimal generalBasis)
		{
			decimal advancesFactor = TaxAdvancesFactor(period);

			decimal advancesResult = DecimalOperations.DecFactorResult(generalBasis, advancesFactor);

			Int32 taxRegulary = RoundingOperations.RoundUpInt(advancesResult);

			return taxRegulary;
		}

		public static Int32 AdvancesSolidaryTax(Period period, decimal solidaryBasis)
		{
			decimal solidaryFactor = TaxSolidaryFactor(period);

			decimal solidaryResult = DecimalOperations.DecFactorResult(solidaryBasis, solidaryFactor);

			Int32 taxSolidary = RoundingOperations.RoundUpInt(solidaryResult);

			return taxSolidary;
		}

		public static decimal TaxComputedResult(Period period, decimal generalBasis)
		{
			decimal taxableHealth = AdvancesTaxableHealth(period, true, generalBasis);

			decimal taxableSocial = AdvancesTaxableSocial(period, true, generalBasis);

			decimal taxableSupers = generalBasis + taxableHealth + taxableSocial;

			decimal advancesBasis = AdvancesRoundedBasis(period, taxableSupers);

			decimal solidaryBasis = AdvancesSolidaryBasis(period, generalBasis);

			Int32 taxStandard = AdvancesRegularyTax(period, advancesBasis);

			Int32 taxSolidary = AdvancesSolidaryTax(period, solidaryBasis);

			return (taxStandard + taxSolidary);
		}

		public static decimal TaxAdvanceResult(Period period, decimal taxComputed, decimal taxAllowance)
		{
			return 0m;
		}
	}
}
