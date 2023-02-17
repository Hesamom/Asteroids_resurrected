using System;
using System.Collections.Generic;
using System.Linq;
using Ash.Runtime.Core;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Ash.Runtime.Game
{
	public class Space : MonoBehaviour, ISpace
	{
		[SerializeField]
		private float m_AsteroidForce;
		
		private IAsteroidFactory m_AsteroidFactory;
		private ISaucerFactory m_SaucerFactory;
		private IAsteroidSpawnPositionGenerator m_AsteroidPositionGenerator;
		private ISaucerSpawnPositionGenerator m_SaucerSpawnPositionGenerator;
		private HashSet<IDestroyable> m_Spawned = new HashSet<IDestroyable>();

		public event Action Cleared;
		public event Action<IDestroyable> EntityDestroyed;
		
		[Inject]
		private void Init(IAsteroidFactory asteroidFactory, ISaucerFactory saucerFactory, IAsteroidSpawnPositionGenerator positionGenerator, ISaucerSpawnPositionGenerator saucerSpawnPositionGenerator)
		{
			m_SaucerSpawnPositionGenerator = saucerSpawnPositionGenerator;
			m_AsteroidPositionGenerator = positionGenerator;
			m_SaucerFactory = saucerFactory;
			m_AsteroidFactory = asteroidFactory;
		}

		public void Clear()
		{
			foreach (var spawned in m_Spawned.ToList())
			{
				spawned.Destroy();
			}
			
			m_Spawned.Clear();
		}

		public void SpawnAsteroidsScattered(AsteroidType type, int count)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(count), "the count should be more than zero.");
			}
			
			var poses = m_AsteroidPositionGenerator.GenerateSpawnPositions(count);
			foreach (Vector2 position in poses)
			{
				Asteroid asteroid = m_AsteroidFactory.Create(type, position);
				asteroid.AddForce(GetRandomDirection() * m_AsteroidForce); ;
				OnSpawnedEntity(asteroid);
			}
		}

		public IAsteroid SpawnAsteroid(AsteroidType type, Vector2 position)
		{
			var asteroid = m_AsteroidFactory.Create(type, position);
			OnSpawnedEntity(asteroid);
			return asteroid;
		}

		private Vector2 GetRandomDirection()
		{
			return Random.insideUnitCircle;
		}

		private void OnDestroyed(IDestroyable destroyable)
		{
			EntityDestroyed?.Invoke(destroyable);
			
			m_Spawned.Remove(destroyable);
			if (m_Spawned.Count == 0)
			{
				Cleared?.Invoke();
			}
		}

		public void SpawnSaucer()
		{
			var pos = m_SaucerSpawnPositionGenerator.GenerateSpawnPosition();
			var saucer = m_SaucerFactory.Create(pos);
			var dir = GetSaucerMoveDirection();
			OnSpawnedEntity(saucer);
			saucer.Move(dir);
			Debug.Log($"{saucer.name} has been spawned at {pos}, moving with direction: {dir}");
		}

		private Vector2 GetSaucerMoveDirection()
		{
			return Random.value > 0.5f ? Vector2.right : Vector2.left;
		}

		private void OnSpawnedEntity(IDestroyable destroyable)
		{
			m_Spawned.Add(destroyable);
			destroyable.Destroyed -= OnDestroyed;
			destroyable.Destroyed += OnDestroyed;
		}
	}
}