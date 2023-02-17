using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using Zenject;

namespace Ash.Runtime.Game
{
    public class AsteroidInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntitySize>().FromComponentInChildren().AsSingle();
            Container.Bind<HealthComponent>().FromComponentSibling().AsTransient();
            
            Container.Bind<ICollider>().FromComponentInParents().AsSingle();
            
            Container.Bind<IPolygonGenerator>().FromComponentSibling().AsSingle();
            Container.Bind<IRigidBody>().FromComponentSibling().AsSingle();
            Container.Bind<Poolable>().FromComponentOn(gameObject).AsSingle();
            Container.Bind<Spawner>().FromComponentOn(gameObject).AsSingle();
            Container.Bind<IAsteroidFactory>().FromComponentSibling().AsSingle();
        }
    }
}
