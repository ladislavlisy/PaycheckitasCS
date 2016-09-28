using System;
namespace PaycheckitasLib
{
	class HealthCzConstants2011
	{
		public static readonly decimal FACTOR_EMPLOYEE = 4.5m;
		public static readonly decimal FACTOR_EMPLOYER = 9m;
		public static readonly decimal FACTOR_COMPOUND = FACTOR_EMPLOYEE + FACTOR_EMPLOYER;
		public static readonly decimal MINIM_YEAR_BASE = 0m;
		public static readonly decimal MAXIM_YEAR_BASE = 0m;
	}

	class HealthCzConstants2012
	{
		public static readonly decimal FACTOR_EMPLOYEE = HealthCzConstants2011.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = HealthCzConstants2011.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_COMPOUND = HealthCzConstants2011.FACTOR_COMPOUND;
		public static readonly decimal MINIM_YEAR_BASE = HealthCzConstants2011.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = HealthCzConstants2011.MAXIM_YEAR_BASE;
	}

	class HealthCzConstants2013
	{
		public static readonly decimal FACTOR_EMPLOYEE = HealthCzConstants2012.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = HealthCzConstants2012.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_COMPOUND = HealthCzConstants2012.FACTOR_COMPOUND;
		public static readonly decimal MINIM_YEAR_BASE = HealthCzConstants2012.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = HealthCzConstants2012.MAXIM_YEAR_BASE;
	}

	class HealthCzConstants2014
	{
		public static readonly decimal FACTOR_EMPLOYEE = HealthCzConstants2013.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = HealthCzConstants2013.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_COMPOUND = HealthCzConstants2013.FACTOR_COMPOUND;
		public static readonly decimal MINIM_YEAR_BASE = HealthCzConstants2013.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = HealthCzConstants2013.MAXIM_YEAR_BASE;
	}
	class HealthCzConstants2015
	{
		public static readonly decimal FACTOR_EMPLOYEE = HealthCzConstants2014.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = HealthCzConstants2014.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_COMPOUND = HealthCzConstants2014.FACTOR_COMPOUND;
		public static readonly decimal MINIM_YEAR_BASE = HealthCzConstants2014.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = HealthCzConstants2014.MAXIM_YEAR_BASE;
	}
	class HealthCzConstants2016
	{
		public static readonly decimal FACTOR_EMPLOYEE = HealthCzConstants2015.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = HealthCzConstants2015.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_COMPOUND = HealthCzConstants2015.FACTOR_COMPOUND;
		public static readonly decimal MINIM_YEAR_BASE = HealthCzConstants2015.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = HealthCzConstants2015.MAXIM_YEAR_BASE;
	}
}
