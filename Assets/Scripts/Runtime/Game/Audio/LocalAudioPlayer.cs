using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Audio
{
	public class LocalAudioPlayer : MonoBehaviour
	{
		private IAudioPlayer m_Player;

		[Inject]
		private void Init(IAudioPlayer player)
		{
			m_Player = player;
		}

		public void PlayExplosion()
		{
			m_Player.PlayExplosion();
		}
	}
}