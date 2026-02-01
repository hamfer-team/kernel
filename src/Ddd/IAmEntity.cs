namespace Hamfer.Kernel.Ddd;

public interface IAmEntity: IEquatable<IAmEntity>, IEquatable<Guid>
{
  public Guid id {get; protected set; }
}