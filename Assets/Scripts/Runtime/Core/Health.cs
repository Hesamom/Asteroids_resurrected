using System;
using UnityEngine;

namespace Ash.Runtime.Core
{
	/// <summary>
	/// Represents the health of an entity 
	/// </summary>
	[Serializable]
	public class Health
	{
		[SerializeField]
		private bool m_IsDead;
		[SerializeField]
		private int m_Max;
		[SerializeField]
		private int m_Current;

		public int Max
		{
			get => m_Max;
			private set => m_Max = value;
		}

		public int Current
		{
			get => m_Current; 
			set
			{
				if (IsInvincible && value < m_Current)
				{
					return;
				}
				
				m_Current = value;
				m_Current = Mathf.Clamp(m_Current, 0, Max);
				IsDead = Current <= 0;
			} 
		}

		public bool IsInvincible { get; set; }

		public event Action Died;

		public Health(int current, int max)
		{
			if (max < current)
			{
				throw new ArgumentOutOfRangeException(nameof(max), "max should be more or equal to current");
			}

			m_Current = current;
			m_Max = max;
		}

		public bool IsDead
		{
			get => m_IsDead;
			private set
			{
				var preVal = m_IsDead;
				m_IsDead = value;
				if (!preVal && value)
				{
					Died?.Invoke();
				}
			}
		}

		public void RestoreToMax()
		{
			Current = Max;
		}

	}
}