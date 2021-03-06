﻿using NUnit.Framework;
using System;
using PaycheckitasLib;

namespace PaycheckitasTest
{
	[TestFixture ()]
	public class TestPayrollStart
	{
		[Test ()]
		public void TestWorkingHours_ShouldBe_Zero_At_Start ()
		{
			PayrollData data = new PayrollData ();
			Assert.AreEqual (0m, data.WorkedHours ());
		}
		[Test ()]
		public void TestSalaryResult_ShouldBe_10_000_For_10_000_Amount ()
		{
			Period period = new Period (2016, 1);

			UInt32 workingHours = (UInt32)PayrollService.WorkingHoursResult(period, 40);

			Assert.AreEqual (10000m, PayrollService.SalaryResult (period, 10000m, workingHours, workingHours));
		}
	}
}
