namespace Ash.Runtime.Core
{
	public class LinearStageProvider : IStageProvider
	{
		private int m_BaseAsteroidsCount;
		private int m_AsteroidsAddPerStage;
		private int m_Index;

		public LinearStageProvider(int baseAsteroidsCount, int asteroidsAddPerStage)
		{
			m_AsteroidsAddPerStage = asteroidsAddPerStage;
			m_BaseAsteroidsCount = baseAsteroidsCount;
		}

		public Stage GetNextStage()
		{
			var stage =  new Stage(m_BaseAsteroidsCount + (m_Index * m_AsteroidsAddPerStage));
			m_Index++;
			return stage;
		}

		public void Restart()
		{
			m_Index = 0;
		}
	}
}