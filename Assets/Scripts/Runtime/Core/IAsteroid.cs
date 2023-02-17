using UnityEngine;

namespace Ash.Runtime.Core
{
	public interface IAsteroid : IDestroyable
	{
		void AddForce(Vector2 force);
	}
}