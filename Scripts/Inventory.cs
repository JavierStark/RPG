using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Inventory : Control
{
	[Export]
	GridContainer grid;
	List<List<InventorySlot>> slots = new List<List<InventorySlot>>();
	Vector2I currentPos = Vector2I.Zero;
	public override void _Ready()
	{
		GD.Print(grid);

		GetInventorySlots();
		slots[0][0].EnterHover();
	}
	public override void _Process(double delta)
	{
	}
	private void GetInventorySlots()
	{
		var allSlots = grid.GetChildren().ToList();
		int columns = grid.Columns;

		List<InventorySlot> newRow = new List<InventorySlot>();
		allSlots.ForEach((s) =>
		{
			newRow.Add(s as InventorySlot);
			if (newRow.Count == columns)
			{
				slots.Add(new List<InventorySlot>(newRow));
				newRow.Clear();
			}
		});

		if (newRow.Count > 0) slots.Add(newRow);
	}

	public void MoveSelector(Vector2I dir)
	{
		var current = slots[currentPos.Y][currentPos.X];

		if (current != null) current.ExitHover();

		SetNewPosition(dir);

		InventorySlot newSlotHovered = slots[currentPos.Y][currentPos.X];
		newSlotHovered.EnterHover();
	}
	public void SetNewPosition(Vector2I dir)
	{
		currentPos += dir;
		if (currentPos.X >= slots[0].Count) currentPos.X = 0;
		else if (currentPos.X < 0) currentPos.X = slots[0].Count - 1;

		if (currentPos.Y >= slots.Count) currentPos.Y = 0;
		else if (currentPos.Y < 0) currentPos.Y = slots.Count - 1;
	}
}
