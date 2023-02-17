using UnityEngine;

namespace Ash.Runtime.Game.Audio
{
	public class UnityAudioPlayer : MonoBehaviour, IAudioPlayer
	{
		[SerializeField]
		private AudioSource m_Source;
		[SerializeField]
		private AudioClip m_Explosion;
		public void PlayExplosion()
		{
			m_Source.PlayOneShot(m_Explosion);
		}
	}
}