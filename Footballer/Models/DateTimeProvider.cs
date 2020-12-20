using System;
using System.Collections.Generic;
using System.Text;

namespace Footballer.Models
{
	public class DateTimeProvider : IDateTimeProvider
	{
		public DateTime Now => DateTime.Now;
	}
}
