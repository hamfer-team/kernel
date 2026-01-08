namespace HamferTeam.Kernel.Models.Errors;

public class DomainError : KernelError
{
  public const string occuredlayer = "Domain Layer";
  public DomainError(string? message = null, Exception? innerException = null) : base(message, innerException)
  {
  }
}