using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private int x; public int X { get { return x; } set { x = value; } }
    private int y; public int Y { get { return y; } set { y = value; } }

    public Item _item;
    public Image _icon;
    public Button _button;
}
