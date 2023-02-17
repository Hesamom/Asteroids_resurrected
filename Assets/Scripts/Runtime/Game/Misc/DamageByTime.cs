using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class DamageByTime : MonoBehaviour
	{
		[SerializeField]
		private int m_Damage;
		
		[SerializeField]
		private float m_Seconds;
		
		private HealthComponent m_HealthComponent;
		private ITimer m_Timer;

		[Inject]
		private void Init(ITimer tracker, HealthComponent health)
		{
			m_Timer = tracker;
			m_HealthComponent = health;
		}

		private void Start()
		{
			m_Timer.Reset();
			m_Timer.Begin(m_Seconds);
			m_Timer.Tick += OnTick;
		}

		private void OnTick()
		{
			m_HealthComponent.Health.Current -= m_Damage;
		}

		private void OnEnable()
		{
			m_Timer?.Reset();
		}
		
	}
}