using System;
using UnityEngine;

namespace Ash.Runtime.Core
{
	public interface IProjectile
	{
		event Action Shot;
		void Shoot(Vector2 from, Vector2 force);
		Vector2 Position { get; }
		void SetTeam(int team);
	}
	
}