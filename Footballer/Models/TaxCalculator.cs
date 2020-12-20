using System;
using System.Collections.Generic;
using System.Text;

namespace Footballer.Models
{
	internal class TaxCalculator
	{
		public decimal IncludeTaxPrice(decimal totalPrice,TaxLocation taxLocation)
		{
			if (taxLocation == TaxLocation.Pl)
				totalPrice = totalPrice * 1.23m;
			else if (taxLocation == TaxLocation.Usa)
				totalPrice = totalPrice * 1.1m;
			else if (taxLocation == TaxLocation.Ger)
				totalPrice = totalPrice * 1.15m;
			return totalPrice;
		}
	}
}
