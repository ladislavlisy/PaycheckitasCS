using System;
namespace PaycheckitasLib
{
	public class PayrollData
	{
		public const Int32 TIME_MULTIPLY_SIXTY = 60;

		public UInt32 Period {get; set;}

		public UInt32 WeeklyMinutes { get; set; }
		public UInt32 WeeklyWorkDays { get; set; }
		public UInt32 WorkingMinutes {get; set;}
		public UInt32 WorkedMinutes {get; set;}
		public UInt32 AbsenceMinutes {get; set;}
		public decimal SalaryAmount {get; set;}
		public decimal BonusAmount {get; set;}
		public UInt32 BonusProcent100 {get; set;}
		public decimal TaxComputed {get; set;}
		public decimal TaxAllowance {get; set;}
		public decimal TaxAdvance {get; set;}
		public decimal HealthInsurance {get; set;}
		public decimal SocialInsurance { get; set; }
		public decimal GrossIncome {get; set;}
		public decimal NetIncome {get; set;}
		public decimal MealDeduction { get; set; }
		public decimal NetPayment {get; set;}

		public decimal SalaryResult { get; set; }
		public decimal BonusResult { get; set; }

		public PayrollData ()
		{
			WeeklyMinutes  = 0;
			WeeklyWorkDays = 0;
			WorkingMinutes = 0;
			WorkedMinutes = 0;
			AbsenceMinutes = 0;
			SalaryAmount = 0; 
			BonusAmount = 0;
			BonusProcent100 = 0;
			TaxComputed = 0;
			TaxAllowance = 0;
			TaxAdvance = 0; 
			HealthInsurance = 0;
			SocialInsurance = 0;
			GrossIncome = 0;
			NetIncome = 0;
			MealDeduction = 0;
			NetPayment = 0;

			SalaryResult = 0m;
			BonusResult = 0m;
		}

		public decimal WeeklyHours()
		{
			return DecimalOperations.Divide(WeeklyMinutes, TIME_MULTIPLY_SIXTY);
		}

		public decimal WorkingHours ()
		{
			return DecimalOperations.Divide(WorkingMinutes, TIME_MULTIPLY_SIXTY);
		}

		public decimal WorkedHours ()
		{
			return DecimalOperations.Divide(WorkedMinutes, TIME_MULTIPLY_SIXTY);
		}

		public decimal AbsenceHours ()
		{
			return DecimalOperations.Divide(AbsenceMinutes, TIME_MULTIPLY_SIXTY);
		}

		public decimal BonusFactor ()
		{
			return DecimalOperations.Divide (BonusProcent100, 100m);
		}
	}
}
