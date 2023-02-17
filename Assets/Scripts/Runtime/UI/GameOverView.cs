using System;
using UnityEngine;

namespace Ash.Runtime.UI
{
    public class GameOverView : MonoBehaviour, IGameOverView
    {
        
        public event Action RestartClicked;
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void OnRestartButtonClicked()
        {
            RestartClicked?.Invoke();
        }

    }
}
