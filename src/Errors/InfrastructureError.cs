namespace HamferTeam.Kernel.Models.Errors;

public class InfrastructureError : KernelError
{
  public const string occuredlayer = "Infrastructure Layer";
  public InfrastructureError(string? message = null, Exception? innerException = null) : base(message, innerException)
  {
  }
}