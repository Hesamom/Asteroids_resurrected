using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Runtime.Game.Misc
{
	public class SaucerInvasion : MonoBehaviour
	{
		[SerializeField]
		private float m_Interval;

		private ISpace m_Space;
		private ITimer m_Timer;

		[Inject]
		private void Init(ISpace space, ITimer timer)
		{
			m_Timer = timer;
			m_Space = space;
		}

		private void Awake()
		{
			m_Timer.Begin(m_Interval);
			m_Timer.Tick += OnTick;
		}

		private void OnTick()
		{
			m_Space.SpawnSaucer();
			m_Timer.Reset();
		}
	}
}