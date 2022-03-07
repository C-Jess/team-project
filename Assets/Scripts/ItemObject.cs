using UnityEngine;
using System.Collections.Generic;

public enum ItemType
{
    Tool,
    Object,
    Puzzle
}

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Inventory System/Item")]
public class ItemObject : ScriptableObject
{
    public ItemType type;
    public GameObject model;
    public Sprite sprite;
    [TextArea(10,15)]
    public string description;
}