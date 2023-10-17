using Godot;

class Door : IInteractable
{

  Vector2I openTile = new Vector2I(6, 9);
  Vector2I closedTile = new Vector2I(3, 9);

  bool isOpen = false;
  Vector2I position;
  Map map;

  public void Setup(Vector2I position, Map map)
  {
    this.position = position;
    this.map = map;
  }
  public void Interact()
  {
    isOpen = !isOpen;
    map.ChangeCell(2, position, isOpen ? openTile : closedTile);
  }

}