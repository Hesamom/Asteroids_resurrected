using System;
using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class AsteroidFactory : MonoBehaviour, IAsteroidFactory
	{
		[SerializeField]
		private Poolable m_LargePrefab;
		[SerializeField]
		private Poolable m_MediumPrefab;
		[SerializeField]
		private Poolable m_SmallPrefab;
		
		private IPool m_Pool;

		[Inject]
		private void Init(IPool pool)
		{
			m_Pool = pool;
		}
		
		public Asteroid Create(AsteroidType type, Vector2 position)
		{
			var prefab = GetPrefab(type);
			var poolable = m_Pool.Spawn(prefab.Id);
			poolable.transform.position = position;
			return poolable.GetComponent<Asteroid>();
		}

		private Poolable GetPrefab(AsteroidType type)
		{
			switch (type)
			{
				case AsteroidType.Large:
					return m_LargePrefab;
				case AsteroidType.Medium:
					return m_MediumPrefab;
				case AsteroidType.Small:
					return m_SmallPrefab;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}
	}
}