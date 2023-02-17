using Zenject;

namespace Ash.Runtime.Game
{
	public class SpaceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<ISaucerFactory>().FromComponentSibling().AsSingle();
			Container.Bind<IAsteroidFactory>().FromComponentSibling().AsSingle();
			Container.Bind<IAsteroidSpawnPositionGenerator>().FromComponentSibling().AsSingle();
			Container.Bind<ISaucerSpawnPositionGenerator>().FromComponentSibling().AsSingle();
            
			Container.Bind<Space>().FromComponentInHierarchy().AsSingle();
		}
	}
}