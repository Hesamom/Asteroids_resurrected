using Ash.Runtime.Game;
using Ash.Runtime.Game.Component;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.UI
{
    public class HUDPresenter : MonoBehaviour
    {
        private GameComponent m_Game;
        private IHUDView m_View;

        [Inject]
        private void Init(GameComponent game, IHUDView view)
        {
            m_Game = game;
            m_View = view;
            m_Game.State.ScoreChanged += ScoreChanged;
            m_Game.State.LivesChanged += LivesChanged;
        }

        private void Start()
        {
            LivesChanged();
            ScoreChanged();
        }

        private void LivesChanged()
        {
            m_View.UpdateLives(m_Game.State.Lives);
        }

        private void ScoreChanged()
        {
            m_View.UpdateScore(m_Game.State.Score);
        }
    }
}
