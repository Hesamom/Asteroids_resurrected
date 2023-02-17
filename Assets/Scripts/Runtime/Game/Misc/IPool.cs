using System;

namespace Ash.Runtime.Game
{
	public interface IPool
	{
		Poolable Spawn(string Id);
		void Despawn(Poolable poolable);
	}
}