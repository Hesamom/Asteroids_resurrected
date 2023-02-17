using Ash.Runtime.Core;
using NUnit.Framework;

namespace Ash.Tests
{
	public class LinearStageProviderTest
	{
		[TestCase(1,1)]
		[TestCase(2,2)]
		[TestCase(10,10)]
		public void AsteroidsCount_MustBeReturnedLinearly(int stageCount, int expected)
		{
			var provider = new LinearStageProvider(1, 1);

			Stage stage = null;
			for (int i = 0; i < stageCount; i++)
			{
				stage = provider.GetNextStage();
			}
			
			Assert.AreEqual(expected, stage.AsteroidsCount) ;
		}
	}
}