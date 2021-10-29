using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpriteArray : ScriptableObject
{
	[SerializeField]
	Sprite[] sprites;

	public Sprite[] Sprites { get => sprites; }
}
