using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;

namespace Footballer.Models
{
	public class Player
	{
		//private int _footballerCount = 0;
		private List<FootballPlayer> _footballPlayers = new List<FootballPlayer>();
		private TaxLocation taxLocation;

		public IDateTimeProvider DateTimeProvider { get; }

		public Player(TaxLocation taxLocation, IDateTimeProvider
			dateTimeProvider)
		{
			this.taxLocation = taxLocation;
			DateTimeProvider = dateTimeProvider;
		}

		public  int Count()
		{
			return _footballPlayers.Count;
		}

		public void Add(FootballPlayer footballPlayer)
		{
			//_footballerCount++;
			if (footballPlayer == null)
				throw new ArgumentNullException("footballplayer");
			_footballPlayers.Add(footballPlayer);
		}

		public void Remove(FootballPlayer footballPlayer)
		{
			_footballPlayers.Remove(footballPlayer);
		}

		public PlayerSummary RenderSummary()
		{
			decimal totalPrice = _footballPlayers.Sum(c => c.NetPrice);
			TaxCalculator calculator = new TaxCalculator();
			totalPrice = calculator.IncludeTaxPrice(totalPrice , taxLocation);

			if (this.DateTimeProvider.Now.Hour >= 12 &&
				this.DateTimeProvider.Now.Hour <= 14)
				totalPrice = totalPrice * 0.9m;

			return new PlayerSummary()
			{
				Count = _footballPlayers.Count,
				FootballPlayers = _footballPlayers.ToArray(),
				TotalPrice = totalPrice

			};
		}

		
	}
}
