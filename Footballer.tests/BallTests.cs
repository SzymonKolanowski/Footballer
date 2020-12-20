using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Footballer.Models;
using System.Linq;
using Should;
using Moq;
namespace Footballer.Tests
{
	public class BallTests
	{
		private Player player;

		[SetUp]
		public void Setup()
		{
			player = new Player(TaxLocation.None, new
				DateTimeProvider());
		}

		[TearDown]
		public void Teardown()
		{
			// wykonuje się po kazdym teście
		}

		[OneTimeSetUp]
		public void FixtureSetup()
		{
			// wykonuje się przed wszystkimi testami w danej klasie
		}

		[OneTimeTearDown]
		public void FixtureTeardown()
		{
			// wykonuje po wszystkich testach w danej klasie
		}


		[Test]
		public void ShouldCreateEmptyPlayer()
		{
			//var player = new Player();
			Assert.AreEqual(0, player.Count());
		}

		[Test]

		public void ShouldReturnPlayer()
		{
			//var player = new Player();
			player.Add(new FootballPlayer());
			Assert.AreEqual(1, player.Count());
		}

		[Test]
		public void ShouldRemovePlayer()
		{
			//var player = new Player();

			FootballPlayer footballPlayer = new FootballPlayer();
			player.Add(footballPlayer);
			player.Remove(footballPlayer);

			Assert.AreEqual(0, player.Count());
		}


		[Test]
		public void ShouldReturnSummaryPlayer()
		{
			//var player = new Player();
			player.Add(new FootballPlayer() { Title = "Test 1" });
			var summary = player.RenderSummary();

			Assert.AreEqual(1, summary.Count);
			Assert.AreEqual("Test 1", summary.FootballPlayers.First().Title);
		}

		[Test]
		public void ShouldReturnSummaryPlayerAfterRemove()
		{
			//var player = new Player();

			FootballPlayer footballPlayer = new FootballPlayer() { Title = "Test 1" };
			player.Add(footballPlayer);
			player.Remove(footballPlayer);


			var summary = player.RenderSummary();

			Assert.AreEqual(0, summary.Count);
			Assert.IsEmpty(summary.FootballPlayers);

			//summary.Count.ShouldEqual(0);
			//summary.FootballPlayers.ShouldBeEmpty();

		}

		[Test]
		public void ShouldNotAcceptNullFootballPlayer()
		{
			//var player = new Player();

			Assert.Throws<ArgumentNullException>(() =>
			player.Add(null));

		}

		[Test]

		public void ShouldReturnFullFotballerPrice()
		{

			var footballplayer = new FootballPlayer() { NetPrice = 10.0m };
			player.Add(footballplayer);

			var summary = player.RenderSummary();
			summary.TotalPrice.ShouldEqual(10.0m);


		}

		//[Test]
		//[TestCase(TaxLocation.Pl , 12.3)]
		//[TestCase(TaxLocation.Pl, 10.0)]
		[TestCaseSource(nameof(TaxPlayerPriceTestCases))]

		public void ShouldReturnFullFotballerPrice(TaxLocation taxLocation,
			decimal expectedTotalPrice)
		{
			var player = new Player(taxLocation, new DateTimeProvider());
			var footballplayer = new FootballPlayer() { NetPrice = 10.0m };
			player.Add(footballplayer);

			var summary = player.RenderSummary();
			summary.TotalPrice.ShouldEqual(expectedTotalPrice);


		}


		public static object[] TaxPlayerPriceTestCases()
		{
			return new object[]
			{
				new object[] { TaxLocation.Pl , 12.3m },
				new object[] { TaxLocation.None,10.0m },
				new object[] { TaxLocation.Usa,11.0m },
				new object[] { TaxLocation.Ger,11.5m }

			};
		}


		[Test]
		public void HappyHouerBetween12And14()
		{
			var timeProvider = new Mock<IDateTimeProvider>();

			var player = new Player(TaxLocation.None, timeProvider.Object);

			var footballplayer = new FootballPlayer() { NetPrice = 10m };
			player.Add(footballplayer);

			timeProvider.Setup(t => t.Now).Returns
				(new DateTime(2020, 12, 17, 13, 2, 3));

			var summary = player.RenderSummary();


			summary.TotalPrice.ShouldEqual(9m);

			//timeProvider.Verify(t => t.Now,Times.Never);
		}
	

	}


}
