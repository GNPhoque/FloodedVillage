using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]
	float padding;
	[SerializeField]
	int rows, columns;
	[SerializeField]
	GameObject cellPrefab;

	Transform t;
	GameObject[,] grid;

	private void Awake()
	{
		t = GetComponent<Transform>();
	}

	private void Start()
	{
		GenerateGrid();
	}

	void GenerateGrid()
	{
		grid = new GameObject[rows, columns];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{

				GameObject cell = Instantiate(cellPrefab, t);
				cell.transform.position = new Vector2(row * (1 + padding), col * (1 + padding));
				grid[row, col] = cell;
			}
		}
	}
}
