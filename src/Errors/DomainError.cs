namespace HamferTeam.Kernel.Errors;

public class DomainError : KernelError
{
  public const string occuredlayer = "Domain Layer";
  public DomainError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}