using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	[SerializeField]
	SpriteArray sprites;
	[SerializeField]
	SpriteRenderer rend;
	[SerializeField]
	private CellType _type;

	private CellType nextType;

	public CellType Type
	{
		get { return _type; }
		private set 
		{ 
			_type = value;
			SetSprite();
			nextType = Type;
		}
	}


	private void Start()
	{
		Type = Type;
		//SetSprite();
		//Type = CellType.Empty;
	}

	private void OnMouseUpAsButton()
	{
		if (Type == CellType.Sand)
		{
			Type = CellType.Empty;
		}
	}

	void SetSprite()
	{
		int spriteIndex;
		switch (Type)
		{
			case CellType.Empty:
				spriteIndex = 0;
				break;
			case CellType.Water:
				spriteIndex = 1;
				break;
			case CellType.Sand:
				spriteIndex = 2;
				break;
			case CellType.Stone:
				spriteIndex = 3;
				break;
			case CellType.Seeds:
				spriteIndex = 4;
				break;
			case CellType.Crops:
				spriteIndex = 5;
				break;
			default:
				spriteIndex = 0;
				break;
		}
		rend.sprite = sprites.Sprites[spriteIndex];
	}

	/// <summary>
	/// Give water to this cell
	/// </summary>
	public void FloodCell()
	{
		//if ((Type & (CellType.Empty | CellType.Seeds | CellType.Villager | CellType.Zombie)) != 0)
		if (Type == CellType.Empty)
		{
			nextType = CellType.Water;
		}
		if (Type == CellType.Seeds)
		{
			nextType = CellType.Crops;
		}
	}

	public void ApplySimulation()
	{
		Type = nextType;
	}
}
