using Ash.Runtime.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ash.Runtime.Game
{
	public class Physics2DRigidBody : MonoBehaviour, IRigidBody
	{
		[SerializeField]
		private ForceMode2D m_ForceMode2D;
		[SerializeField]
		private Rigidbody2D m_Body;

		private void Awake()
		{
			Assert.IsNotNull(m_Body);
		}
		public void AddForce(Vector2 force)
		{
			m_Body.AddForce(force, m_ForceMode2D);
		}

		public void AddTorque(float force)
		{
			m_Body.AddTorque(force, m_ForceMode2D);
		}

		public void SetVelocity(Vector2 velocity)
		{
			m_Body.velocity = velocity;
		}
	}
}