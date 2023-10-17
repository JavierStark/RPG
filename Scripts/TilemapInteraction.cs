using Godot;
using System;

public partial class TilemapInteraction : Node2D
{
	Vector2I targeterAtlasCoord = new Vector2I(25, 14);

	Map tilemap;
	Node2D entity;
	Timer targeterTimer;
	Vector2I lastTargeterPosition;

	bool isInteracting = false;


	public override void _Ready()
	{
		tilemap = GetNode<Map>("%Map");
		entity = GetParent<Node2D>();
		targeterTimer = GetChild<Timer>(0);

		targeterTimer.Timeout += DeactivateTargeter;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void Interact(Vector2I direction)
	{
		if (isInteracting) return;
		isInteracting = true;
		Vector2I currentPosition = tilemap.LocalToMap(entity.GlobalPosition);
		Vector2I targetGridPosition = currentPosition + direction;

		ActivateTargeter(targetGridPosition);

		TileData data = tilemap.GetCellTileData((int)MapLayers.ITEMS, targetGridPosition);

		if (data == null) return;

		bool isInteractable = data.GetCustomData("Interactable").AsBool();

		if (!isInteractable) return;

		tilemap.Interact(targetGridPosition);
	}

	private void ActivateTargeter(Vector2I cell)
	{
		DeactivateTargeter();
		lastTargeterPosition = cell;
		tilemap.SetCell((int)MapLayers.UI, cell, 0, targeterAtlasCoord);
		targeterTimer.Start();
	}


	public void DeactivateTargeter()
	{
		tilemap.EraseCell((int)MapLayers.UI, lastTargeterPosition);
	}

	public void ResetInteraction()
	{
		isInteracting = false;
	}
}
