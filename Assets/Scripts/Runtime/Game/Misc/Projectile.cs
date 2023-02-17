using System;
using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Component
{
	public class Projectile : MonoBehaviour, IProjectile
	{
		public event Action Shot;
		
		private IRigidBody m_RigidBody;
		private ICollider m_Collider;

		[Inject]
		private void Init(IRigidBody rigidBody, ICollider collider)
		{
			m_Collider = collider;
			m_RigidBody = rigidBody;
		}
		
		public void Shoot(Vector2 from, Vector2 force)
		{
			m_RigidBody.AddForce(force);
			transform.right = force;
			transform.position = from;
			Shot?.Invoke();
		}

		public Vector2 Position => transform.position;
		public void SetTeam(int team)
		{
			m_Collider.Team = team;
		}
	}
}