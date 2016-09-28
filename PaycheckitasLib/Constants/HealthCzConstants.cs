using System;

namespace PaycheckitasLib
{
	class HealthCzConstants2011
	{ 
		public const uint YEAR_2011 = 2011; 
		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 0; 
		public const Int32 BASIS_MANDATORY = 8000; 
		public const decimal BASIS_ANNUAL_MAXIMUM = 1781280m; 
		public const decimal FACTOR_COMPOUND = 13.5m; 
		public const decimal INCOME_EMPLOY_MARGINAL = 2000m; 
		public const decimal INCOME_AGREEM_MARGINAL = 10000m; 
	}
	class HealthCzConstants2012
	{ 
		public const uint YEAR_2012 = 2012; 
		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 0; 
		public const Int32 BASIS_MANDATORY = HealthCzConstants2011.BASIS_MANDATORY; 
		public const decimal BASIS_ANNUAL_MAXIMUM = 1809864m; 
		public const decimal FACTOR_COMPOUND = HealthCzConstants2011.FACTOR_COMPOUND; 
		public const decimal INCOME_EMPLOY_MARGINAL = 2500m; 
		public const decimal INCOME_AGREEM_MARGINAL = 10000m; 
	}
	class HealthCzConstants2013
	{ 
		public const uint YEAR_2013 = 2013; 
		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 8000; 
		public const Int32 BASIS_MANDATORY = 8500; 
		public const decimal BASIS_ANNUAL_MAXIMUM = 0m; 
		public const decimal FACTOR_COMPOUND = HealthCzConstants2012.FACTOR_COMPOUND; 
		public const decimal INCOME_EMPLOY_MARGINAL = HealthCzConstants2012.INCOME_EMPLOY_MARGINAL; 
		public const decimal INCOME_AGREEM_MARGINAL = HealthCzConstants2012.INCOME_AGREEM_MARGINAL; 
	}
	class HealthCzConstants2014
	{ 
		public const uint YEAR_2014 = 2014; 
		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 0; 
		public const Int32 BASIS_MANDATORY = 8500; 
		public const decimal BASIS_ANNUAL_MAXIMUM = HealthCzConstants2013.BASIS_ANNUAL_MAXIMUM; 
		public const decimal FACTOR_COMPOUND = HealthCzConstants2013.FACTOR_COMPOUND; 
		public const decimal INCOME_EMPLOY_MARGINAL = HealthCzConstants2013.INCOME_EMPLOY_MARGINAL; 
		public const decimal INCOME_AGREEM_MARGINAL = HealthCzConstants2013.INCOME_AGREEM_MARGINAL; 
	}
	class HealthCzConstants2015
	{ 
		public const uint YEAR_2015 = 2015; 
		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 0; 
		public const Int32 BASIS_MANDATORY = 9200; 
		public const decimal BASIS_ANNUAL_MAXIMUM = HealthCzConstants2014.BASIS_ANNUAL_MAXIMUM; 
		public const decimal FACTOR_COMPOUND = HealthCzConstants2014.FACTOR_COMPOUND; 
		public const decimal INCOME_EMPLOY_MARGINAL = HealthCzConstants2014.INCOME_EMPLOY_MARGINAL; 
		public const decimal INCOME_AGREEM_MARGINAL = HealthCzConstants2014.INCOME_AGREEM_MARGINAL; 
	}
	class HealthCzConstants2016
	{ 
		public const uint YEAR_2016 = 2016; 
		public const Int32 BASIS_MANDATORY_FROM_01_TO_07 = 0; 
		public const Int32 BASIS_MANDATORY = 9900; 
		public const decimal BASIS_ANNUAL_MAXIMUM = HealthCzConstants2015.BASIS_ANNUAL_MAXIMUM; 
		public const decimal FACTOR_COMPOUND = HealthCzConstants2015.FACTOR_COMPOUND; 
		public const decimal INCOME_EMPLOY_MARGINAL = HealthCzConstants2015.INCOME_EMPLOY_MARGINAL; 
		public const decimal INCOME_AGREEM_MARGINAL = HealthCzConstants2015.INCOME_AGREEM_MARGINAL; 
	}
}
