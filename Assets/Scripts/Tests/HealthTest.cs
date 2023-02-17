using Ash.Runtime.Core;
using NUnit.Framework;

namespace Ash.Tests
{
	public class HealthTest
	{
		[TestCase(-1,4)]
		[TestCase(1,5)]
		[TestCase(-3,2)]
		[TestCase(-10,0)]
		public void WhenHealthIsChanged_CurrentShouldChange(int delta, int expected)
		{
			var health = new Health(5,5);
			
			health.Current += delta;
			
			Assert.AreEqual(expected,health.Current);
		}
		
		[Test]
		public void WhenHealthBecomesZero_ShouldInvokeDeathEvent()
		{
			var health = new Health(1,1);
			bool isInvoked = false;
			health.Died += () => isInvoked = true;
			
			health.Current--;
			
			Assert.AreEqual(true,isInvoked);
		}
		
		[Test]
		public void WhenHealthIsZero_IsDeadShouldReturnTrue()
		{
			var health = new Health(1,1);
			
			health.Current--;
			
			Assert.AreEqual(true,health.IsDead);
		}
		
		[Test]
		public void WhenHealthIsAboveZero_IsDeadShouldReturnFalse()
		{
			var health = new Health(0,1);
			
			health.Current++;
			
			Assert.AreEqual(false,health.IsDead);
		}
		
		[Test]
		public void WhenRestoreIsCalled_CurrentShouldBeEqualToMax()
		{
			var health = new Health(0,5);
			
			health.RestoreToMax();
			
			Assert.AreEqual(5,health.Current);
		}
		
		[Test]
		public void WhenIsInvincible_AndHealthIsChanged_CurrentShouldNotChange()
		{
			var health = new Health(5,5);

			health.IsInvincible = true;
			health.Current -= 3;
			
			Assert.AreEqual(5,health.Current);
		}
		
		[Test]
		public void WhenRestored_IsDeadShouldReturnFalse()
		{
			var health = new Health(1,1);

			health.Current -= 1;
			health.RestoreToMax();
			
			Assert.AreEqual(false,health.IsDead);
		}
	}
}