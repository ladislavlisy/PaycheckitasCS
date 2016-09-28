using System;
namespace PaycheckitasLib
{
	class TaxesCzConstants2011
	{
		public static readonly long BENEFIT_PAYER = 1970;

		public static readonly long BENEFIT_DISABILITY_1 = 210;
		public static readonly long BENEFIT_DISABILITY_2 = 420;
		public static readonly long BENEFIT_DISABILITY_3 = 1345;

		public static readonly long BENEFIT_STUDYING = 335;
		public static readonly long BENEFIT_CHILD = 967;

		public static readonly long BRACKET_MAX_WITHHOLD = 5000;
		public static readonly decimal FACTOR_ADVANCE = 15.0m;
		public static readonly decimal FACTOR_WITHHOLD = 15.0m;

		public static readonly bool IS_SMALLER_ROUND_UP = true;
		public static readonly long BRACKET_MAX_SMALLER = 100;

		public static readonly bool IS_ZERO_SOLIDARY_TAX = true;
		public static readonly decimal FACTOR_SOLIDARY = 0m;
		public static readonly long BRACKET_MAX_SOLIDARY = 0;
	}

	class TaxesCzConstants2012
	{
		public static readonly long BENEFIT_PAYER = 2070;

		public static readonly long BENEFIT_DISABILITY_1 = TaxesCzConstants2011.BENEFIT_DISABILITY_1;
		public static readonly long BENEFIT_DISABILITY_2 = TaxesCzConstants2011.BENEFIT_DISABILITY_2;
		public static readonly long BENEFIT_DISABILITY_3 = TaxesCzConstants2011.BENEFIT_DISABILITY_3;

		public static readonly long BENEFIT_STUDYING = TaxesCzConstants2011.BENEFIT_STUDYING;
		public static readonly long BENEFIT_CHILD = 1117;

		public static readonly long BRACKET_MAX_WITHHOLD = TaxesCzConstants2011.BRACKET_MAX_WITHHOLD;
		public static readonly decimal FACTOR_ADVANCE = TaxesCzConstants2011.FACTOR_ADVANCE;
		public static readonly decimal FACTOR_WITHHOLD = TaxesCzConstants2011.FACTOR_WITHHOLD;

		public static readonly bool IS_SMALLER_ROUND_UP = TaxesCzConstants2011.IS_SMALLER_ROUND_UP;
		public static readonly long BRACKET_MAX_SMALLER = TaxesCzConstants2011.BRACKET_MAX_SMALLER;

		public static readonly bool IS_ZERO_SOLIDARY_TAX = TaxesCzConstants2011.IS_ZERO_SOLIDARY_TAX;
		public static readonly decimal FACTOR_SOLIDARY = TaxesCzConstants2011.FACTOR_SOLIDARY;
		public static readonly long BRACKET_MAX_SOLIDARY = TaxesCzConstants2011.BRACKET_MAX_SOLIDARY;
	}

	class TaxesCzConstants2013
	{
		public static readonly long BENEFIT_PAYER = TaxesCzConstants2012.BENEFIT_PAYER;

		public static readonly long BENEFIT_DISABILITY_1 = TaxesCzConstants2012.BENEFIT_DISABILITY_1;
		public static readonly long BENEFIT_DISABILITY_2 = TaxesCzConstants2012.BENEFIT_DISABILITY_2;
		public static readonly long BENEFIT_DISABILITY_3 = TaxesCzConstants2012.BENEFIT_DISABILITY_3;

		public static readonly long BENEFIT_STUDYING = TaxesCzConstants2012.BENEFIT_STUDYING;
		public static readonly long BENEFIT_CHILD = TaxesCzConstants2012.BENEFIT_CHILD;

		public static readonly long BRACKET_MAX_WITHHOLD = TaxesCzConstants2012.BRACKET_MAX_WITHHOLD;
		public static readonly decimal FACTOR_ADVANCE = TaxesCzConstants2012.FACTOR_ADVANCE;
		public static readonly decimal FACTOR_WITHHOLD = TaxesCzConstants2012.FACTOR_WITHHOLD;

		public static readonly bool IS_SMALLER_ROUND_UP = TaxesCzConstants2012.IS_SMALLER_ROUND_UP;
		public static readonly long BRACKET_MAX_SMALLER = TaxesCzConstants2012.BRACKET_MAX_SMALLER;

		public static readonly bool IS_ZERO_SOLIDARY_TAX = false;
		public static readonly decimal FACTOR_SOLIDARY = 7.0m;
		public static readonly long BRACKET_MAX_SOLIDARY = (4 * 25884);
	}

	class TaxesCzConstants2014
	{
		public static readonly long BENEFIT_PAYER = TaxesCzConstants2013.BENEFIT_PAYER;

		public static readonly long BENEFIT_DISABILITY_1 = TaxesCzConstants2013.BENEFIT_DISABILITY_1;
		public static readonly long BENEFIT_DISABILITY_2 = TaxesCzConstants2013.BENEFIT_DISABILITY_2;
		public static readonly long BENEFIT_DISABILITY_3 = TaxesCzConstants2013.BENEFIT_DISABILITY_3;

