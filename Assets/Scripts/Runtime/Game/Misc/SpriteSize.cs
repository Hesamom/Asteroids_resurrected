using UnityEngine;

namespace Ash.Runtime.Game
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteSize : MonoBehaviour, IEntitySize
	{
		public Vector2 Size => GetComponent<SpriteRenderer>().sprite.bounds.extents;
	}
}