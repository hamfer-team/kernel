namespace Hamfer.Kernel.Errors;

public class RepositoryError : KernelError
{
  public const string OCCURED_LAYER = "Repository Layer";
  public RepositoryError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}