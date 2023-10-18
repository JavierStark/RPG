using Godot;
using System;

public partial class InventorySlot : Panel
{
	Control selector;

	public override void _Ready()
	{
		selector = GetNode<Control>("Selector");
		ExitHover();
	}

	public void EnterHover()
	{
		selector.Show();
	}
	public void ExitHover()
	{
		selector.Hide();
	}
}
