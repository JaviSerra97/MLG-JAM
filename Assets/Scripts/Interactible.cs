using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public Interaction interaction;

    public void Execute()
    {
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
