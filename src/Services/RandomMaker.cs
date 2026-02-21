using System.Security.Cryptography;

namespace Hamfer.Kernel.Services;

public static class RandomMaker
{
  private static readonly Random random = new();

  /// <summary>
  /// Gets a random byte array from `System.Security.Cryptography`
  /// </summary>
  /// <param name="length">The length of the byte array</param>
  /// <returns>The random byte array</returns>
  public static byte[] GetCryptoBytes(int length)
  {
    byte[]? data = new byte[length];
    using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
    randomNumberGenerator.GetBytes(data);
    return data;
  }
  
  /// <summary>
  /// Gets a random byte array
  /// </summary>
  /// <param name="length">The length of the byte array</param>
  /// <returns>The random byte array</returns>
  public static byte[] GetBytes(int length)
  {
    byte[] buffer = new byte[length];
    random.NextBytes(buffer);
    return buffer;
  }

  /// <summary>
  /// Get a random number
  /// </summary>
  /// <returns>A random number as `int` or `Int32`</returns>
  public static int GetInt() => random.Next();

  /// <summary>
  /// Get an integer random number between `from` and `to`
  /// </summary>
  /// <param name="from">from this number</param>
  /// <param name="to">to this number</param>
  /// <returns>A random number as `int` or `Int32` between `from` and `to`</returns>
  public static int GetIntBetween(int from, int to) => random.Next(from, to + 1);

  /// <summary>
  /// Get a random number between `from` and `to`
  /// </summary>
  /// <param name="from">from this number</param>
  /// <param name="to">to this number</param>
  /// <returns>A random number as `double` or `Double` between `from` and `to`</returns>
  public static double GetDouble(double from, double to) => from + random.NextDouble() * to;
}