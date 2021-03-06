﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorkboardController : MonoBehaviour
{
    public static CorkboardController instance;

    [Header("Prop")]
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;

    public GameObject fakeMirror;
    public GameObject mirror;

    private int notesCounter = 0;

    /*
    [Header("Examinando")]
    public GameObject note1Examine;
    public GameObject note2Examine;
    public GameObject note3Examine;
    public GameObject note4Examine;
    */

    private void Awake()
    {
        instance = this;
    }

    public void PlaceNotes()
    {
        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota4))
        {
            note4.SetActive(true);
            notesCounter++;
            //note1Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota4);
        }

        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota1))
        {
            note1.SetActive(true);
            notesCounter++;
            //note2Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota1);
        }
        
        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota2))
        {
            note2.SetActive(true);
            notesCounter++;
            //note3Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota2);
        }

        if (InventoryController.instance.CheckItem(InventoryController.ItemType.nota3))
        {
            note3.SetActive(true);
            notesCounter++;
            //note4Examine.SetActive(true);
            InventoryController.instance.RemoveItem(InventoryController.ItemType.nota3);
        }

        if(notesCounter == 4)
        {
            fakeMirror.SetActive(false);
            mirror.SetActive(true);
        }
    }
}
