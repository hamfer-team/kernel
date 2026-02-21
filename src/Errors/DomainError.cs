namespace Hamfer.Kernel.Errors;

public class DomainError : KernelError
{
  public const string OCCURED_LAYER = "Domain Layer";
  public DomainError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}