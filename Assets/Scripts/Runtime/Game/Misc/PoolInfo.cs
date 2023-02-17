using System;

namespace Ash.Runtime.Game
{
	[Serializable]
	public class PoolInfo
	{
		public Poolable prefab;
		public int initalCount;
		public int maxCount;
	}
}