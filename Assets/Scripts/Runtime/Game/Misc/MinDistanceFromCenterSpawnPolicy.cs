using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ash.Runtime.Game
{
	[Serializable]
	public class MinDistanceFromCenterSpawnPolicy : ISpawnPositionPolicy
	{
		[SerializeField]
		private float m_MinDistance;
		public bool IsValid(Vector2 pos, IReadOnlyList<Vector2> others)
		{
			return Vector2.Distance(Vector2.zero, pos) > m_MinDistance;
		}
	}
}