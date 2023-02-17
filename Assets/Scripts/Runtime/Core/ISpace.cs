using System;
using UnityEngine;

namespace Ash.Runtime.Core
{
	public interface ISpace
	{
		event Action Cleared;
		event Action<IDestroyable> EntityDestroyed;

		void Clear();
		
		void SpawnAsteroidsScattered(AsteroidType type, int count);
		
		IAsteroid SpawnAsteroid(AsteroidType type, Vector2 position);
		void SpawnSaucer();
	}
}