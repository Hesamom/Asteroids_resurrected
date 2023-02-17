using System;

namespace Ash.Runtime.Core
{
	public interface IDestroyable
	{
		event Action<IDestroyable> Destroyed;
		int DestructionScore { get; }
		void Destroy();
	}
}