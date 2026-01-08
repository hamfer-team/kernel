using System.ComponentModel;
using System.Globalization;

namespace HamferTeam.Kernel.Utils;

public static class ValueTypeHelper
{
  private static readonly List<Type> NumericTypes =
  [
    typeof(sbyte),      // aka System.SByte
    typeof(byte),       // aka System.Byte
    typeof(short),      // aka System.Int16
    typeof(ushort),     // aka System.UInt16
    typeof(int),        // aka System.Int32
    typeof(uint),       // aka System.UInt32
    typeof(long),       // aka System.Int64
    typeof(ulong),      // aka System.UInt64
    typeof(float),      // aka System.Single
    typeof(double),     // aka System.Double
    typeof(decimal),    // aka System.Decimal
  ];

  public static bool IsNumeric(Type? type)
  => type != null && NumericTypes.Contains(type);

  public static bool TryParse<T>(string fromString, out T? toValue)
  {
    toValue = default;
    try
    {
      TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
      toValue = (T?)converter.ConvertFromString(null, CultureInfo.InvariantCulture, fromString);

      return true;
    }
    catch (Exception)
    {
      return false;
    }
  }
}