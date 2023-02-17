using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	[RequireComponent(typeof(Poolable))]
	public class ReviveOnSpawn : MonoBehaviour
	{
		private HealthComponent m_HealthComponent;
		private Poolable m_Poolable;

		[Inject]
		private void Init(HealthComponent healthComponent, Poolable poolable)
		{
			m_Poolable = poolable;
			m_HealthComponent = healthComponent;
		}

		private void Start()
		{
			m_Poolable.Spawned += OnSpawned;
		}

		private void OnSpawned()
		{
			m_HealthComponent.Health.RestoreToMax();
		}
	}
}