using Ash.Runtime.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ash.Runtime.Game
{
	public class TransformAdaptor : MonoBehaviour, ITransform
	{
		[SerializeField]
		private Transform m_Transform;

		private void Awake()
		{
			Assert.IsNotNull(m_Transform);
		}

		public float EulerAngle
		{
			get => m_Transform.eulerAngles.z;
			set
			{
				Vector3 angle = m_Transform.eulerAngles;
				m_Transform.eulerAngles = new Vector3(angle.x, angle.y, value);
			}
		}
	}
}