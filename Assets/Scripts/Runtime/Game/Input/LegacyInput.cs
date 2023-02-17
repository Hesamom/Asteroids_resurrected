using System;
using UnityEngine;

namespace Ash.Runtime.Game.Input
{
	public class LegacyInput : MonoBehaviour, IInput
	{
		[SerializeField]
		private KeyCode m_FireKey;
		[SerializeField]
		private KeyCode m_PedalKey;
		[SerializeField]
		private KeyCode m_RotateLeftKey;
		[SerializeField]
		private KeyCode m_RotateRightKey;
		
		public event Action Fired;
		public event Action PressedPedal;
		public event Action RotatedLeft;
		public event Action RotatedRight;
		public void Enable()
		{
			enabled = true;
		}

		public void Disable()
		{
			enabled = false;
		}

		private void Update()
		{
			if (UnityEngine.Input.GetKeyDown(m_FireKey))
			{
				Fired?.Invoke();
			}
			
			if (UnityEngine.Input.GetKey(m_PedalKey))
			{
				PressedPedal?.Invoke();
			}
			
			if (UnityEngine.Input.GetKey(m_RotateLeftKey))
			{
				RotatedLeft?.Invoke();
			}
			
			if (UnityEngine.Input.GetKey(m_RotateRightKey))
			{
				RotatedRight?.Invoke();
			}
		}
	}
}