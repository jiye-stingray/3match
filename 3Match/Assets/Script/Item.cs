using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Match-3/Item")]
public class Item : ScriptableObject 
{
    private int _value; public int Value { get { return _value; } set { _value = value; } }
    public Sprite _sprite;
}
