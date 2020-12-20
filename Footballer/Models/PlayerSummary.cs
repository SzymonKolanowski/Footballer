using System.Collections.Generic;

namespace Footballer.Models


{
	public struct PlayerSummary
	{
		public int Count { get; set; }
		public IEnumerable<FootballPlayer> FootballPlayers { get; set; }
		public object TotalPrice { get; set; }
	}
}