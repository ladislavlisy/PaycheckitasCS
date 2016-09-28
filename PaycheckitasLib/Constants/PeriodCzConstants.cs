using System;

namespace PaycheckitasLib
{
	class PeriodCzConstants2011
	{
		public const Int32 DAYS_WORKING_WEEKLY = 5; 
		public const Int32 HOURS_WORKING_DAILY = 8;
	}
	class PeriodCzConstants2012
	{
		public const Int32 DAYS_WORKING_WEEKLY = PeriodCzConstants2011.DAYS_WORKING_WEEKLY; 
		public const Int32 HOURS_WORKING_DAILY = PeriodCzConstants2011.HOURS_WORKING_DAILY;
	}
	class PeriodCzConstants2013
	{ 
		public const Int32 DAYS_WORKING_WEEKLY = PeriodCzConstants2012.DAYS_WORKING_WEEKLY; 
		public const Int32 HOURS_WORKING_DAILY = PeriodCzConstants2012.HOURS_WORKING_DAILY; 
	}
	class PeriodCzConstants2014
	{ 
		public const Int32 DAYS_WORKING_WEEKLY = PeriodCzConstants2013.DAYS_WORKING_WEEKLY; 
		public const Int32 HOURS_WORKING_DAILY = PeriodCzConstants2013.HOURS_WORKING_DAILY; 
	}
	class PeriodCzConstants2015
	{ 
		public const Int32 DAYS_WORKING_WEEKLY = PeriodCzConstants2014.DAYS_WORKING_WEEKLY; 
		public const Int32 HOURS_WORKING_DAILY = PeriodCzConstants2014.HOURS_WORKING_DAILY; 
	}
	class PeriodCzConstants2016
	{ 
		public const Int32 DAYS_WORKING_WEEKLY = PeriodCzConstants2015.DAYS_WORKING_WEEKLY; 
		public const Int32 HOURS_WORKING_DAILY = PeriodCzConstants2015.HOURS_WORKING_DAILY; 
	}
}
