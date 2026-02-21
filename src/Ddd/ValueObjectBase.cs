namespace Hamfer.Kernel.Ddd;

public abstract class ValueObjectBase : IAmValueObject
{
  int IAmValueObject.value => this.GetHashCode();

  public bool Equals(IAmValueObject? other)
  {
    return this.GetHashCode() == other?.GetHashCode();
  }

  public int CompareTo(IAmValueObject? other)
  {
    return this.GetHashCode().CompareTo(other?.GetHashCode());
  }
}