using System;
namespace PaycheckitasLib
{
	public static class TaxingService
	{
		const bool TAXING_SUPPRESS_NEGAT = true;

		static decimal MinimumIncomeToApplySolidaryIncrease(Period period)
		{
			return TaxingCzConstants2016.MIN_INCOME_APPLY_SOLIDARY_INCREASE;
		}

		static decimal TaxAdvancesFactor(Period period)
		{
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return TaxingCzConstants2011.FACTOR_ADVANCES;
				case 2012:
					return TaxingCzConstants2012.FACTOR_ADVANCES;
				case 2013:
					return TaxingCzConstants2013.FACTOR_ADVANCES;
				case 2014:
					return TaxingCzConstants2014.FACTOR_ADVANCES;
				case 2015:
					return TaxingCzConstants2015.FACTOR_ADVANCES;
				case 2016:
					return TaxingCzConstants2016.FACTOR_ADVANCES;
				default:
					return TaxingCzConstants2016.FACTOR_ADVANCES;
			}
		}

		static decimal TaxSolidaryFactor(Period period)
		{
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return TaxingCzConstants2011.FACTOR_SOLIDARY;
				case 2012:
					return TaxingCzConstants2012.FACTOR_SOLIDARY;
				case 2013:
					return TaxingCzConstants2013.FACTOR_SOLIDARY;
				case 2014:
					return TaxingCzConstants2014.FACTOR_SOLIDARY;
				case 2015:
					return TaxingCzConstants2015.FACTOR_SOLIDARY;
				case 2016:
					return TaxingCzConstants2016.FACTOR_SOLIDARY;
				default:
					return TaxingCzConstants2016.FACTOR_SOLIDARY;
			}
		}

		public static decimal TaxPayerAllowance(Period period)
		{
			if (period.Year < 2016)
			{
				return 0;
			}
			switch (period.Year)
			{
				case 2011:
					return TaxingCzConstants2011.ALLOWANCE_PAYER_BASIC;
				case 2012:
					return TaxingCzConstants2012.ALLOWANCE_PAYER_BASIC;
				case 2013:
					return TaxingCzConstants2013.ALLOWANCE_PAYER_BASIC;
				case 2014:
					return TaxingCzConstants2014.ALLOWANCE_PAYER_BASIC;
				case 2015:
					return TaxingCzConstants2015.ALLOWANCE_PAYER_BASIC;
				case 2016:
					return TaxingCzConstants2016.ALLOWANCE_PAYER_BASIC;
				default:
					return TaxingCzConstants2016.ALLOWANCE_PAYER_BASIC;
			}

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
			decimal amountForCalc = DecimalOperations.DecSuppressNegative(TAXING_SUPPRESS_NEGAT, taxableIncome);

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
			decimal taxReliefsValue = TaxPayerRelief(taxComputed, 0m, taxAllowance);

			decimal taxAdvanceValue = TaxAdvanceAfterRelief(taxComputed, taxReliefsValue, 0m);

			return taxAdvanceValue;
		}

		private static decimal TaxPayerRelief(decimal advanceBaseValue, decimal reliefValue, decimal claimsValue)
		{
			decimal taxAfterRelief = decimal.Subtract(advanceBaseValue, reliefValue);

			decimal maxAfterRelief = Math.Max(0m, decimal.Subtract(claimsValue, taxAfterRelief));

			decimal taxReliefValue = decimal.Subtract(claimsValue, maxAfterRelief);
			
			return taxReliefValue;
		}

		private static decimal TaxAdvanceAfterRelief(decimal advanceBaseValue, decimal reliefPayerValue, decimal reliefChildValue)
		{
			decimal afterRelief = Math.Max(0, advanceBaseValue - reliefPayerValue - reliefChildValue);

			return afterRelief;
		}
	}
}
