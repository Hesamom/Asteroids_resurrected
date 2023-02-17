namespace Ash.Runtime.Core
{
	public interface IStageProvider
	{
		Stage GetNextStage();
		void Restart();
	}
}