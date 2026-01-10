namespace HamferTeam.Kernel.Errors;

public class ApplicationError : KernelError
{
  public const string occuredlayer = "Application Layer";
  public ApplicationError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}