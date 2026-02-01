namespace Hamfer.Kernel.Ddd;

/// <summary>
/// The Entity-Base means that object can identify by an id and can stored in DB with it as an index
/// </summary>
public abstract class EntityBase : IAmEntity
{
  private Guid _id;

  /// <summary>
  /// The unique auto-generated identifier for declaring the entity
  /// </summary>
  Guid IAmEntity.id { 
    get => this._id; 
    set => this._id = value; 
  }

  /// <summary>
  /// Define object as an Entity-Base object
  /// </summary>
  public EntityBase()
  {
    this._id = Guid.NewGuid();
  }

  /// <summary>
  /// Set / override private id in child classes
  /// </summary>
  /// <param name="id">The id</param>
  protected void setId(Guid id)
  {
    this._id = id;
  }

  /// <summary>
  /// Entities equality is over `id` only
  /// </summary>
  /// <param name="other">The Other Entity</param>
  /// <returns>Is other entity equals to this entity?</returns>
  public bool Equals(IAmEntity? other)
  {
    return this._id.Equals(other?.id);
  }

  /// <summary>
  /// Entities equality is over `id` only
  /// </summary>
  /// <param name="other">The Other Entitys id</param>
  /// <returns>Is other entitys id equals to this entity?</returns>
  public bool Equals(Guid other)
  {
    return this._id.Equals(other);
  }
}