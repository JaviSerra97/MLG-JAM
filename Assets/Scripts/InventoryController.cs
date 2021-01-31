using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public enum ItemType
    {
        none, notaOsito, hammer, book1, book2, book3, book4, nota1, nota2, nota3, rope, card
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
                currentItem.GetComponent<Image>().color = Color.green;

                break;

            case ItemType.book1:
                currentItem.GetComponent<Image>().sprite = spriteList[2];

                break;

            case ItemType.book2:
                currentItem.GetComponent<Image>().sprite = spriteList[3];

                break;

            case ItemType.book3:
                currentItem.GetComponent<Image>().sprite = spriteList[4];

                break;

            case ItemType.book4:
                currentItem.GetComponent<Image>().sprite = spriteList[5];

                break;

            case ItemType.rope:
                currentItem.GetComponent<Image>().sprite = spriteList[6];

                break;

            case ItemType.card:
                currentItem.GetComponent<Image>().color = Color.green;

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
