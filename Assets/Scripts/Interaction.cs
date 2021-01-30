using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Interaction
{
    public string label;
    public InventoryController.ItemType itemNeeded;
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;
    public List<InventoryController.ItemType> addToInventory;
    public List<InventoryController.ItemType> removeFromInventory;
    public UnityEvent OnInteract;
}
