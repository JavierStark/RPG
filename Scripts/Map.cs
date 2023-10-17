using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Map : TileMap
{
	Dictionary<Vector2I, IInteractable> map = new Dictionary<Vector2I, IInteractable>();
	IFactory[] interactableFactories =
	{null, new InteractableFactory<PickableItem>(), new InteractableFactory<Door>() };

	public override void _Ready()
	{
		foreach (var cell in GetUsedCells((int)MapLayers.ITEMS))
		{
			int typeInteractable = GetCellTileData((int)MapLayers.ITEMS, cell).GetCustomData("TypeInteractable").AsInt16();

			IInteractable interactable = interactableFactories[typeInteractable].Create();

			map.Add(cell, interactable);
			interactable.Setup(cell, this);
		}
	}

	public override void _Process(double delta)
	{
	}

	public void Interact(Vector2I cell)
	{
		if (!map.ContainsKey(cell)) return;

		map[cell].Interact();
	}

	public void DeleteItem(Vector2I item)
	{
		EraseCell((int)MapLayers.ITEMS, item);
		map.Remove(item);
	}

	public void ChangeCell(int layer, Vector2I cell, Vector2I newTile)
	{
		SetCell(layer, cell, 0, newTile);
	}
}
