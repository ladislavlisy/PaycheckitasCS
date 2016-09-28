using System;
using System.Linq;

namespace PaycheckitasLib
{
	public static class PayrollService
	{
		public static int WorkingHoursResult (Period period, UInt32 weeklyHours)
		{
			Int32 secondsWeekly = TimeSheetService.HoursToMinutes(weeklyHours);

			Int32 workdaysWeekly = 5;

			Int32 [] weekSchedule = TimeSheetService.WeekSchedule (secondsWeekly, workdaysWeekly);

			Int32 [] monthSchedule = TimeSheetService.MonthSchedule (period, weekSchedule);

			int timesheetHours = TimeSheetService.TotalTimesheetHours (monthSchedule);

			return timesheetHours;
		}

		public static decimal SalaryResult (Period period, decimal salaryAmount, UInt32 workingHours, UInt32 workedHours)
		{
			decimal scheduleFactor = 1.0m;

			decimal amountFactor = DecimalOperations.Multiply (salaryAmount, scheduleFactor);

			UInt32 salariedHours = Math.Max (0, workedHours);

			decimal salaryResult = DecimalOperations.MultiplyAndDivide(salariedHours, amountFactor, workingHours);

			return RoundingOperations.RoundToCZK(salaryResult);
		}

		public static decimal BonusResult (decimal bonusAmount, decimal bonusFactor)
		{
			decimal bonusResult = DecimalOperations.MultiplyAndDivide (bonusAmount, bonusFactor, 100m);

			return RoundingOperations.RoundToCZK (bonusResult);
		}

	}
}
