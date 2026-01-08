namespace HamferTeam.Kernel.Models.Errors;

public class ApiError : KernelError
{
  public const string occuredlayer = "API Layer";
  public ApiError(string? message = null, Exception? innerException = null) : base(message, innerException)
  {
  }
}