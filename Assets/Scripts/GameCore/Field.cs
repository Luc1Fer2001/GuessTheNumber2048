using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [Header("Field Properties")]
    public float cellSize;
    public float spacing;
    public int fieldSize;
    public int initCellsCount;

    [SerializeField] private Cell cellPrefab;
    [SerializeField] private RectTransform rectTransform;

    private Cell[,] field;

    private void Start()
    {
        GenerateField();
    }

    private void CreateField()
    {
        field = new Cell[fieldSize, fieldSize];

        float fieldWidthHeight = fieldSize * (cellSize + spacing) + spacing;
        rectTransform.sizeDelta = new Vector2(fieldWidthHeight, fieldWidthHeight);

        float startX = -(fieldWidthHeight / 2) + (cellSize / 2) + spacing;
        float startY = (fieldWidthHeight / 2) - (cellSize / 2) - spacing;

        for (int x = 0; x < fieldSize; x++)
        {
            for (int y = 0; y < fieldSize; y++)
            {
                var cell = Instantiate(cellPrefab, transform, false);
                var position = new Vector2(startX + (x * (cellSize + spacing)), startY - (y * (cellSize + spacing)));
                cell.transform.localPosition = position;

                field[x, y] = cell;

                cell.SetValue(x, y, 0);
            }
        }
    }

    public void GenerateField()
    {
        if(field == null)
        {
            CreateField();
        }

        for (int x = 0; x < fieldSize; x++)
        {
            for (int y = 0; y < fieldSize; y++)
            {
                field[x, y].SetValue(x, y, 0);
            }
        }

        for (int i = 0; i < initCellsCount; i++)
        {
            GenerateRandomCell();
        }
    }

    private void GenerateRandomCell()
    {
        var emptyCells = new List<Cell>();

        for (int x = 0; x < fieldSize; x++)
        {
            for (int y = 0; y < fieldSize; y++)
            {
                if(field[x, y].IsEmpty)
                {
                    emptyCells.Add(field[x, y]);
                }
            }
        }

        if(emptyCells.Count == 0)
        {
            throw new System.Exception("There is no any empty cell!");
        }

        int value = Random.Range(0, 10) == 0 ? 2 : 1;

        var cell = emptyCells[Random.Range(0, emptyCells.Count)];
        cell.SetValue(cell.X, cell.Y, value);
    }
}
