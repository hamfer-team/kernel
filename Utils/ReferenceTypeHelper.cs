using HamferTeam.Kernel.Models.Errors;

namespace HamferTeam.Kernel.Utils;

public static class ReferenceTypeHelper
{
  public static dynamic? GetPropertValueByName<TObject>(TObject @object, string propertyName)
    where TObject : class
  {
    var property = typeof(TObject).GetProperty(propertyName) ?? throw new PropertyNotFoundError<TObject>(propertyName);
    var value = property.GetValue(@object, null);
    return value;
  }

  public static bool IsDerivedOfGenericInterface(Type type, Type genericType)
  {
    var i = type.GetInterface(genericType.Name);

    return i != null;
  }
}