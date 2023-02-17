using Ash.Runtime.Core;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Ash.Tests
{
	public class ShooterTest
	{
		[Test]
		public void WhenShootIsCalled_MustShootProjectile()
		{
			var projectile = Substitute.For<IProjectile>();
			var mag = Substitute.For<IMagazine>();
			mag.CreateProjectile().Returns(projectile);
			
			var cooldown = Substitute.For<ICoolDown>();
			cooldown.IsCool().Returns(true);
			
			var shooter = new Shooter(mag,cooldown);
			shooter.Shoot(Vector2.zero, Vector2.up);

			projectile.Received().Shoot( Arg.Any<Vector2>(),Arg.Is<Vector2>(v => v == Vector2.up * shooter.Force));
		}
		
		[Test]
		public void WhenShootIsCalled_AndInCooldown_MustNotShootProjectile()
		{
			var projectile = Substitute.For<IProjectile>();
			var mag = Substitute.For<IMagazine>();
			mag.CreateProjectile().Returns(projectile);
			
			var cooldown = Substitute.For<ICoolDown>();
			cooldown.IsCool().Returns(false);
			
			var shooter = new Shooter(mag,cooldown);
			shooter.Shoot(Vector2.zero, Vector2.up);

			projectile.DidNotReceive().Shoot(Arg.Any<Vector2>(), Arg.Any<Vector2>());
		}
	}
}