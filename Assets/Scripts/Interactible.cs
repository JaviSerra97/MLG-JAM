using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public Interaction interaction;
    private bool interactive;
    private Vector3 InitialPosition;
    private Quaternion InitialRotation;

    private Renderer objectRenderer;
    private Material originalMaterial;

    public bool isNote;

    private void Awake()
    {
        interactive = true;
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
        InitialPosition = gameObject.transform.position;
        InitialRotation = gameObject.transform.rotation;

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
                    if (GetLabel() == "libro_rojo" || GetLabel() == "libro_verde" || GetLabel() == "libro_azul" || GetLabel() == "libro_rosa" || GetLabel() == "libro_amarillo")
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

    public Material GetOriginalMaterial()
    {
        return originalMaterial;
    }

    public void SetMaterial(Material material)
    {
        if (!isNote)
        {
            objectRenderer.material = material;
        }
    }

    public Vector3 GetInitialPosition()
    {
        return InitialPosition;
    }

    public Quaternion GetInitialRotation()
    {
        return InitialRotation;
    }

    public string GetLabel()
    {
        return interaction.label;
    }
}
    
