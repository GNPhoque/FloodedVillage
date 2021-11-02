using System;
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
	Cell cellPrefab;

	Transform t;
	Cell[,] grid;

	private void Awake()
	{
		t = GetComponent<Transform>();
	}

	private void Start()
	{
		GenerateGrid();
		SetCamera();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//RunSimulation();
		}
	}

	private void SetCamera()
	{
		Vector3 cameraPos = grid[rows - 1, columns - 1].transform.position / 2f;
		float cameraRatio = Camera.main.aspect;
		Camera.main.transform.position = new Vector3(cameraPos.x + .5f, cameraPos.y + .5f, -10f);
		if (cameraPos.x > cameraPos.y * cameraRatio)
		{
			Camera.main.orthographicSize = (cameraPos.x + 0.5f + (2 * padding)) / cameraRatio;
		}
		else
		{
			Camera.main.orthographicSize = cameraPos.y + 0.5f + 2 * padding;
		}
	}

	void GenerateGrid()
	{
		grid = new Cell[rows, columns];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				Cell cell = Instantiate(cellPrefab, new Vector2(col * (1 + padding), row * (1 + padding)), Quaternion.identity, t);
				cell.name = $"{row}, {col}";
				grid[row, col] = cell;
			}
		}
	}

	bool IsAnyNeighbourWater(int row, int col)
	{
		for (int i = -1; i <= 1; i+=2)
		{
			for (int j = -1; j <= 1; j+=2)
			{
				if (IsInGrid(row + i, col + j))
				{
					if (grid[row + i, col + j].Type == CellType.Water)
					{
						return true;
					}
				}
			}
		}
		return false; ;
	}

	bool IsInGrid(int i, int j)
	{
		return i >= 0 && i < rows && j >= 0 && j < columns;
	}
}
