using System;
using NUnit.Framework;
using PaycheckitasLib;
using TechTalk.SpecFlow;

namespace PaycheckitasFeatures
{
	[Binding]
	public class SpecPayrollDataSteps
	{
		Period TestPeriod { get; set; }

		PayrollData TestData { get; set; }

		PayrollData ResultData { get; set; }

		decimal CaptureMoney(string money)
		{
			return decimal.Parse(money);
		}

		int CaptureHours(string hours)
		{
			return Int32.Parse(hours);
		}

		uint CaptureCount(string count)
		{
			return UInt32.Parse(count);
		}

		uint CaptureBool(string flag)
		{
			if (flag == "YES")
				return 1;
			return 0;
		}

		uint CaptureTaxes(string flag)
		{
			if (flag == "DECLARE")
				return 3;
			else if (flag == "YES")
				return 1;
			return 0;
		}

		uint Capture3bool(string flag1, string flag2, string flag3)
		{
			uint flags = 0;
			if (flag1 == "YES")
				flags += 1;
			if (flag2 == "YES")
				flags += 10;
			if (flag3 == "YES")
				flags += 100;
			return flags;
		}

		PayrollData MyTestPayrollData()
		{
			if (TestData == null)
			{
				TestData = new PayrollData();
			}
			return TestData;
		}

		void EvaluatePayroll()
		{
		}

		[Given(@"Payroll process for payroll period (\d+) (\d+)$")]
		public void GivenPayrollProcessForPayrollPeriod(string monthCode, string yearCode)
		{
			string monthParse = monthCode.TrimStart('0');
			string yearParse = yearCode.TrimStart('0');
			int monthNumber = Int32.Parse(monthParse);
			int yearNumber = Int32.Parse(yearParse);
			TestPeriod = new Period(yearNumber, monthNumber);

			MyTestPayrollData();
		}

		[Given(@"Employee works in Weekly schedule (.*) hours")]
		public void GivenEmployeeWorksInWeeklyScheduleHours(int hoursWeekly)
		{
			PayrollData target = MyTestPayrollData();
			target.WeeklyMinutes = (UInt32)TimeSheetService.HoursToMinutes(hoursWeekly);
		}

		[Given(@"Employee has (.*) hours of absence")]
		public void GivenEmployeeHasHoursOfAbsence(int hoursAbsence)
		{
			PayrollData target = MyTestPayrollData();
			target.AbsenceMinutes = (UInt32)TimeSheetService.HoursToMinutes(hoursAbsence);
		}

		[Given(@"Employee Salary is CZK (.*) monthly")]
		public void GivenEmployeeSalaryIsCZKMonthly(int salaryMonthly)
		{
			PayrollData target = MyTestPayrollData();
			target.SalaryAmount = DecimalOperations.DecimalCast(salaryMonthly);
		}

		[Given(@"Employee Bonus is (.*) percent from CZK (.*)")]
		public void GivenEmployeeBonusIsPercentFromCZK(int bonusPercent, int bonusAmount)
		{
			PayrollData target = MyTestPayrollData();
			target.BonusAmount = DecimalOperations.DecimalCast(bonusAmount);
			target.BonusProcent100 = (uint)bonusPercent*100;
		}

		[Given(@"Meal Deduction is CZK (.*)")]
		public void GivenMealDeductionIsCZK(int mealDeduction)
		{
			PayrollData target = MyTestPayrollData();
			target.MealDeduction = DecimalOperations.DecimalCast(mealDeduction);
		}
	
		[When(@"Payroll process calculate results")]
		public void WhenPayrollProcessCalculateResults()
		{
			PayrollData target = MyTestPayrollData();
			ResultData = EvaluationService.GetResults(TestPeriod, target);
		}

		[Then(@"Contribution to Health insurance should be CZK (.*)")]
		public void ThenContributionToHealthInsuranceShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.HealthInsurance);
		}

		[Then(@"Contribution to Social insurance should be CZK (.*)")]
		public void ThenContributionToSocialInsuranceShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.SocialInsurance);
		}

		[Then(@"Tax advance before tax relief on payer should be CZK (.*)")]
		public void ThenTaxAdvanceBeforeTaxReliefOnPayerShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.TaxComputed);
		}

		[Then(@"Tax relief on payer should be CZK (.*)")]
		public void ThenTaxReliefOnPayerShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.TaxAllowance);
		}

		[Then(@"Tax advance should be CZK (.*)")]
		public void ThenTaxAdvanceShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.TaxAdvance);
		}

		[Then(@"Gross income should be CZK (.*)")]
		public void ThenGrossIncomeShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.GrossIncome);
		}

		[Then(@"Netto income should be CZK (.*)")]
		public void ThenNettoIncomeShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.NetIncome);
		}

		[Then(@"Netto payment should be CZK (.*)")]
		public void ThenNettoPaymentShouldBeCZK(int expected)
		{
			decimal expectedResult = DecimalOperations.DecimalCast(expected);
			Assert.AreEqual(expectedResult, ResultData.NetPayment);
		}
	}
}