		public static readonly long BENEFIT_STUDYING = TaxesCzConstants2013.BENEFIT_STUDYING;
		public static readonly long BENEFIT_CHILD = TaxesCzConstants2013.BENEFIT_CHILD;

		public static readonly long BRACKET_MAX_WITHHOLD = TaxesCzConstants2013.BRACKET_MAX_WITHHOLD;
		public static readonly decimal FACTOR_ADVANCE = TaxesCzConstants2013.FACTOR_ADVANCE;
		public static readonly decimal FACTOR_WITHHOLD = TaxesCzConstants2013.FACTOR_WITHHOLD;

		public static readonly bool IS_SMALLER_ROUND_UP = TaxesCzConstants2013.IS_SMALLER_ROUND_UP;
		public static readonly long BRACKET_MAX_SMALLER = TaxesCzConstants2013.BRACKET_MAX_SMALLER;

		public static readonly bool IS_ZERO_SOLIDARY_TAX = TaxesCzConstants2013.IS_ZERO_SOLIDARY_TAX;
		public static readonly decimal FACTOR_SOLIDARY = TaxesCzConstants2013.FACTOR_SOLIDARY;
		public static readonly long BRACKET_MAX_SOLIDARY = (4 * 25942);
	}

	class TaxesCzConstants2015
	{
		public static readonly long BENEFIT_PAYER = TaxesCzConstants2013.BENEFIT_PAYER;

		public static readonly long BENEFIT_DISABILITY_1 = TaxesCzConstants2014.BENEFIT_DISABILITY_1;
		public static readonly long BENEFIT_DISABILITY_2 = TaxesCzConstants2014.BENEFIT_DISABILITY_2;
		public static readonly long BENEFIT_DISABILITY_3 = TaxesCzConstants2014.BENEFIT_DISABILITY_3;

		public static readonly long BENEFIT_STUDYING = TaxesCzConstants2014.BENEFIT_STUDYING;
		public static readonly long BENEFIT_CHILD = TaxesCzConstants2014.BENEFIT_CHILD;

		public static readonly long BRACKET_MAX_WITHHOLD = TaxesCzConstants2014.BRACKET_MAX_WITHHOLD;
		public static readonly decimal FACTOR_ADVANCE = TaxesCzConstants2014.FACTOR_ADVANCE;
		public static readonly decimal FACTOR_WITHHOLD = TaxesCzConstants2014.FACTOR_WITHHOLD;

		public static readonly bool IS_SMALLER_ROUND_UP = TaxesCzConstants2014.IS_SMALLER_ROUND_UP;
		public static readonly long BRACKET_MAX_SMALLER = TaxesCzConstants2014.BRACKET_MAX_SMALLER;

		public static readonly bool IS_ZERO_SOLIDARY_TAX = TaxesCzConstants2014.IS_ZERO_SOLIDARY_TAX;
		public static readonly decimal FACTOR_SOLIDARY = TaxesCzConstants2014.FACTOR_SOLIDARY;
		public static readonly long BRACKET_MAX_SOLIDARY = (4 * 25942);
	}

	class TaxesCzConstants2016
	{
		public static readonly long BENEFIT_PAYER = TaxesCzConstants2015.BENEFIT_PAYER;

		public static readonly long BENEFIT_DISABILITY_1 = TaxesCzConstants2015.BENEFIT_DISABILITY_1;
		public static readonly long BENEFIT_DISABILITY_2 = TaxesCzConstants2015.BENEFIT_DISABILITY_2;
		public static readonly long BENEFIT_DISABILITY_3 = TaxesCzConstants2015.BENEFIT_DISABILITY_3;

		public static readonly long BENEFIT_STUDYING = TaxesCzConstants2015.BENEFIT_STUDYING;
		public static readonly long BENEFIT_CHILD = TaxesCzConstants2015.BENEFIT_CHILD;

		public static readonly long BRACKET_MAX_WITHHOLD = TaxesCzConstants2015.BRACKET_MAX_WITHHOLD;
		public static readonly decimal FACTOR_ADVANCE = TaxesCzConstants2015.FACTOR_ADVANCE;
		public static readonly decimal FACTOR_WITHHOLD = TaxesCzConstants2015.FACTOR_WITHHOLD;

		public static readonly bool IS_SMALLER_ROUND_UP = TaxesCzConstants2015.IS_SMALLER_ROUND_UP;
		public static readonly long BRACKET_MAX_SMALLER = TaxesCzConstants2015.BRACKET_MAX_SMALLER;

		public static readonly bool IS_ZERO_SOLIDARY_TAX = TaxesCzConstants2015.IS_ZERO_SOLIDARY_TAX;
		public static readonly decimal FACTOR_SOLIDARY = TaxesCzConstants2015.FACTOR_SOLIDARY;
		public static readonly long BRACKET_MAX_SOLIDARY = (4 * 25942);
	}
}
