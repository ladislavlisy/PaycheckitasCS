using System;
namespace PaycheckitasLib
{
	public static class EvaluationService
	{
		public static PayrollData GetResults(Period monthPeriod, PayrollData targets)
		{
			PayrollData results = new PayrollData();

			results.WorkingMinutes = (UInt32) TimeSheetService.TotalWorkingHours(monthPeriod, targets.WeeklyHours());

			results.WorkedMinutes = results.WorkingMinutes;

			results.AbsenceMinutes = targets.AbsenceMinutes;

			results.SalaryAmount = targets.SalaryAmount;
			results.SalaryResult = PayrollService.SalaryResult(monthPeriod, results.SalaryAmount, results.WorkingMinutes, results.WorkedMinutes);

			results.BonusAmount = targets.BonusAmount;
			results.BonusProcent100 = targets.BonusProcent100;
			results.BonusResult = PayrollService.BonusResult(results.BonusAmount, results.BonusFactor());

			decimal generalBasis = results.SalaryResult + results.BonusResult;
			results.TaxComputed = TaxingService.TaxComputedResult(monthPeriod, generalBasis);

			results.TaxAllowance = TaxingService.TaxPayerAllowance(monthPeriod);

			results.TaxAdvance = TaxingService.TaxAdvanceResult(monthPeriod, results.TaxComputed, results.TaxAllowance);

			results.HealthInsurance = HealthService.HealthInsuranceResult(monthPeriod, generalBasis);

			results.SocialInsurance = SocialService.SocialInsuranceResult(monthPeriod, generalBasis);

			results.GrossIncome = results.SalaryResult + results.BonusResult;

			results.NetIncome = results.GrossIncome - results.TaxAdvance - results.HealthInsurance - results.SocialInsurance;

			results.MealDeduction = targets.MealDeduction;

			results.NetPayment = results.NetIncome - results.MealDeduction;

			return results;
		}
	}
}
