using NUnit.Framework;
using System;
using PaycheckitasLib;

namespace PaycheckitasTest
{
	[TestFixture()]
	public class TestPayrollData
	{
		//Jmeno 			Cross Petra
		//Úvazek týden		40
		//Úvazek měsíc		168
		//Salary Amount		12_345
		//Bonus Amount		98_765
		//Bonus Factor		33_00
		//Result Salary		12_345
		//Hrubá mzda		44_937
		//SocPoj			2_921
		//ZdrPoj			2_023
		//Daň vypočtená		9_045
		//Daň sražená		6_975
		//Srážka Stravné	321
		//Čistá mzda		33_018
		//Celkem k výplatě	32_697
		[Test()]
		public void TestWorkingHours_ShouldBe_168()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.WorkingHours());
		}
		[Test()]
		public void TestWorkedHours_ShouldBe_168()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.WorkedHours());
		}
		[Test()]
		public void TestAbsenceHours_ShouldBe_0()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.AbsenceHours());
		}
		[Test()]
		public void TestSalaryAmount_ShouldBe_12_345()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.SalaryAmount);
		}
		[Test()]
		public void TestBonusAmount_ShouldBe_98_765()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.BonusAmount);
		}
		[Test()]
		public void TestBonusProcent100_ShouldBe_33_00()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.BonusFactor());
		}
		[Test()]
		public void TestTaxComputed_ShouldBe_9_045()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.TaxComputed);
		}
		[Test()]
		public void TestTaxAllowance_ShouldBe_2_070()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.TaxAllowance);
		}
		[Test()]
		public void TestTaxAdvance_ShouldBe_6_975()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.TaxAdvance);
		}
		[Test()]
		public void TestHealthInsurance_ShouldBe_2_023()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.HealthInsurance);
		}
		[Test()]
		public void TestSocialInsurance_ShouldBe_2_921()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.SocialInsurance);
		}
		[Test()]
		public void TestGrossIncome_ShouldBe_44_937()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.GrossIncome);
		}
		[Test()]
		public void TestNetIncome_ShouldBe_33_018()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.NetIncome);
		}
		[Test()]
		public void TestMealDeduction_ShouldBe_321()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.MealDeduction);
		}
		[Test()]
		public void TestNetPayment_ShouldBe_32_697()
		{
			PayrollData data = new PayrollData();
			Assert.AreEqual(0m, data.NetPayment);
		}
	}
}
