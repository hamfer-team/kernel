namespace Hamfer.Kernel.Utils;

public static class BooleanExtensions
{
  public static int ToBit(this bool src) => src ? 1 : 0;
}
