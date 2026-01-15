namespace Hamfer.Kernel.Errors;

public class InfrastructureError : KernelError
{
  public const string occuredlayer = "Infrastructure Layer";
  public InfrastructureError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}