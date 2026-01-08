namespace HamferTeam.Kernel.Models.Errors;

public class RepositoryError : KernelError
{
  public const string occuredlayer = "Repository Layer";
  public RepositoryError(string? message = null, Exception? innerException = null) : base(message, innerException)
  {
  }
}