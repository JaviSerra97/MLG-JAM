using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public Interaction interaction;

    public void Execute()
    {
        if (interaction.itemNeeded == InventoryController.ItemType.none || InventoryController.instance.CheckItem(interaction.itemNeeded))
        {
            interaction.OnInteract.Invoke();

            for (int i = 0; i < interaction.addToInventory.Count; i++)
            {
                InventoryController.instance.AddItem(interaction.addToInventory[i]);
            }

            for (int i = 0; i < interaction.removeFromInventory.Count; i++)
            {
                InventoryController.instance.RemoveItem(interaction.removeFromInventory[i]);
            }

            for (int i=0; i < interaction.objectsToActivate.Count; i++)
            {
                interaction.objectsToActivate[i].SetActive(true);
            }

            for (int i = 0; i < interaction.objectsToDeactivate.Count; i++)
            {
                interaction.objectsToDeactivate[i].SetActive(false);
            }
        }
    }
}
