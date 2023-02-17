namespace Ash.Runtime.Core
{
	public interface ICoolDown
	{
		void StartCoolDown();
		bool IsCool();
	}
}