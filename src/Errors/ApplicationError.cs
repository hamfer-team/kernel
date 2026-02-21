namespace Hamfer.Kernel.Errors;

public class ApplicationError : KernelError
{
  public const string OCCURED_LAYER = "Application Layer";
  public ApplicationError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}