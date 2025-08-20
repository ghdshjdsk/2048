using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public TileRow[] Rows { get; private set; }
    public TileCell[] cells { get; private set; }

    public int size => cells.Length;
    public int height => Rows.Length;
    public int width => size / height;
    void Awake()
    {
        Rows = this.GetComponentsInChildren<TileRow>();
        cells = this.GetComponentsInChildren<TileCell>();
    }

    void Start()
    {
        for (int y = 0; y < Rows.Length; y++)
        {
            for (int x = 0; x < Rows[y].cells.Length; x++)
            {
                Rows[y].cells[x].coordinates = new Vector2Int(x, y);
            }
        }
    }

    public TileCell GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return Rows[y].cells[x];
        }
        else { return null; }
    }

    public TileCell GetCell(Vector2Int direction)
    {
        return GetCell(direction.x, direction.y);
    }

    public TileCell GetAdjacentCell(TileCell cell, Vector2Int direction)
    {
        Vector2Int coordinates = cell.coordinates;
        coordinates.x += direction.x;
        coordinates.y -= direction.y;
        return GetCell(coordinates);
    }

    public TileCell GetRandomEmptyCell()
    {
        int index = Random.Range(0, cells.Length);
        int startingIndex = index;
        while (cells[index].occupied)
        {
            index++;
            if (index >= cells.Length)
            {
                index = 0;
            }
            if (index == startingIndex)
            {
                return null;
            }
        }
        return cells[index];
    }

    public TileCell GetTileCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return Rows[y].cells[x];
        }
        else
        {
            return null;
        }
    }


}
