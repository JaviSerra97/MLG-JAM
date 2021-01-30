using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorkboardController : MonoBehaviour
{
    public static CorkboardController instance;

    [Header("Prop")]
    public GameObject note1, note2, note3, note4;

    [Header("Examinando")]
    public GameObject note1Examine, note2Examine, note3Examine, note4Examine;

    private void Awake()
    {
        instance = this;
    }

    public void PlaceNotes()
    {
        if (InventoryController.instance.CheckItem(InventoryController.ItemType.notaOsito))
        {
            note1.SetActive(true);
            note1Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.notaOsito);
        }

        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota2))
        {
            note2.SetActive(true);
            note2Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota2);
        }
        
        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota3))
        {
            note3.SetActive(true);
            note3Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota3);
        }

        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota4))
        {
            note4.SetActive(true);
            note4Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota4);
        }
    }
}
