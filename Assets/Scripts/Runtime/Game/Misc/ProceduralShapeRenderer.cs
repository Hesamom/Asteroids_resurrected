using System.Linq;
using UnityEngine;

namespace Ash.Runtime.Game
{
	public class ProceduralShapeRenderer : MonoBehaviour
	{
		[SerializeField]
		private LineRenderer m_Renderer;
		[SerializeField]
		private ProceduralShape m_Shape;
		
		private void Start()
		{
			m_Renderer.positionCount = m_Shape.Vertices.Count;
			m_Renderer.SetPositions(m_Shape.Vertices.ToArray());
		}
        
		private void OnDrawGizmos()
		{
			var start = transform.position;
			for (int i = 0; i < m_Renderer.positionCount; i++)
			{
				Gizmos.DrawLine(start, m_Renderer.GetPosition(i) + start);
			}
		}
	}
}