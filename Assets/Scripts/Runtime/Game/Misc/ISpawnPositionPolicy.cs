using System.Collections.Generic;
using UnityEngine;

namespace Ash.Runtime.Game
{
	public interface ISpawnPositionPolicy
	{
		bool IsValid(Vector2 pos, IReadOnlyList<Vector2> others);
	}
}