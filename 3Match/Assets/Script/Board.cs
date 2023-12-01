using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] _rows;

    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    private readonly List<Tile> _selectionTileList = new List<Tile>();

    private const float _tweenDuration = 0.25f;

    private void Awake() => Instance = this;

    private void Start()
    {
        Tiles = new Tile[_rows.Max(row => row._tiles.Length), _rows.Length];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                var tile = _rows[y]._tiles[x];

                tile.X = x;
                tile.Y = y;


                tile.Item = ItemDatabase.Items[Random.Range(0,ItemDatabase.Items.Length)];
                Tiles[x, y] = tile;

            }
        }
    }

    public void Select(Tile tile)
    {
        if(!_selectionTileList.Contains(tile)) _selectionTileList.Add(tile);


        if (_selectionTileList.Count < 2) return;

        Debug.Log($"Selected Tiles at ({_selectionTileList[0].X},{_selectionTileList[0].Y} and {_selectionTileList[1].X},{_selectionTileList[1].Y})");

        _selectionTileList.Clear();
    }

    public async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1._icon;
        var icon2 = tile2._icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;


        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, _tweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, _tweenDuration));

        await sequence.Play().AsyncWaitForCompletion();


        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1._icon = icon2;
        tile2._icon = icon1;


        (tile1.Item, tile2.Item) = (tile2.Item, tile1.Item);        // Swap
    }
}
