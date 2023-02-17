using System;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class SpawnOnDeath : MonoBehaviour
	{
		private HealthComponent m_HealthComponent;
		private Spawner m_Spawner;

		[Inject]
		private void Init(HealthComponent healthComponent, Spawner spawner)
		{
			m_HealthComponent = healthComponent;
			m_Spawner = spawner;
		}

		private void Start()
		{
			m_HealthComponent.Health.Died += OnDied;
		}

		private void OnDied()
		{
			m_Spawner.Spawn();
		}
	}
}