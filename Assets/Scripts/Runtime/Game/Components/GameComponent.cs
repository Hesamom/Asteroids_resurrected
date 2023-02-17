using System;
using Ash.Runtime.Core;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Component
{
	public class GameComponent : MonoBehaviour
	{
		[SerializeField]
		private int m_InitialLives;
		
		private Core.Game m_Game;
		private IStageProvider m_StageProvider;
		public GameState State => m_Game.State;

		public event Action GameOver;

		[Inject]
		private void Init(ISpace space, IPlayer player, IStageProvider stageProvider)
		{
			m_Game = new Core.Game(space, player, m_InitialLives);
			m_StageProvider = stageProvider;
		}

		private void Awake()
		{
			m_Game.StageCleared += StageCleared;
			m_Game.GameOver += OnGameOver;
		}

		private void OnGameOver()
		{
			Debug.LogWarning("game is over!");
			GameOver?.Invoke();
		}

		private void StageCleared()
		{
			m_Game.StartStage(m_StageProvider.GetNextStage());
		}

		private void Start()
		{
			m_Game.StartStage(m_StageProvider.GetNextStage());
		}
		
		public void Restart()
		{
			m_StageProvider.Restart();
			m_Game.Restart();
			m_Game.StartStage(m_StageProvider.GetNextStage());
		}
	}
}