using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class Magazine : MonoBehaviour, IMagazine
	{
		private IPool m_ObjectPool;
		
		[SerializeField]
		private Poolable m_ProjectilePrefab;

		[Inject]
		private void Init(IPool pool)
		{
			m_ObjectPool = pool;
		}
		
		public IProjectile CreateProjectile()
		{
			var poolable = m_ObjectPool.Spawn(m_ProjectilePrefab.Id);
			return poolable.GetComponent<IProjectile>();
		}
	}
}