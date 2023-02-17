using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Component
{
	public class WheelComponent : MonoBehaviour
	{
		[SerializeField]
		private float m_DegreePerSecond;
        
		private Wheel m_Wheel;
        
		[Inject]
		private void Init(ITransform t)
		{
			m_Wheel = new Wheel(t);
		}

		public void RotateRight()
		{
			m_Wheel.Rotate(-m_DegreePerSecond * Time.deltaTime);
		}

		public void RotateLeft()
		{
			m_Wheel.Rotate(m_DegreePerSecond * Time.deltaTime);
		}
	}
}