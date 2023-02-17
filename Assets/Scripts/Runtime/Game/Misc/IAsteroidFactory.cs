using Ash.Runtime.Core;
using UnityEngine;

namespace Ash.Runtime.Game
{
	internal interface IAsteroidFactory
	{
		Asteroid Create(AsteroidType type, Vector2 position);
	}
}