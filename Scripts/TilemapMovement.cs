using Godot;
using System;

public partial class TilemapMovement : Node2D
{
	bool moving = false;
	Map tilemap;
	Node2D entity;


	public override void _Ready()
	{
		tilemap = GetNode<Map>("%Map");
		entity = GetParent<Node2D>();
	}

	public void Move(Vector2I direction)
	{
		if (moving) return;
		moving = true;

		Vector2I currentPosition = tilemap.LocalToMap(entity.GlobalPosition);
		Vector2I targetGridPosition = currentPosition + direction;

		TileData data = tilemap.GetCellTileData((int)MapLayers.GROUND, targetGridPosition);
		if (data != null)
		{
			bool isWall = data.GetCustomData("Walkable").AsBool();

			if (!isWall) return;
		}

		data = tilemap.GetCellTileData((int)MapLayers.ITEMS, targetGridPosition);
		if (data != null)
		{
			bool isWall = data.GetCustomData("Walkable").AsBool();

			if (!isWall) return;
		}

		var targetPosition = tilemap.MapToLocal(targetGridPosition);
		entity.GlobalPosition = targetPosition;
	}

	public void ResetMovement()
	{
		moving = false;
	}
}
