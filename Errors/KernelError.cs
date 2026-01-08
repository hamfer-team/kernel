namespace HamferTeam.Kernel.Models.Errors;

public class KernelError : Exception
{
  public KernelError()
  {
  }

  public KernelError(string message) : base(message)
  {
  }

  public KernelError(string? message, Exception? innerException) : base(message, innerException)
  {
  }

  public static KernelError Create(string? message = null, Exception? innerException = null)
  {
    if (innerException != null)
    {
      return new KernelError(message ?? "A kernel exception occured!", innerException);
    }
      
    if (message != null)
    {
      return new KernelError(message);
    }

    return new KernelError();
  }
}