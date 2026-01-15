using System.Reflection;
using System.Text;

namespace Hamfer.Kernel.Utils;

public static class IOHelper
{
  public static string? Cwd() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

  public static string? CurrentWorkingDirectory() => Cwd();

  private static readonly byte[] TestFileBytes = Encoding.ASCII.GetBytes(@"X");

  public static bool IsFileNameValid(string file, bool removePath = true)
  {
    try
    {
      if (string.IsNullOrEmpty(file))
      {
        return false;
      }

      string fileNamePart = removePath ? Path.GetFileName(file) : file;
      if (fileNamePart.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
      {
        return false;
      }

      string fileName = Path.Combine(Path.GetTempPath(), fileNamePart);
      using FileStream fileStream = File.Create(fileName);
      {
          fileStream.Write(TestFileBytes, 0, TestFileBytes.Length);
      }

      File.Delete(fileName);
      return true;
    }
    catch
    {
      return false;
    }
  }
}