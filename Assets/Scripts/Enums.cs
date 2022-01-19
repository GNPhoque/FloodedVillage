using System;

[Flags]
public enum CellType
{
	Empty = 1,
	Water = 2,
	Sand = 4,
	Stone = 8,
	Seeds = 16,
	Crops = 32,

	Floodable = Empty | Seeds
}

public class Enums
{
}
