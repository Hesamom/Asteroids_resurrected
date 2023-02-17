using System;
using UnityEngine;

namespace Ash.Runtime.Core
{
	[Serializable]
	public class GameState
	{
		[SerializeField]
		private int m_Lives;
		[SerializeField]
		private int m_Score;
		
		public int Score
		{
			get => m_Score;
			internal set
			{
				if (m_Score != value)
				{
					m_Score = value;
					ScoreChanged?.Invoke();
					return;
				}
				m_Score = value;
			}
		}
		public int Lives
		{
			get => m_Lives;
			internal set
			{
				if (m_Lives != value)
				{
					m_Lives = value;
					LivesChanged?.Invoke();
					return;
				}
				m_Lives = value;
			}
		}

		public event Action ScoreChanged;
		public event Action LivesChanged;
	}
}