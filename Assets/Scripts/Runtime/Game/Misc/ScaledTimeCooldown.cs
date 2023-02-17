using System;
using Ash.Runtime.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ash.Runtime.Game
{
	public class ScaledTimeCooldown : MonoBehaviour, ICoolDown
	{
		[SerializeField, Range(0.01f,2)]
		private float m_CooldownTime;

		private float m_ElapsedTime;

		private void Awake()
		{
			Assert.IsTrue(m_CooldownTime >= 0);
		}

		public void StartCoolDown()
		{
			m_ElapsedTime = 0;
		}

		public bool IsCool()
		{
			return m_ElapsedTime > m_CooldownTime;
		}

		private void Update()
		{
			m_ElapsedTime += Time.deltaTime;
		}
	}
}