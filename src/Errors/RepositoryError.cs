namespace HamferTeam.Kernel.Errors;

public class RepositoryError : KernelError
{
  public const string occuredlayer = "Repository Layer";
  public RepositoryError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}