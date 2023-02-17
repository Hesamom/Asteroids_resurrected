using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ash.Runtime.Game
{
	[Serializable]
	public class MinDistanceFromOthersSpawnPolicy : ISpawnPositionPolicy
	{
		[SerializeField]
		private float m_MinDistance;
		public bool IsValid(Vector2 pos, IReadOnlyList<Vector2> others)
		{
			return !others.Any(p => Vector2.Distance(p, pos) < m_MinDistance);
		}
	}
}