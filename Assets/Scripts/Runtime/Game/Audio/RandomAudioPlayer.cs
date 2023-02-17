using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Ash.Runtime.Game.Audio
{
	public class RandomAudioPlayer : MonoBehaviour
	{
		[SerializeField]
		private AudioSource m_Source;
		[SerializeField]
		private AudioClip[] m_Clips;

		private void Awake()
		{
			Assert.IsTrue(m_Clips.Length > 0);
		}

		public void PlayRandom()
		{
			m_Source.PlayOneShot(m_Clips[Random.Range(0,m_Clips.Length)]);
		}
	}
}