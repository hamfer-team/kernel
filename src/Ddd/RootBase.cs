namespace Hamfer.Kernel.Ddd;

public abstract class RootBase : EntityBase, IAmRoot
{
  private string _boundary;

  string IAmRoot.boundary
  {
    get => this._boundary;
    set => this._boundary = value;
  }

  public RootBase(string boundary) : base()
  {
    this._boundary = boundary;
  }
}