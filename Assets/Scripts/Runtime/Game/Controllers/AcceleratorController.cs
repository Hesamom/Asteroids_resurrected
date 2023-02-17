using Ash.Runtime.Game.Component;
using Ash.Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Controllers
{
    public class AcceleratorController : MonoBehaviour
    {
        private AcceleratorComponent m_Accelerator;

        [Inject]
        private void Init(AcceleratorComponent accelerator, IInput input)
        {
            m_Accelerator = accelerator;
            input.PressedPedal += OnPedal;
        }

        private void OnPedal()
        {
            m_Accelerator.Accelerate();
        }
        
    }
}
