using System.Collections.Generic;
using UnityEngine;

namespace Ash.Runtime.Game
{
	public interface IAsteroidSpawnPositionGenerator
	{
		IEnumerable<Vector2> GenerateSpawnPositions(int count);
	}
	
	public interface ISaucerSpawnPositionGenerator
	{
		Vector2 GenerateSpawnPosition();
	}
}