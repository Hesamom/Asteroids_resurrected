using System;
using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class Asteroid : MonoBehaviour, IAsteroid
	{
		[SerializeField]
		private int m_Score;
		
		private IRigidBody m_RigidBody;
		private HealthComponent m_HealthComponent;
		private Poolable m_Poolable;

		public int DestructionScore => m_Score;
	
		public event Action<IDestroyable> Destroyed;

		[Inject]
		private void Init(IRigidBody rigidBody, HealthComponent healthComponent, Poolable poolable)
		{
			m_Poolable = poolable;
			m_HealthComponent = healthComponent;
			m_HealthComponent.Died += OnDied;
			m_RigidBody = rigidBody;
		}
		
		private void OnDied()
		{
			Destroyed?.Invoke(this);
		}

		public void Destroy()
		{
			m_Poolable.OnDespawned();
		}

		public void AddForce(Vector2 force)
		{
			m_RigidBody.AddTorque(force.magnitude);
			m_RigidBody.AddForce(force);
		}
	}
}