using Ash.Runtime.Game;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.UI
{
    public sealed class GameOverPanelPresenter : MonoBehaviour
    {
        private IGameOverView m_View;
        private GameComponent m_GameComponent;

        [Inject]
        private void Init(GameComponent gameComponent, IGameOverView view)
        {
            m_GameComponent = gameComponent;
            m_View = view;
            m_GameComponent.GameOver += OnGameOver;
            m_View.RestartClicked += OnRestart;
        }

        private void OnRestart()
        {
            m_View.Hide();
            m_GameComponent.Restart();
        }

        private void OnGameOver()
        {
            m_View.Show();
        }
    }
}
