namespace Hamfer.Kernel.Utils;

public static class IEnumerableExtensions
{
  public static void ApplyToAll<T>(this IEnumerable<T> list, Action<T> action)
  {
    foreach (T item in list)
    {
      action.Invoke(item);
    }
  }
}
