using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		private AsteroidType m_Type;
		[SerializeField]
		private int m_Count;
		[SerializeField]
		private float m_MinForce, m_MaxForce;
		
		private ISpace m_Space;

		[Inject]
		private void Init(ISpace space)
		{
			m_Space = space;
		}
		public void Spawn()
		{
			for (int i = 0; i < m_Count; i++)
			{
				var asteroid = m_Space.SpawnAsteroid(m_Type,transform.position);
				asteroid.AddForce(Random.insideUnitCircle * Random.Range(m_MinForce, m_MaxForce));
			}
		}
	}
}