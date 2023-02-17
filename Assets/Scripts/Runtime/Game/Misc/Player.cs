using System;
using System.Collections;
using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using Ash.Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class Player : MonoBehaviour, IPlayer
	{
		[SerializeField]
		private Vector2 m_SpawnPosition;

		[SerializeField]
		private float m_InvincibilityDuration;
		
		private HealthComponent m_Health;
		private IInput m_Input;
		public bool IsDead => m_Health.Health.IsDead;
		public Vector3 Position => transform.position;
		
		public event Action Destroyed;

		[Inject]
		private void Init(HealthComponent healthComponent, IInput input)
		{
			m_Input = input;
			m_Health = healthComponent;
			m_Health.Died += OnDied;
		}
		

		private void OnDied()
		{
			Debug.Log("Player has been destroyed");
			gameObject.SetActive(false);
			Destroyed?.Invoke();
		}

		public void EnableInput()
		{
			m_Input.Enable();
		}
		
		public void DisableInput()
		{
			m_Input.Disable();
		}

		public void ApplyInvincibility()
		{
			StartCoroutine(ApplyInvincibilityCoroutine(m_InvincibilityDuration));
		}

		private IEnumerator ApplyInvincibilityCoroutine(float duration)
		{
			m_Health.Health.IsInvincible = true;
			yield return new WaitForSeconds(duration);
			m_Health.Health.IsInvincible = false;
		}

		public void Spawn()
		{
			gameObject.SetActive(true);
			transform.position = m_SpawnPosition;
			m_Health.Health.RestoreToMax();
			Debug.Log($"Player is spawned at : {m_SpawnPosition}");
		}
	}
}