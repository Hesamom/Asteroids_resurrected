using System;
using System.Collections.Generic;
using System.Linq;
using Ash.Runtime.Core;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Ash.Runtime.Game
{
	public class BoundedSpawnPositionGenerator : MonoBehaviour, IAsteroidSpawnPositionGenerator, ISaucerSpawnPositionGenerator
	{
		[SerializeField]
		private MinDistanceFromOthersSpawnPolicy m_DistanceFromOther;
		[SerializeField]
		private MinDistanceFromCenterSpawnPolicy m_DistanceFromCenter;
		[SerializeField]
		private int m_PolicyInvalidTryCount = 10;
		
		private IBoundary<Vector2> m_Boundary2D;
		private List<ISpawnPositionPolicy> m_Policies;

		[Inject]
		public void Init( IBoundary<Vector2> boundary2D)
		{
			m_Boundary2D = boundary2D;
		}

		private void Awake()
		{
			m_Policies = new List<ISpawnPositionPolicy>()
			{
				m_DistanceFromOther,
				m_DistanceFromCenter
			};
		}

		public IEnumerable<Vector2> GenerateSpawnPositions(int count)
		{
			List<Vector2> poses = new List<Vector2>(count);

			for (int i = 0; i < count; i++)
			{
				var pos = GeneratePosition(poses);
				poses.Add(pos);
			}

			return poses;
		}

		private Vector2 GeneratePosition(IReadOnlyList<Vector2> poses)
		{
			Vector2 newPos = Vector2.zero; 
			for (int i = 0; i < m_PolicyInvalidTryCount; i++)
			{
				newPos = new Vector2(Random.Range(m_Boundary2D.Min.x, m_Boundary2D.Max.x),
					Random.Range(m_Boundary2D.Min.y, m_Boundary2D.Max.y));
				var isValid = m_Policies.All(p => p.IsValid(newPos, poses));
				if (isValid)
				{
					return newPos;
				}
			}

			//returning the last generated one
			return newPos;
		}

		public Vector2 GenerateSpawnPosition()
		{
			var y = Random.Range(m_Boundary2D.Min.y, m_Boundary2D.Max.y);
			var x = Random.value > 0.5f ? m_Boundary2D.Min.x : m_Boundary2D.Max.x;
			return new Vector2(x, y);
		}
	}
}