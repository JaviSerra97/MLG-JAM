﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public enum ItemType
    {
        none, notaOsito, hammer, nota1, nota2, nota3, rope, card, libro_rojo, libro_verde, libro_azul, libro_rosa, libro_amarillo, nota4
    }

    public static InventoryController instance;

    public GameObject InventoryItemPrefab;
    public Transform InventoryParent;
    public List<Sprite> spriteList;

    private GameObject currentItem;   // Esto en realidad es la imagen del objeto
    private List<ItemType> itemList;
    private List<GameObject> itemImageList;


    private int putted;
    public List<GameObject> ultimateDestroyObject;


    private void Awake()
    {
        instance = this;
        itemList = new List<ItemType>();
        itemImageList = new List<GameObject>();
        putted = 0;
    }

    public void AddItem(ItemType type)
    {
        currentItem = Instantiate(InventoryItemPrefab, InventoryParent);
        itemList.Add(type);
        itemImageList.Add(currentItem);
        //AudioManager.instance.playGrab();

        switch (type)
        {
            case ItemType.notaOsito:
                currentItem.GetComponent<Image>().sprite = spriteList[0];

                break;

            case ItemType.nota1:
                currentItem.GetComponent<Image>().sprite = spriteList[0];

                break;

            case ItemType.nota2:
                currentItem.GetComponent<Image>().sprite = spriteList[0];

                break;

            case ItemType.nota3:
                currentItem.GetComponent<Image>().sprite = spriteList[0];

                break;

            case ItemType.hammer:
                currentItem.GetComponent<Image>().sprite = spriteList[1];

                break;

            case ItemType.libro_azul:
                currentItem.GetComponent<Image>().sprite = spriteList[5];

                break;

            case ItemType.libro_amarillo:
                currentItem.GetComponent<Image>().sprite = spriteList[4];

                break;

            case ItemType.libro_rosa:
                currentItem.GetComponent<Image>().sprite = spriteList[6];

                break;

            case ItemType.libro_verde:
                currentItem.GetComponent<Image>().sprite = spriteList[2];

                break;

            case ItemType.libro_rojo:
                currentItem.GetComponent<Image>().sprite = spriteList[3];

                break;

            case ItemType.rope:
                currentItem.GetComponent<Image>().sprite = spriteList[7];

                break;

            case ItemType.card:
                currentItem.GetComponent<Image>().sprite = spriteList[8];

                break;

            case ItemType.nota4:
                currentItem.GetComponent<Image>().sprite = spriteList[0];

                break;

            default:
                currentItem.GetComponent<Image>().color = Color.green;

                break;
        }
    }

    public void RemoveItem(ItemType type)
    {
        // Borra el objeto para no poder usarlo más
        if (CheckItem(type))
        {
            int index = itemList.IndexOf(type);
            itemList.Remove(type);

            // Borra el item de la interfaz
            Destroy(itemImageList[index]);
            itemImageList.RemoveAt(index);
        }
    }

    public bool CheckItem(ItemType type)
    {
        for (int i=0; i < itemList.Count; i++)
        {
            Debug.Log(itemList[i]);
        }
        Debug.Log(itemList.Contains(type));
        return itemList.Contains(type);
    }

    public void AddPutted()
    {
        putted++;
    }

    public void SetPutted(int put)
    {
        putted = put;
    }

    public int GetPutted()
    {
        return putted;
    }
}
