using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class PoolableSaucerFactory : MonoBehaviour, ISaucerFactory
	{
		[SerializeField]
		private Saucer m_Prefab;
		private IPool m_Pool;

		[Inject]
		private void Init(IPool pool)
		{
			m_Pool = pool;
		}
		public Saucer Create(Vector2 position)
		{
			var poolable = m_Pool.Spawn(m_Prefab.name);
			poolable.transform.position = position;
			return poolable.GetComponent<Saucer>();
		}
	}
}