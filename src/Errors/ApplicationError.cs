namespace HamferTeam.Kernel.Models.Errors;

public class ApplicationError : KernelError
{
  public const string occuredlayer = "Application Layer";
  public ApplicationError(string? message = null, Exception? innerException = null) : base(message, innerException)
  {
  }
}