using System;

namespace Ash.Runtime.Core
{
	public interface ICollider
	{
		event Action<ICollider> Collided;
		Health Health { get; }
		
		public int Team { get; set; }
		public string Name { get; }
	}
}