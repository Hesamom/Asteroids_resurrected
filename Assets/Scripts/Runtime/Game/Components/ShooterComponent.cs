using Ash.Runtime.Core;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Ash.Runtime.Game.Component
{
	public class ShooterComponent : MonoBehaviour
	{
		[SerializeField]
		private float m_Force;
		[SerializeField]
		private Transform m_From;
		[SerializeField]
		private UnityEvent ShotEvent;
		[SerializeField]
		private int m_Team;
		
		private Shooter m_Shooter;

		[Inject]
		private void Init(IMagazine magazine, ICoolDown coolDown)
		{
			m_Shooter = new Shooter(magazine, coolDown);
		}

		public void Shoot(Vector2 direction)
		{
			m_Shooter.Force = m_Force;
			var projectile = m_Shooter.Shoot(m_From.position, direction);
			if (projectile != null)
			{
				projectile.SetTeam(m_Team);
				ShotEvent?.Invoke();
			}
		}
	}
}