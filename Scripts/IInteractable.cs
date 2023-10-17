using Godot;

interface IInteractable
{
  public void Setup(Vector2I position, Map map);
  public void Interact();
}