using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Ash.Runtime.Core
{
	public class WrappingBounder : IBounder<Vector2>
	{
		public IBoundary<Vector2> Boundary { get; }
		public float Margin { get; set; }
		public WrappingBounder([NotNull] IBoundary<Vector2> boundary)
		{
			Boundary = boundary ?? throw new ArgumentNullException(nameof(boundary));
		}
		
		public Vector2 Bound(Vector2 position)
		{
			float x = Wrap(position.x, Boundary.Min.x - Margin, Boundary.Max.x + Margin);
			float y = Wrap(position.y, Boundary.Min.y - Margin, Boundary.Max.y + Margin);

			return new Vector2(x,y);
		}
		

		private float Wrap(float pos, float min, float max)
		{
			var value = pos < min ? max : (pos > max ? min : pos);
			return value;
		}
	}
}