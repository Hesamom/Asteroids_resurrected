namespace Ash.Runtime.Core
{
	public interface IBounder<T>
	{
		T Bound(T bound);
	}
}