namespace Hamfer.Kernel.Ddd;

public interface IAmValueObject: IEquatable<IAmValueObject>, IComparable<IAmValueObject>
{
  protected int value { get; }
}