using Godot;
using System;

public partial class Player : Sprite2D
{
	bool moving = false;
	TilemapMovement tilemapMovement;
	TilemapInteraction tilemapInteraction;

	public override void _Ready()
	{
		tilemapMovement = GetChild<TilemapMovement>(0);
		tilemapInteraction = GetChild<TilemapInteraction>(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GameState.isInMenu) return;

		if (Input.IsKeyPressed(Key.A))
		{
			tilemapMovement.Move(Vector2I.Left);
		}
		else if (Input.IsKeyPressed(Key.D))
		{
			tilemapMovement.Move(Vector2I.Right);
		}
		else if (Input.IsKeyPressed(Key.W))
		{
			tilemapMovement.Move(Vector2I.Up);
		}
		else if (Input.IsKeyPressed(Key.S))
		{
			tilemapMovement.Move(Vector2I.Down);
		}
		else
		{
			tilemapMovement.ResetMovement();
		}

		if (Input.IsKeyPressed(Key.Left))
		{
			tilemapInteraction.Interact(Vector2I.Left);
		}
		else if (Input.IsKeyPressed(Key.Right))
		{
			tilemapInteraction.Interact(Vector2I.Right);
		}
		else if (Input.IsKeyPressed(Key.Up))
		{
			tilemapInteraction.Interact(Vector2I.Up);
		}
		else if (Input.IsKeyPressed(Key.Down))
		{
			tilemapInteraction.Interact(Vector2I.Down);
		}
		else
		{
			tilemapInteraction.ResetInteraction();
		}

	}
}
