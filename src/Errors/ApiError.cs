namespace HamferTeam.Kernel.Errors;

public class ApiError : KernelError
{
  public const string occuredlayer = "API Layer";
  public ApiError(string? message = null, Exception? innerError = null) : base(message, innerError)
  {
  }
}