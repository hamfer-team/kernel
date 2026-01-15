namespace Hamfer.Kernel.Errors;

public interface IAggregatedError<TException> 
  where TException: Exception
{
  TException[] InnerErrors { get; }
}