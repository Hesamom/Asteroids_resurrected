using Ash.Runtime.Core;
using Ash.Runtime.Game.Audio;
using Ash.Runtime.Game.Component;
using Ash.Runtime.Game.Input;
using UnityEngine;
using Zenject;

namespace Ash.Runtime.Game
{
    public class MasterSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Player m_Player;
        [SerializeField]
        private Space m_Space;
        [SerializeField]
        private ObjectPool m_ObjectPool;

        public override void InstallBindings()
        {
            Container.Bind<IInput>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IBoundary<Vector2>>().To<ScreenBoundary>().FromComponentInHierarchy().AsSingle();

            Container.Bind<IPool>().FromInstance(m_ObjectPool).AsSingle();
            
            Container.Bind<GameComponent>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ISpace>().FromComponentInNewPrefab(m_Space).AsSingle();
            Container.Bind<IPlayer>().FromComponentInNewPrefab(m_Player).AsSingle();
            
            Container.Bind<IParticlePlayer>().To<ParticlePlayer>().AsSingle();
            Container.Bind<IStageProvider>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IAudioPlayer>().FromComponentInHierarchy().AsSingle();

            Container.Bind<ITimer>().FromComponentSibling().AsSingle();
        }
    }
}
