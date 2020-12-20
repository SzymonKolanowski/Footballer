using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Footballer.Models;
using NUnit.Framework;
using System. Linq;

namespace XUnitTestProject1
{
	public class Ball
	{
		
		[Test]
		public void ShouldCreateNewFootballer()
		{
			var Footballer = new Pilka();
			Assert.AreEqual(0,Pilka.Count());
		}
	}
}
