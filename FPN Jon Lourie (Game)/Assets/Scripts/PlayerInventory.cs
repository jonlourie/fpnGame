using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory

    //having the list property just be a getter with no setter means its a read only property 
{
    public static List<InventoryObject> InventoryObjects { get; } = new List<InventoryObject>();
}
