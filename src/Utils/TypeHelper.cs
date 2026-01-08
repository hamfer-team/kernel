using HamferTeam.Kernel.Models.Errors;

namespace HamferTeam.Kernel.Utils;

public static class TypeHelper
{
  public static dynamic? GetDefault(this Type type)
  {
    // If no Type was supplied, if the Type was a reference type, or if the Type was a System.Void, return null
    if (type == null || !type.IsValueType || type == typeof(void))
    {
      return null;
    }

    // If the supplied Type has generic parameters, its default value cannot be determined
    if (type.ContainsGenericParameters)
    {
      throw new KernelError($"{nameof(GetDefault)} Error:\n\nThe supplied value type <{type}> contains generic parameters, so the default value cannot be retrieved");
    }

    // If the Type is a primitive type, or if it is another publicly-visible value type (i.e. struct/enum), return a 
    //  default instance of the value type
    if (type.IsPrimitive || !type.IsNotPublic)
    {
      try
      {
        return Activator.CreateInstance(type);
      }
      catch (Exception e)
      {
        throw new KernelError($"{nameof(GetDefault)} Error:\n\nThe Activator.CreateInstance method could not " +
          $"create a default instance of the supplied value type <{type}> (Inner Exception message: \"{e.Message}\")", e);
      }
    }

    // Fail with exception
    throw new KernelError($"{nameof(GetDefault)} Error:\n\nThe supplied value type <{type}> is not a publicly-visible type, so the default value cannot be retrieved");
  }
}