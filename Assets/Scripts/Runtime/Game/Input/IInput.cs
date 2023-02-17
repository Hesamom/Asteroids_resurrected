using System;

namespace Ash.Runtime.Game.Input
{
	public interface IInput
	{
		event Action Fired;
		event Action PressedPedal;
		event Action RotatedLeft, RotatedRight;
		void Enable();
		void Disable();
	}
}