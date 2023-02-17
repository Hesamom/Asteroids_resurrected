using System;
using UnityEngine;

namespace Ash.Runtime.Core
{
	[Serializable]
	public class Stage
	{
		[SerializeField]
		private int m_AsteroidsCount;
		public int AsteroidsCount => m_AsteroidsCount;
		
		public Stage(int asteroidsCount)
		{
			m_AsteroidsCount = asteroidsCount;
		}

	}
}