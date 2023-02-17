namespace Ash.Runtime.Core
{
	public interface IBoundary<out T>
	{
		T Min { get; }
		T Max { get; }
	}
}