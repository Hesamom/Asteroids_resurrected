using System;
using UnityEngine;

namespace Ash.Runtime.Core
{
	public interface IPlayer
	{
		bool IsDead { get; }
		event Action Destroyed;
		void Spawn();
		Vector3 Position { get; }
		void EnableInput();
		void DisableInput();

		void ApplyInvincibility();
	}
}