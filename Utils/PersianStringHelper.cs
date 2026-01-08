using System.Globalization;
using System.Text.RegularExpressions;

namespace HamferTeam.Kernel.Utils;

public static class PersianStringHelper
{
  public static bool VerifyNationalCodeCheckSum(string code, bool isForeignAllowed = true)
  {
      //// بررسی اولیه تعداد و اعداد  کد
      if (!Regex.IsMatch(code, @"^\d\d[1-9]\d{7}$"))
          return false;

      //// بررسی کد ملی اتباع خارجه
      if (code.StartsWith("9") && !isForeignAllowed)
          return false;

      //// بررسی عدم استفاده از تکرار اعداد
      var invalidCodes = Enumerable.Range('2', 8).Select(c => new string((char)c, 10));
      if (invalidCodes.Contains(code))
          return false;

      // TODO: remove Parses
      var ctr = int.Parse(code[9].ToString());
      var sum = 0;
      for (var i = 0; i < 9; i++)
      {
          var c = int.Parse(code[i].ToString());
          sum += c * (10 - i);
      }

      var net = sum % 11;

      return (net < 2 && ctr == net) || (ctr + net == 11);
  }

  public static bool ConvertToDateTime(string persianDate, out DateTime dateTime)
  {
    dateTime = DateTime.MinValue;
    if (string.IsNullOrEmpty(persianDate))
    {
      return false;
    }

    var regex = new Regex(@"^(?<year>\d{4})[\\\/\- ](?<month>\d\d?)[\\\/\- ](?<day>\d\d?)([ ,\-](?<hour>\d\d?)[\\\.\:\,](?<min>\d\d)?([\\\.\:\,](?<sec>\d\d)?([[\\\.\:\,](?<mili>\d{1,6})])?)?)?$");
    var match = regex.Match(persianDate);
    if (!match.Success)
    {
      return false;
    }

    if (!int.TryParse("0" + match.Groups["year"].Value, out int year)) return false;
    if (!int.TryParse("0" + match.Groups["month"].Value, out int month)) return false;
    if (!int.TryParse("0" + match.Groups["day"].Value, out int day)) return false;
    if (!int.TryParse("0" + match.Groups["hour"].Value, out int hour)) return false;
    if (!int.TryParse("0" + match.Groups["min"].Value, out int min)) return false;
    if (!int.TryParse("0" + match.Groups["sec"].Value, out int sec)) return false;
    if (!int.TryParse("0" + match.Groups["mili"].Value, out int mili)) return false;

    var persianCalendar = new PersianCalendar();
    dateTime = persianCalendar.ToDateTime(year, month, day, hour, min, sec, mili);

    return true;
  }
}