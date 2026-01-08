using System.Globalization;

namespace HamferTeam.Kernel.Utils;

public static class DateTimeExtensions
{
  public static string? ToPersianString(this DateTime src, string pattern = "{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}.{6}")
  {
    var pcal = new PersianCalendar();

    if (src < pcal.ToDateTime(1, 1, 1, 0, 0, 0, 0))
    {
      return null;
    }
    
    var year = pcal.GetYear(src);
    var month = pcal.GetMonth(src);
    var day = pcal.GetDayOfMonth(src);
    var hour = pcal.GetHour(src);
    var minu = pcal.GetMinute(src);
    var seco = pcal.GetSecond(src);
    var mili = pcal.GetMilliseconds(src);

    return string.Format(pattern, year, month, day, hour, minu , seco, mili);
  }
}