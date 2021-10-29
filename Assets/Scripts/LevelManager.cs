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
		SetCamera();
	}

	private void SetCamera()
	{
		Vector3 cameraPos = grid[rows - 1, columns - 1].transform.position / 2f;
		float cameraRatio = Camera.main.aspect;
		Camera.main.transform.position = new Vector3(cameraPos.x, cameraPos.y, -10f);
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
		grid = new GameObject[rows, columns];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{

				GameObject cell = Instantiate(cellPrefab, t);
				cell.transform.position = new Vector2(row * (1 + padding), col * (1 + padding));
				cell.name = $"{row}, {col}";
				grid[row, col] = cell;
			}
		}
	}
}
