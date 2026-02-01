namespace Hamfer.Kernel.Ddd;

public interface IAmRoot: IAmEntity
{
  public string boundary { get; protected set; }
}