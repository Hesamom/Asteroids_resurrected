using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Component
{
	public class AcceleratorComponent : MonoBehaviour
	{
		[SerializeField]
		private float m_ForcePerSecond;
		
		private Engine m_Engine;

		[Inject]
		private void Init(IRigidBody rigidBody)
		{
			m_Engine = new Engine(rigidBody);
		}

		public void Accelerate()
		{
			m_Engine.Direction = transform.right;
			m_Engine.Accelerate(m_ForcePerSecond * Time.deltaTime);
		}
	}
}