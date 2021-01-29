using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public enum ItemType
    {
        type1, type2, type3
    }

    public static InventoryController instance;

    public GameObject InventoryItemPrefab;
    public Transform InventoryParent;

    private GameObject currentItem;   // Esto en realidad es la imagen del objeto
    private List<ItemType> itemList;
    private List<GameObject> itemImageList;

    private void Awake()
    {
        instance = this;
        itemList = new List<ItemType>();
        itemImageList = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RemoveItem(ItemType.type1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            RemoveItem(ItemType.type2);
        }
    }

    public void AddItem(ItemType type)
    {
        currentItem = Instantiate(InventoryItemPrefab, InventoryParent);
        itemList.Add(type);
        itemImageList.Add(currentItem);

        switch (type)
        {
            case ItemType.type1:
                currentItem.GetComponent<Image>().color = Color.red;

                break;
            case ItemType.type2:
                currentItem.GetComponent<Image>().color = Color.green;

                break;

            case ItemType.type3:
                currentItem.GetComponent<Image>().color = Color.blue;

                break;

            default:
                break;
        }
    }

    public void RemoveItem(ItemType type)
    {
        // Borra el objeto para no poder usarlo más
        int index = itemList.IndexOf(type);
        itemList.Remove(type);

        // Borra el item de la interfaz
        Destroy(itemImageList[index]);
        itemImageList.RemoveAt(index);
    }

    public bool CheckItem(ItemType type)
    {
        return itemList.Contains(type);
    }
}
