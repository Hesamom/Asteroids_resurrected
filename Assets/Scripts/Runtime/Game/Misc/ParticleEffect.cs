using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class ParticleEffect : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem m_Effect;

		private IParticlePlayer m_Factory;

		[Inject]
		private void Init(IParticlePlayer factory)
		{
			m_Factory = factory;
		}

		public void Play()
		{
			m_Factory.Play(m_Effect, transform.position);
		}
	}
}