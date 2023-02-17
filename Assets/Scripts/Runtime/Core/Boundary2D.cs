using UnityEngine;

namespace Ash.Runtime.Core
{
	public class Boundary2D : IBoundary<Vector2>
	{
		public Vector2 Min { get; set; }
		public Vector2 Max { get; set; }
	}
}