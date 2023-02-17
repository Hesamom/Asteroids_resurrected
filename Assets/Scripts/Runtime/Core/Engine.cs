using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Ash.Runtime.Core
{
	public class Engine
	{
		private readonly IRigidBody m_RigidBody;

		public Engine([NotNull] IRigidBody rigidBody)
		{
			m_RigidBody = rigidBody ?? throw new ArgumentNullException(nameof(rigidBody));
		}

		public Vector2 Direction { get; set; }

		public void Accelerate(float force)
		{
			m_RigidBody.AddForce(force * Direction.normalized);
		}
	}
}