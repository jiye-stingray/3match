using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] _rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    private void Awake() => Instance = this;

    private void Start()
    {
        Tiles = new Tile[_rows.Max(row => row._tiles.Length), _rows.Length];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                var tile = _rows[y]._tiles[x];

                Tiles[x, y] = tile;
                tile.Item = ItemDatabase.Items[Random.Range(0,ItemDatabase.Items.Length)];
            }
        }
    }

}
