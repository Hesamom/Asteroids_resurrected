using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
    public class DespawnOnParticleEnd : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem m_ParticleSystem;
        
        private Poolable m_Poolable;

        [Inject]
        private void Init(Poolable poolable)
        {
            m_Poolable = poolable;
        }

        private void Update()
        {
            if (!m_ParticleSystem.isPlaying)
            {
                m_Poolable.OnDespawned();
            }
        }
    }
}
