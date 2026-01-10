namespace HamferTeam.Kernel.Utils;

public static class ICollectionExtensions
{
  public static bool Add<T>(this ICollection<T> list, T item, bool overwrite, Func<T, bool> condition)
  {
    var oldItem = list.SingleOrDefault(condition);

    if (oldItem == null)
    {
      list.Add(item);
      return true;
    }
    else if (oldItem != null && overwrite)
    {
      list.Remove(oldItem);
      list.Add(item);
      return true;
    }

    return false;
  }
}