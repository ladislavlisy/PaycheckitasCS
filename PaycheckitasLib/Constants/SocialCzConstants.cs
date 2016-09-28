using System;
namespace PaycheckitasLib
{
	class SocialCzConstants2011
	{
		public static readonly decimal FACTOR_EMPLOYEE = 6.5m;
		public static readonly decimal FACTOR_EMPLOYER = 25m;
		public static readonly decimal FACTOR_EXEMPTION_RAISE = 1m;
		public static readonly decimal FACTOR_PENSIONS_REDUCE = 0m;
		public static readonly decimal MINIM_YEAR_BASE = 0m;
		public static readonly decimal MAXIM_YEAR_BASE = 0m;
	}

	class SocialCzConstants2012
	{
		public static readonly decimal FACTOR_EMPLOYEE = SocialCzConstants2011.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = SocialCzConstants2011.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_EXEMPTION_RAISE = SocialCzConstants2011.FACTOR_EXEMPTION_RAISE;
		public static readonly decimal FACTOR_PENSIONS_REDUCE = SocialCzConstants2011.FACTOR_PENSIONS_REDUCE;
		public static readonly decimal MINIM_YEAR_BASE = SocialCzConstants2011.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = SocialCzConstants2011.MAXIM_YEAR_BASE;
	}

	class SocialCzConstants2013
	{
		public static readonly decimal FACTOR_EMPLOYEE = SocialCzConstants2012.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = SocialCzConstants2012.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_EXEMPTION_RAISE = SocialCzConstants2012.FACTOR_EXEMPTION_RAISE;
		public static readonly decimal FACTOR_PENSIONS_REDUCE = 3m;
		public static readonly decimal MINIM_YEAR_BASE = SocialCzConstants2012.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = SocialCzConstants2012.MAXIM_YEAR_BASE;
	}

	class SocialCzConstants2014
	{
		public static readonly decimal FACTOR_EMPLOYEE = SocialCzConstants2013.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = SocialCzConstants2013.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_EXEMPTION_RAISE = SocialCzConstants2013.FACTOR_EXEMPTION_RAISE;
		public static readonly decimal FACTOR_PENSIONS_REDUCE = SocialCzConstants2013.FACTOR_PENSIONS_REDUCE;
		public static readonly decimal MINIM_YEAR_BASE = SocialCzConstants2013.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = SocialCzConstants2013.MAXIM_YEAR_BASE;
	}

	class SocialCzConstants2015
	{
		public static readonly decimal FACTOR_EMPLOYEE = SocialCzConstants2014.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = SocialCzConstants2014.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_EXEMPTION_RAISE = SocialCzConstants2014.FACTOR_EXEMPTION_RAISE;
		public static readonly decimal FACTOR_PENSIONS_REDUCE = SocialCzConstants2014.FACTOR_PENSIONS_REDUCE;
		public static readonly decimal MINIM_YEAR_BASE = SocialCzConstants2014.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = SocialCzConstants2014.MAXIM_YEAR_BASE;
	}

	class SocialCzConstants2016
	{
		public static readonly decimal FACTOR_EMPLOYEE = SocialCzConstants2015.FACTOR_EMPLOYEE;
		public static readonly decimal FACTOR_EMPLOYER = SocialCzConstants2015.FACTOR_EMPLOYER;
		public static readonly decimal FACTOR_EXEMPTION_RAISE = SocialCzConstants2015.FACTOR_EXEMPTION_RAISE;
		public static readonly decimal FACTOR_PENSIONS_REDUCE = SocialCzConstants2015.FACTOR_PENSIONS_REDUCE;
		public static readonly decimal MINIM_YEAR_BASE = SocialCzConstants2015.MINIM_YEAR_BASE;
		public static readonly decimal MAXIM_YEAR_BASE = SocialCzConstants2015.MAXIM_YEAR_BASE;
	}
}
