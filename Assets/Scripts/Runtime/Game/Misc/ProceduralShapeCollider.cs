using System;
using System.Linq;
using UnityEngine;

namespace Ash.Runtime.Game
{
	[RequireComponent(typeof(ProceduralShape))]
	public class ProceduralShapeCollider : MonoBehaviour
	{
		[SerializeField]
		private PolygonCollider2D m_PolygonCollider2D;
		[SerializeField]
		private ProceduralShape m_Shape;
		
		private void Start()
		{
			m_PolygonCollider2D.points = m_Shape.Vertices.Select(v => new Vector2(v.x, v.y)).ToArray();
		}
	}
}