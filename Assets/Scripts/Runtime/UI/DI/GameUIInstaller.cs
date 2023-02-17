using Zenject;

namespace Ash.Runtime.UI
{
    public class GameUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IHUDView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IGameOverView>().FromComponentInHierarchy().AsSingle();
        }
    }
}
