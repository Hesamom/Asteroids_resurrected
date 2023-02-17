using System;

namespace Ash.Runtime.Core
{
	public interface ITimer
	{
		event Action Tick;
		void Begin(float seconds);
		void Reset();
	}
}