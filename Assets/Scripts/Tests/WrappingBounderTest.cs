
using Ash.Runtime.Core;
using NUnit.Framework;
using UnityEngine;

namespace Ash.Tests
{
	public class WrappingBounderTest
	{
		[Test]
		public void WhenBoundIsCalled_PositionShouldBeWrapped()
		{
			var pos = new Vector2(10, 10);

			Boundary2D boundary = new Boundary2D()
			{
				Max = new Vector2(5, 5),
				Min = new Vector2(0, 0)
			};
			
			WrappingBounder simpleBounder = new WrappingBounder(boundary);

			var bound = simpleBounder.Bound(pos);
			
			var expected = new Vector2(0, 0);
			Assert.AreEqual(expected, bound);
		}
	}
}