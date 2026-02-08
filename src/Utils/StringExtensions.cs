using System.Text.RegularExpressions;

namespace Hamfer.Kernel.Utils;

public static class StringExtensions
{
  public static string? AppendWith(this string? src, string newPart, string separator = ",")
  {
    if (string.IsNullOrEmpty(src))
    {
      return newPart;
    }

    return src + separator + newPart;
  }

  public static string ToPascalCase(this string src)
  {
    if (Regex.IsMatch(src, @"^[A-Za-z]+$"))
    {
      return src[0].ToString().ToUpperInvariant() + src[1..].ToLowerInvariant();
    }

    return src;
  }

  public static string ToPersianStandard(this string src)
  {
    // TODO : standadize more characters
    return src
      .Replace("ي", "ی")
      .Replace("ك", "ک")
      .Replace("ة", "ه")
      .Replace("إ", "ا")
      .Replace("أ", "ا");
  }

  public static string UsePersianNumbers(this string src)
  {
    return src
      .Replace("0", "۰")
      .Replace("1", "۱")
      .Replace("2", "۲")
      .Replace("3", "۳")
      .Replace("4", "۴")
      .Replace("5", "۵")
      .Replace("6", "۶")
      .Replace("7", "۷")
      .Replace("8", "۸")
      .Replace("9", "۹")
      ;
  }
}
