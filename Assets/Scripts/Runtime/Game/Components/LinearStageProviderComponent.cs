using Ash.Runtime.Core;
using UnityEngine;

namespace Ash.Runtime.Game.Component
{
	public class LinearStageProviderComponent : MonoBehaviour, IStageProvider
	{
		[SerializeField]
		private int m_BaseAsteroidsCount;
		[SerializeField]
		private int m_AsteroidsAddPerStage;
		
		private LinearStageProvider m_Provider;

		private void Awake()
		{
			m_Provider = new LinearStageProvider(m_BaseAsteroidsCount, m_AsteroidsAddPerStage);
		}

		public Stage GetNextStage()
		{
			return m_Provider.GetNextStage();
		}

		public void Restart()
		{
			m_Provider.Restart();
		}
	}
}