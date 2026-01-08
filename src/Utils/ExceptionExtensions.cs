using System.Text;
using HamferTeam.Kernel.Models.Errors;

namespace HamferTeam.Kernel.Utils;

public static class ExceptionExtensions
{
  public static string GetExceptionMessage(this Exception exception)
  {
    var messages = GetInnerExceptionMessages(exception);

    var aggException = exception.ConvertToAggregateException();

    if (aggException != null)
    {
      messages += GetAggregatedExceptionMessages(aggException.InnerExceptions);
    }

    return messages.TrimEnd('\r', '\n');
  }

  public static AggregateException? ConvertToAggregateException<TException>(this TException exception)
    where TException: Exception
  {
    var aggException = exception as AggregateException;
    if (aggException == null && ReferenceTypeHelper.IsDerivedOfGenericInterface(exception.GetType(), typeof(IAggregatedError<>)))
    {
      var prop = exception.GetType().GetProperty(nameof(IAggregatedError<>.InnerExceptions));
      var value = (Exception[]?)prop?.GetValue(exception, null);
      if (value != null)
      {
        aggException = new AggregateException(value);
      }
    }

    return aggException;
  }

  private static string GetInnerExceptionMessages(Exception exception, string initIndent = "")
  {
    var indent = initIndent;
    var sb = new StringBuilder();
    var ex = exception;
    do
    {
      sb.Append(indent)
        .AppendLine(ex.Message);

      ex = ex.InnerException;
      indent += "   ";
    } while (ex != null);

    return sb.ToString();
  }

  private static string GetAggregatedExceptionMessages(IEnumerable<Exception> exceptions)
  {
    var messages = "";
    foreach (var innerException in exceptions)
    {
      messages += GetInnerExceptionMessages(innerException, " + ");
    }

    return messages;
  }
}