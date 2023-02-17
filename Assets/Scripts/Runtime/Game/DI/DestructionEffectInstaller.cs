using Zenject;

namespace Ash.Runtime.Game
{
	public class DestructionEffectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<Poolable>().FromComponentOn(gameObject).AsSingle();
		}
	}
}