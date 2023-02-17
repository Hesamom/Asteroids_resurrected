using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class ProceduralShape : MonoBehaviour
	{
		[SerializeField]
		private float m_MinRadius, m_MaxRadius;

		private IPolygonGenerator m_Generator;
		public IReadOnlyList<Vector3> Vertices { get; private set; }

		[Inject]
		private void Init(IPolygonGenerator generator)
		{
			m_Generator = generator;
		}

		private void Awake()
		{
			float radius = Random.Range(m_MinRadius, m_MaxRadius);
			Vertices = m_Generator.GenerateVertices(radius);
		}
	}
}