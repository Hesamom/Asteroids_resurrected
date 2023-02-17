using System;
using UnityEngine;

namespace Ash.Runtime.UI
{
	public interface IGameOverView
	{
		void Show();
		event Action RestartClicked;
		void Hide();
	}
}