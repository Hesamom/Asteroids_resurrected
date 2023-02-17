using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class ObjectPool : MonoBehaviour, IPool
	{
		[SerializeField]
		private bool m_CanExceedMax;
		
		[SerializeField]
		private List<PoolInfo> m_PoolsInfo;
		
		[SerializeField]
		private Transform m_PoolParent;

		private Dictionary<string, List<Poolable>> m_Pools = new Dictionary<string, List<Poolable>>();
		private DiContainer m_Container;

		[Inject]
		private void Init(DiContainer container)
		{
			m_Container = container;
		}

		private void Awake()
		{
			CreateInitialCount();
		}

		private void CreateInitialCount()
		{
			foreach (var info in m_PoolsInfo)
			{
				var pool = new List<Poolable>();
				for (int i = 0; i < info.initalCount; i++)
				{
					pool.Add(Create(info.prefab));
				}
				m_Pools.Add(info.prefab.name, pool);
			}
		}

		public Poolable Spawn(string Id)
		{
			if (!m_Pools.TryGetValue(Id, out var poolables))
			{
				throw new InvalidOperationException($"no pool was found for poolable with id: {Id}.");
			}
			
			var poolable = poolables.FirstOrDefault(p => !p.IsActive);
			if (poolable == null)
			{
				var poolInfo = m_PoolsInfo.First(i => i.prefab.Id == Id);
				if (poolInfo.maxCount <= poolables.Count)
				{
					if (m_CanExceedMax)
					{
						Debug.LogWarning($"{Id} has exceeded max pool number of :{poolInfo.maxCount}");
					}
					else
					{
						throw new PoolExceededMaxSizeException();
					}
				}
				
				var newP = Create(poolInfo.prefab);
				poolables.Add(newP);
				newP.OnSpawned();
				return newP;
			}

			poolable.OnSpawned();
			return poolable;
		}

		private Poolable Create(Poolable prefab)
		{
			var newPoolable = m_Container.InstantiatePrefab(prefab, GetPoolParent(prefab)).GetComponent<Poolable>();
			newPoolable.OnDespawned();
			return newPoolable;
		}

		private Transform GetPoolParent(Poolable poolable)
		{
			var parent = m_PoolParent.Find(poolable.Id);
			if (parent != null)
			{
				return parent;
			}
			
			var newParent = new GameObject(poolable.Id);
			newParent.transform.SetParent(m_PoolParent);
			return newParent.transform;
		}

		public void Despawn(Poolable poolable)
		{
			poolable.OnDespawned();
		}
	}
}