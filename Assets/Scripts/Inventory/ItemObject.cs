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
    public GameObject prefab;
    public Sprite sprite;
    [TextArea(10,15)]
    public string description;
    public bool isInventoryItem;

    [Header("Extra")]
    public LevelFlags levelFlags;
    public string flagToCheck;
    public string ifTrue;
    public string ifFalse;

    public string FullDescription()
    {
        if (levelFlags == null || string.IsNullOrEmpty(flagToCheck))
        {
            return description;
        }
        else
        {
            return description + (levelFlags.GetFlag(flagToCheck) ? ifTrue : ifFalse);
        }
    }
}