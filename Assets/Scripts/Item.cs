using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public InventoryController.ItemType type;

    public void Collect()
    {
        InventoryController.instance.AddItem(type);

        gameObject.SetActive(false);
    }
}
