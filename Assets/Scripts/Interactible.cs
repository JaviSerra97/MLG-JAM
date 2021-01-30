using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public Interaction interaction;
    private bool interactive;
    private Vector3 InitialPosition;

    private Renderer objectRenderer;
    private Material originalMaterial;

    private void Awake()
    {
        interactive = true;
<<<<<<< Updated upstream
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
=======
        InitialPosition = gameObject.transform.position;
>>>>>>> Stashed changes
    }

    public void Execute()
    {
        if (interactive)
        {
            if (interaction.itemNeeded == InventoryController.ItemType.none || InventoryController.instance.CheckItem(interaction.itemNeeded))
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
                    InventoryController.instance.ultimateDestroyObject.Add(interaction.objectsToDeactivate[i]);
                }

                interaction.OnInteract.Invoke();
            }
        }
    }

    public void FinishInteration()
    {
        interactive = false;
    }

    public void RestartInteraction()
    {
        interactive = true;
    }

<<<<<<< Updated upstream
    public Material GetOriginalMaterial()
    {
        return originalMaterial;
    }

    public void SetMaterial(Material material)
    {
        objectRenderer.material = material;
=======
    public Vector3 GetInitialPosition()
    {
        return InitialPosition;
>>>>>>> Stashed changes
    }
}
