using System;
namespace PaycheckitasLib
{
	public static class PeriodService
	{
		public const int WEEKSUN_SUNDAY = 0;

		public const int WEEKMON_SUNDAY = 7;

		public static int DayOfWeekFromOrdinal (int dayOrdinal, int periodBeginCwd)
		{
			// dayOrdinal 1..31
			// periodBeginCwd 1..7
			// dayOfWeek 1..7

			int dayOfWeek = (((dayOrdinal - 1) + (periodBeginCwd - 1)) % 7) + 1;

			return dayOfWeek;
		}

		public static int DayOfWeekMonToSun (int periodDateCwd)
		{
			// DayOfWeek Sunday = 0,
			// Monday = 1, Tuesday = 2, Wednesday = 3, Thursday = 4, Friday = 5, Saturday = 6, 
			if (periodDateCwd == WEEKSUN_SUNDAY) {
				return WEEKMON_SUNDAY;
			} else {
				return periodDateCwd;
			}
		}

		public static DateTime? BeginOfMonth (Period period)
		{
			if (period.IsNull ()) {
				return null;
			}
			DateTime beginOfPeriod = new DateTime (period.Year, period.Month, 1);

			return beginOfPeriod;
		}

		public static DateTime? EndOfMonth (Period period)
		{
			if (period.IsNull ()) {
				return null;
			}
			DateTime beginOfPeriod = new DateTime (period.Year, period.Month, DaysInMonth (period));

			return beginOfPeriod;
		}

		public static int DaysInMonth (Period period)
		{
			if (period.IsNull ()) {
				return 0;
			}
			return DateTime.DaysInMonth (period.Year, period.Month);
		}

		public static DateTime? DateOfMonth (Period period, int dayOrdinal)
		{
			if (period.IsNull ()) {
				return null;
			}
			int periodDay = Math.Min (Math.Max (1, dayOrdinal), DaysInMonth (period));

			return new DateTime (period.Year, period.Month, periodDay);
		}

		public static int WeekDayOfMonth (Period period, int dayOrdinal)
		{
			DateTime? periodDate = DateOfMonth (period, dayOrdinal);

			if (!periodDate.HasValue) {
				return 0;
			}
			int periodDateCwd = (int)periodDate?.DayOfWeek;

			return DayOfWeekMonToSun (periodDateCwd);
		}
	}
}
