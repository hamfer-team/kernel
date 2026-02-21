using Hamfer.Kernel.Errors;

namespace Hamfer.Kernel.Utils;

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
    return type.GetInterface(genericType.Name) != null;
  }

  // TODO
  // public static bool IsNullable(Type type)
  // {
    
  // }
}