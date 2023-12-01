using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private int x; public int X { get { return x; } set { x = value; } }
    private int y; public int Y { get { return y; } set { y = value; } }

    private Item _item;
    public Item Item 
    { 
        get => _item; 
        set { 
            if (_item == value) return; 
            _item = value;
            _icon.sprite = _item._sprite;
        }
    }

    public Image _icon;
    public Button _button;

    private void Start()
    {
        _button.onClick.AddListener(() => Board.Instance.Select(this));
    }
}
