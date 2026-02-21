namespace Hamfer.Kernel.Errors;

public class InfrastructureError : KernelError
{
  public const string OCCURED_LAYER = "Infrastructure Layer";
  public InfrastructureError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}