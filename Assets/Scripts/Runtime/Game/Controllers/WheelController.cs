using Ash.Runtime.Game.Component;
using Ash.Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game.Controllers
{
    public class WheelController : MonoBehaviour
    {
        private WheelComponent m_Wheel;

        [Inject]
        private void Init(WheelComponent wheel, IInput input)
        {
            m_Wheel = wheel;
            input.RotatedLeft += OnRotateLeft;
            input.RotatedRight += OnRotateRight;
        }

        private void OnRotateRight()
        {
            m_Wheel.RotateRight();
        }

        private void OnRotateLeft()
        {
            m_Wheel.RotateLeft();
        }
    }
}