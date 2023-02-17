using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using Zenject;

namespace Ash.Runtime.Game
{
    public class SpaceshipInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntitySize>().FromComponentInChildren().AsSingle();
            Container.Bind<IMagazine>().FromComponentSibling().AsSingle();
            Container.Bind<ICoolDown>().FromComponentSibling().AsSingle();
            Container.Bind<IRigidBody>().FromComponentInParents().AsSingle();
            Container.Bind<ITransform>().FromComponentInParents().AsSingle();
            Container.Bind<ICollider>().FromComponentInParents().AsSingle();
            
            Container.Bind<WheelComponent>().FromComponentSibling().AsSingle();
            Container.Bind<ShooterComponent>().FromComponentSibling().AsSingle();
            Container.Bind<AcceleratorComponent>().FromComponentSibling().AsSingle();
            Container.Bind<HealthComponent>().FromComponentSibling().AsTransient();
        }
    }
}
