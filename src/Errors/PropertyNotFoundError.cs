namespace HamferTeam.Kernel.Models.Errors;

public class PropertyNotFoundError<TObject> : KernelError
{
  private const string MessagePattern = "Unable to find a property(name:'{1}') in object(Type:{0}) ";

  public PropertyNotFoundError(string propertyName, string? message = null, Exception? innerException = null)
    : base (message ?? string.Format(MessagePattern, nameof(TObject), propertyName), innerException)
  {
    TypeName = nameof(TObject);
    PropertyName = propertyName;
  }

  public string TypeName { get; }
  public string PropertyName { get; }
}