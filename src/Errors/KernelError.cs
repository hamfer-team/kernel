namespace HamferTeam.Kernel.Errors;

public class KernelError : Exception
{
  public KernelError()
  {
  }

  public KernelError(string message) : base(message)
  {
  }

  public KernelError(string? message, Exception? innerError) : base(message, innerError)
  {
  }

  public static KernelError Create(string? message = null, Exception? innerError = null)
  {
    if (innerError != null)
    {
      return new KernelError(message ?? "A kernel error occured!", innerError);
    }
      
    if (message != null)
    {
      return new KernelError(message);
    }

    return new KernelError();
  }
}