using Ash.Runtime.Game.Component;
using Ash.Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Controllers
{
	public class ShooterController : MonoBehaviour
	{
		private ShooterComponent m_Shooter;

		[Inject]
		public void Init(ShooterComponent shooter, IInput input)
		{
			m_Shooter = shooter;
			input.Fired += OnFired;
		}

		private void OnFired()
		{
			m_Shooter.Shoot(transform.right);
		}
	}
}