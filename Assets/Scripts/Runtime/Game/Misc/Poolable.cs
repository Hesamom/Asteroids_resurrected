using System;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
	public class Poolable : MonoBehaviour
	{
		public string Id => name;
		public bool IsActive { get; private set; }

		public event Action Spawned;
		public void OnDespawned()
		{
			gameObject.SetActive(false);
			IsActive = false;
		}

		public void OnSpawned()
		{
			gameObject.SetActive(true);
			IsActive = true;
			Spawned?.Invoke();
		}
	}
}