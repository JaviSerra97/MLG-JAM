using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public string label;
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;
    public List<InventoryController.ItemType> addToInventory;
    public List<InventoryController.ItemType> removeFromInventory;
}
