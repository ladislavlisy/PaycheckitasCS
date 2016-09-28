using NUnit.Framework;
using System;
using PaycheckitasLib;

namespace PaycheckitasTest
{
	[TestFixture()]
	public class TestPayrollData
	{
		PayrollData testPayrollData;

		Period testPeriod;

		[SetUp]
		public void Init()
		{
			testPeriod = new Period(2016, 1);

			testPayrollData = new PayrollData();
			//Úvazek týden		40
			testPayrollData.WeeklyMinutes = (uint)TimeSheetService.HoursToMinutes(40m);
			//Úvazek měsíc		168
			//Salary Amount		12_345
			testPayrollData.SalaryAmount = 12345m;
			//Bonus Amount		98_765
			testPayrollData.BonusAmount = 98765m;
			//Bonus Factor		33_00
			testPayrollData.BonusProcent100 = 3300;
			//Result Salary		12_345
			//Hrubá mzda		44_937
			//SocPoj			2_921
			//ZdrPoj			2_023
			//Daň vypočtená		9_045
			//Daň sražená		6_975
			//Srážka Stravné	321
			testPayrollData.MealDeduction = 321m;
			//Čistá mzda		33_018
			//Celkem k výplatě	32_697
		}

		[TearDown]
		public void Cleanup()
		{
		}
		[Test()]
		public void TestWorkingHours_ShouldBe_168()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(168m, resultData.WorkingHours());
		}
		[Test()]
		public void TestWorkedHours_ShouldBe_168()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(168m, resultData.WorkedHours());
		}
		[Test()]
		public void TestAbsenceHours_ShouldBe_0()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(0m, resultData.AbsenceHours());
		}
		[Test()]
		public void TestSalaryAmount_ShouldBe_12_345()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(12345m, resultData.SalaryAmount);
		}
		[Test()]
		public void TestBonusAmount_ShouldBe_98_765()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(98765m, resultData.BonusAmount);
		}
		[Test()]
		public void TestBonusProcent100_ShouldBe_33_00()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(33m, resultData.BonusFactor());
		}
		[Test()]
		public void TestTaxComputed_ShouldBe_9_045()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(9045m, resultData.TaxComputed);
		}
		[Test()]
		public void TestTaxAllowance_ShouldBe_2_070()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(2070m, resultData.TaxAllowance);
		}
		[Test()]
		public void TestTaxAdvance_ShouldBe_6_975()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(6975m, resultData.TaxAdvance);
		}
		[Test()]
		public void TestHealthInsurance_ShouldBe_2_023()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(2023m, resultData.HealthInsurance);
		}
		[Test()]
		public void TestSocialInsurance_ShouldBe_2_921()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(2921m, resultData.SocialInsurance);
		}
		[Test()]
		public void TestGrossIncome_ShouldBe_44_937()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(44937m, resultData.GrossIncome);
		}
		[Test()]
		public void TestNetIncome_ShouldBe_33_018()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(33018m, resultData.NetIncome);
		}
		[Test()]
		public void TestMealDeduction_ShouldBe_321()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(321m, resultData.MealDeduction);
		}
		[Test()]
		public void TestNetPayment_ShouldBe_32_697()
		{
			PayrollData resultData = EvaluationService.GetResults(testPeriod, testPayrollData);
			Assert.AreEqual(32697m, resultData.NetPayment);
		}
	}
}
