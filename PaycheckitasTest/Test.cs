using NUnit.Framework;
using System;
using PaycheckitasLib;

namespace PaycheckitasTest
{
	[TestFixture ()]
	public class TestPayrollData
	{
		[Test ()]
		public void TestWorkingHoursShouldBe_Zero_At_Start ()
		{
			PayrollData data = new PayrollData ();
			Assert.AreEqual (0m, data.WorkedHours ());
		}
	}
}
