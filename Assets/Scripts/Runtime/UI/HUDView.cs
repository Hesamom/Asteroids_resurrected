using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Ash.Runtime.UI
{
    public class HUDView : MonoBehaviour, IHUDView
    {
        [SerializeField]
        private char m_LifeChar;
        
        [SerializeField]
        private Text m_ScoreText;
        [SerializeField]
        private Text m_LivesText;

        private StringBuilder m_Builder;

        private void Awake()
        {
            m_ScoreText.text = (0).ToString();
            m_LivesText.text = (0).ToString();

            m_Builder = new StringBuilder();
        }

        public void UpdateScore(int score)
        {
            m_ScoreText.text = score.ToString();
        }

        public void UpdateLives(int lives)
        {
            m_Builder.Clear();
            m_LivesText.text = m_Builder.Append(m_LifeChar, lives).ToString();
        }
    }
}
