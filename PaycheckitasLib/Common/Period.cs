using System;
namespace PaycheckitasLib
{   
	public class Period
	{
		public int Month { get; set; }
		public int Year { get; set; }

		public Period ()
		{
			this.Year = 0;
			this.Month = 0;
		}

		public Period (int year, int month)
		{
			this.Year = year;
			this.Month = month;
		}

		public bool IsNull ()
		{
			return (this.Month == 0 || this.Year == 0);
		}

		public int PeriodCode ()
		{
			if (IsNull ()) {
				return 0;
			}
			return this.Year * 100 + this.Month;
		}

		public string Description ()
		{
			DateTime firstPeriodDay = new DateTime (Year, Month, 1);
			return firstPeriodDay.ToString ("MMMM yyyy");
		}

	}
}
