using Godot;
using System;

public partial class MenuManager : Node2D
{
	Inventory inventory;
	bool activeInventory = false;
	public override void _Ready()
	{
		inventory = GetNode<Inventory>("%Inventory");
		inventory.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventKey eventKey)
		{
			if (!PressedButNotHold(eventKey)) return;

			if (eventKey.Keycode == Key.E)
			{
				activeInventory = !activeInventory;
				inventory.Visible = activeInventory;
				GameState.isInMenu = activeInventory;
			}

			if (!activeInventory) return;

			if (eventKey.Keycode == Key.Right)
				inventory.MoveSelector(Vector2I.Right);
			if (eventKey.Keycode == Key.Left)
				inventory.MoveSelector(Vector2I.Left);
			if (eventKey.Keycode == Key.Up)
				inventory.MoveSelector(Vector2I.Up);
			if (eventKey.Keycode == Key.Down)
				inventory.MoveSelector(Vector2I.Down);
		}
	}

	private static bool PressedButNotHold(InputEventKey eventKey)
	{
		return eventKey.Pressed && !eventKey.Echo;
	}

}
