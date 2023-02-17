using System;
using UnityEngine;

namespace Ash.Runtime.Game
{
	[RequireComponent(typeof(Collider2D))]
	public class Collider2DSize : MonoBehaviour, IEntitySize
	{
		public Vector2 Size => GetComponent<Collider2D>().bounds.extents;

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			var r = Mathf.Max(Size.x, Size.y);
			Gizmos.DrawWireSphere(transform.position, r);
		}
	}
}