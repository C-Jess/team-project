using UnityEngine;
using System.Collections.Generic;

public class Item : ScriptableObject
{
    private string itemName {get; set;}
    private string itemDescription {get; set;}
    public int ID {get; set;}

    List<Item> Items = new List<Item>();

}