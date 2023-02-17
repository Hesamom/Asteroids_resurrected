using UnityEngine;

namespace Ash.Runtime.Core
{
	public interface IRigidBody
	{
		void AddForce(Vector2 force);
		void AddTorque(float force);

		void SetVelocity(Vector2 velocity);
	}
}