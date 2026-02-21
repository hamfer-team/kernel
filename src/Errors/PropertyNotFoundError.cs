namespace Hamfer.Kernel.Errors;

public class PropertyNotFoundError<TObject> : KernelError
{
  private const string MESSAGE_PATTERN = "Unable to find a property(name:'{1}') in object(Type:{0}) ";

  public PropertyNotFoundError(string propertyName, string? message = null, Exception? innerError = null)
    : base (message ?? string.Format(MESSAGE_PATTERN, nameof(TObject), propertyName), innerError)
  {
    typeName = nameof(TObject);
    this.propertyName = propertyName;
  }

  public string typeName { get; }
  public string propertyName { get; }
}