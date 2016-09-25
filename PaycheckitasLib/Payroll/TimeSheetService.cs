using System;
using System.Linq;

namespace PaycheckitasLib
{
	public static class TimeSheetService
	{
		public const Int32 TIME_MULTIPLY_SIXTY = 60;

		public static int HoursToSeconds (decimal hours)
		{
			return RoundingOperations.RoundToInt (DecimalOperations.Multiply (hours, TIME_MULTIPLY_SIXTY * TIME_MULTIPLY_SIXTY));
		}

		public static Int32 [] WeekSchedule (Int32 secondsWeekly, Int32 workdaysWeekly)
		{
			Int32 secondsDaily = (secondsWeekly / Math.Min (workdaysWeekly, 7));

			Int32 secRemainder = secondsWeekly - (secondsDaily * workdaysWeekly);

			Int32 [] weekSchedule = Enumerable.Range (1, 7).
				Select ((x) => (WeekDaySeconds (x, workdaysWeekly, secondsDaily, secRemainder))).ToArray ();

			return weekSchedule;
		}

		private static Int32 WeekDaySeconds (int dayOrdinal, int daysOfWork, Int32 secondsDaily, Int32 secRemainder)
		{
			if (dayOrdinal < daysOfWork) {
				return secondsDaily;
			} else if (dayOrdinal == daysOfWork) {
				return secondsDaily + secRemainder;
			}
			return (0);
		}

		public static int WorkingSecondsDaily (int workingHours)
		{
			Int32 secondsInHour = (TIME_MULTIPLY_SIXTY * TIME_MULTIPLY_SIXTY);

			return (workingHours * secondsInHour);
		}

		public static Int32 [] MonthSchedule (Period period, Int32 [] weekSchedule)
		{
			int periodDaysCount = PeriodService.DaysInMonth (period);

			int periodBeginCwd = PeriodService.WeekDayOfMonth (period, 1);

			Int32 [] monthSchedule = Enumerable.Range (1, periodDaysCount).
				Select ((x) => (SecondsFromWeekSchedule (period, weekSchedule, x, periodBeginCwd))).ToArray ();

			return monthSchedule;
		}

		private static Int32 SecondsFromWeekSchedule (Period period, Int32 [] weekSchedule, int dayOrdinal, int periodBeginCwd)
		{
			int dayOfWeek = PeriodService.DayOfWeekFromOrdinal (dayOrdinal, periodBeginCwd);

			int indexWeek = (dayOfWeek - 1);

			if (indexWeek < 0 || indexWeek >= weekSchedule.Length) {
				return 0;
			}
			return weekSchedule [indexWeek];
		}

		public static Int32 TotalTimesheetHours (Int32 [] monthTimesheet)
		{
			if (monthTimesheet == null) {
				return 0;
			}
			Int32 timesheetHours = monthTimesheet.Aggregate (0, (agr, dh) => (agr + dh));

			return timesheetHours;
		}
	}
}
