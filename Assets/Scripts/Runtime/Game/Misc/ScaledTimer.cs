using System;
using Ash.Runtime.Core;
using UnityEngine;

namespace Ash.Runtime.Game
{
	public class ScaledTimer : MonoBehaviour, ITimer
	{
		private float m_TimeElapsed;
		private float m_Time;
		
		
		public event Action Tick;
		private bool m_Begun;

		private void Update()
		{
			if (!m_Begun)
			{
				return;
			}
			
			m_TimeElapsed += Time.deltaTime;
			if (m_TimeElapsed > m_Time)
			{
				Tick?.Invoke();
			}
		}
		

		public void Begin(float seconds)
		{
			m_Begun = true;
			m_TimeElapsed = 0;
			m_Time = seconds;
		}

		public void Reset()
		{
			m_TimeElapsed = 0;
		}
	}
}