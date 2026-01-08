namespace HamferTeam.Kernel.Models.Errors;

public interface IAggregatedError<TException> 
  where TException: Exception
{
  TException[] InnerExceptions { get; }
}