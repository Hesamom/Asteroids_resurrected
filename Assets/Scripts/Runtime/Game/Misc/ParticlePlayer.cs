using UnityEngine;

namespace Ash.Runtime.Game
{
	public class ParticlePlayer : IParticlePlayer
	{
		private readonly IPool m_Pool;

		public ParticlePlayer(IPool pool)
		{
			m_Pool = pool;
		}
		public void Play(ParticleSystem effect, Vector2 position)
		{
			var poolable = m_Pool.Spawn(effect.gameObject.name);
			poolable.GetComponent<ParticleSystem>().Play();
			poolable.transform.position = position;
		}
	}
}