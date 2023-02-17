using System;
using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	[RequireComponent(typeof(Collider2D))]
	public class Trigger2DCollider : MonoBehaviour, ICollider
	{
		[SerializeField, Range(0,1)]
		private int m_Team;
		
		private HealthComponent m_Health;
		
		public event Action<ICollider> Collided;
		public Health Health => m_Health.Health;

		public int Team
		{
			get => m_Team;
			set => m_Team = value;
		}

		public string Name => gameObject.name;

		[Inject]
		private void Init(HealthComponent healthComponent)
		{
			m_Health = healthComponent;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			Debug.Log($"{name} contacted with : {col.name}");
			if (col.TryGetComponent(out ICollider other))
			{
				Collided?.Invoke(other);
			}
		}
	}
}