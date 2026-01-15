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
    // TODO : standadize characters
    return src
      .Replace("ي", "ی")
      .Replace("ك", "ک")
      .Replace("ة", "ه")
      .Replace("إ", "ا")
      .Replace("أ", "ا");
  }
}
