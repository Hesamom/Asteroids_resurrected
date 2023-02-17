using System;
using Ash.Runtime.Core;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Ash.Runtime.Game.Component
{
	/// <summary>
	/// Wraps an entity position in the world boundary 
	/// </summary>
	public class WorldBounderComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform m_Transform;
		
		
		private WrappingBounder m_Bounder;
		private IEntitySize m_Size;

		private void Awake()
		{
			Assert.IsNotNull(m_Transform);
		}

		[Inject]
		private void Init(IBoundary<Vector2> boundary, IEntitySize size)
		{
			m_Size = size;
			m_Bounder = new WrappingBounder(boundary);
			Assert.IsNotNull(m_Bounder);
		}

		private void Start()
		{
			m_Bounder.Margin = Mathf.Max(m_Size.Size.x, m_Size.Size.y);
		}

		private void Update()
		{
			m_Transform.position = m_Bounder.Bound(m_Transform.position);
		}
	}
}