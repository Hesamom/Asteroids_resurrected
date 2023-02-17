using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Ash.Runtime.Core
{

	/// <summary>
	/// Shoots projectiles in a direction 
	/// </summary>
	public class Shooter
	{
		public float Force { get; set; }
		
		private readonly IMagazine m_Magazine;
		private readonly ICoolDown m_CoolDown;
		
		
		public Shooter([NotNull] IMagazine magazine, ICoolDown coolDown)
		{
			m_Magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
			m_CoolDown = coolDown;
		}

		public IProjectile Shoot(Vector2 from, Vector2 direction)
		{
			if (!m_CoolDown.IsCool())
			{
				return null;
			}
			
			IProjectile projectile = m_Magazine.CreateProjectile();
			Vector2 force = direction.normalized * Force;
			projectile.Shoot(from, force);

			m_CoolDown.StartCoolDown();
			return projectile;
		}
	}
}