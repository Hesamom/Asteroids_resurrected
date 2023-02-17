using Ash.Runtime.Core;
using Ash.Runtime.Game.Component;
using Zenject;

namespace Ash.Runtime.Game
{
	public class SaucerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IEntitySize>().FromComponentInChildren().AsSingle();
			Container.Bind<IRigidBody>().FromComponentSibling().AsSingle();
            
			Container.Bind<ICollider>().FromComponentSibling().AsSingle();
            
			Container.Bind<ITimer>().FromComponentSibling().AsSingle();
			Container.Bind<HealthComponent>().FromComponentSibling().AsSingle();
			Container.Bind<Poolable>().FromComponentOn(gameObject).AsSingle();
			
			Container.Bind<IMagazine>().FromComponentSibling().AsSingle();
			Container.Bind<ICoolDown>().FromComponentSibling().AsSingle();
			Container.Bind<ShooterComponent>().FromComponentInChildren().AsSingle();
		}
	}
}