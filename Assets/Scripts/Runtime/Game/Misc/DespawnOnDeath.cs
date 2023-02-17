using System;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	[RequireComponent(typeof(Poolable))]
	public class DespawnOnDeath : MonoBehaviour
	{
		private HealthComponent m_HealthComponent;

		[Inject]
		private void Init(HealthComponent healthComponent)
		{
			m_HealthComponent = healthComponent;
		}

		private void Start()
		{
			m_HealthComponent.Health.Died += OnDeath;
		}

		private void OnDeath()
		{
			GetComponent<Poolable>().OnDespawned();
		}
	}
}