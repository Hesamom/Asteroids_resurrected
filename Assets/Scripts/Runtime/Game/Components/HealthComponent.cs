using System;
using Ash.Runtime.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Ash.Runtime.Game.Component
{
	internal class HealthComponent : MonoBehaviour
	{
		public event Action Died;
		
		[SerializeField]
		private UnityEvent DeathEvent;

		[SerializeField]
		private Health m_Health;
		public Health Health => m_Health;

		
		private void Awake()
		{
			Health.Died += OnDeath;
		}

		private void OnDeath()
		{
			Debug.Log($"{name} died.");
			DeathEvent.Invoke();
			Died?.Invoke();
		}
	}
}