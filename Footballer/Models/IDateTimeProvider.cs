using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Footballer.Models
{
	public interface IDateTimeProvider
	{
		DateTime Now { get; }
	}
}
