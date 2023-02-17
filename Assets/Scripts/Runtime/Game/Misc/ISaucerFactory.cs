using UnityEngine;

namespace Ash.Runtime.Game
{
	internal interface ISaucerFactory
	{
		Saucer Create(Vector2 position);
	}
}