using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class DamageOnContact : MonoBehaviour
	{
		[SerializeField]
		private int m_Damage;

		private ICollider m_Collider;

		[Inject]
		private void Init(ICollider collider)
		{
			m_Collider = collider;
			collider.Collided += OnCollided;
		}

		private void OnCollided(ICollider other)
		{
			if (other.Team == m_Collider.Team)
			{
				return;
			}
			
			
			Debug.Log($"{m_Collider.Name} delivered {m_Damage} damage to: {other.Name}");
			other.Health.Current -= m_Damage;
		}
	}
}