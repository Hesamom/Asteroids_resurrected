using System.Collections.Generic;
using UnityEngine;

namespace Ash.Runtime.Game
{
	public interface IPolygonGenerator
	{
		List<Vector3> GenerateVertices(float radius);
	}
}