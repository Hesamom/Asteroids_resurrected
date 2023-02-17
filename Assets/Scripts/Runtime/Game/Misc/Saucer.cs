using System;
using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class Saucer : MonoBehaviour, IDestroyable
	{
		[SerializeField]
		private int m_Score;
		
		[SerializeField]
		private float m_Speed;
		
		private IRigidBody m_RigidBody;
		private ShooterComponent m_ShooterComponent;
		private IPlayer m_Player;
		private HealthComponent m_HealthComponent;

		public event Action<IDestroyable> Destroyed;
		public int DestructionScore => m_Score;
	

		[Inject]
		private void Init(IRigidBody rigidBody, ShooterComponent shooterComponent, IPlayer player, HealthComponent healthComponent)
		{
			m_HealthComponent = healthComponent;
			m_Player = player;
			m_ShooterComponent = shooterComponent;
			m_RigidBody = rigidBody;
			m_HealthComponent.Died += OnDied;
		}
		
		public void Destroy()
		{
			m_HealthComponent.Health.Current = 0;
		}

		private void OnDied()
		{
			Destroyed?.Invoke(this);
		}

		public void Move(Vector2 moveDirection)
		{
			m_RigidBody.SetVelocity(moveDirection.normalized * m_Speed);
		}

		private void Update()
		{
			ShootPlayer();
		}
		
		private void ShootPlayer()
		{
			var direction = GetToPlayerDirection();
			m_ShooterComponent.Shoot(direction);
		}

		//TODO add inaccuracy to shots 
		private Vector2 GetToPlayerDirection()
		{
			return m_Player.Position - transform.position;
		}
	}
}