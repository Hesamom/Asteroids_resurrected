using UnityEngine;

namespace Ash.Runtime.Game
{
	internal interface IParticlePlayer
	{
		void Play(ParticleSystem effect, Vector2 position);
	}
}