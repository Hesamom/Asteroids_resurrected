using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using Zenject;

namespace Ash.Runtime.Game
{
    public class ProjectileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntitySize>().FromComponentInChildren().AsSingle();
            Container.Bind<IRigidBody>().FromComponentInParents().AsSingle();
            
            Container.Bind<ICollider>().FromComponentInParents().AsSingle();
            
            Container.Bind<ITimer>().FromComponentSibling().AsSingle();
            Container.Bind<IProjectile>().FromComponentSibling().AsSingle();
            Container.Bind<HealthComponent>().FromComponentSibling().AsSingle();
            Container.Bind<Poolable>().FromComponentOn(gameObject).AsSingle();
        }
    }
}
