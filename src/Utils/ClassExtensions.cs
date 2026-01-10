using System.Reflection;

namespace HamferTeam.Kernel.Utils;

public static class ClassExtensions
{
  public static TResult AutoMap<TResult>(this object src)
    where TResult : class, new()
  {
    TResult result = new();
    PropertyInfo[] props = typeof(TResult).GetProperties();

    foreach (PropertyInfo prop in props)
    {
      try
      {
        prop.SetValue(result, prop.GetValue(src));
      }
      catch //(Exception err)
      {
        //ignored
      }
    }

    return result;
  }
}