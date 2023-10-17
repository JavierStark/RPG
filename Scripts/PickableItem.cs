using System.Numerics;
using Godot;

class PickableItem : IInteractable
{
  Vector2I position;
  Map map;

  public void Interact()
  {
    GD.Print("Object picked");
    map.DeleteItem(position);
  }

  public void Setup(Vector2I position, Map map)
  {
    this.position = position;
    this.map = map;
  }
}