using System;

namespace Ash.Runtime.Core
{
	/// <summary>
	/// Represents the overall logic of the game
	/// </summary>
	public class Game 
	{
		private ISpace m_Space;
		private IPlayer m_Player;
		private readonly int m_InitialLives;

		public event Action GameOver;
		public event Action StageCleared;
		public GameState State { get; }

		public Game(ISpace space, IPlayer player, int initialLives)
		{
			m_Player = player;
			m_InitialLives = initialLives;
			m_Space = space;
			State = new GameState()
			{
				Lives = initialLives
			};
			
			m_Player.Destroyed += OnPlayerDestroyed;
			m_Space.Cleared += OnClearedSpace;
			m_Space.EntityDestroyed += OnEntityDestroyed;
		}

		public void StartStage(Stage stage)
		{
			SpawnPlayer();
			SpawnAsteroids(stage);
		}
		
		
		public void Restart()
		{
			State.Lives = m_InitialLives;
			State.Score = 0;
			m_Space.Clear();
		}
		
		private void SpawnPlayer()
		{
			m_Player.Spawn();
			m_Player.EnableInput();
		}
		
		private void OnEntityDestroyed(IDestroyable destroyable)
		{
			State.Score += destroyable.DestructionScore;
		}

		private void OnPlayerDestroyed()
		{
			State.Lives--;
			if (State.Lives <= 0)
			{
				m_Player.DisableInput();
				GameOver?.Invoke();
				return;
			}

			SpawnPlayer();
			m_Player.ApplyInvincibility();
		}

		private void OnClearedSpace()
		{
			StageCleared?.Invoke();
		}

		private void SpawnAsteroids(Stage stage)
		{
			m_Space.SpawnAsteroidsScattered(AsteroidType.Large, stage.AsteroidsCount);
		}

	}
}