using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public float distance;
    private int position, iterator;

    public void Heap()
    {
        List<GameObject> ultimate = InventoryController.instance.ultimateDestroyObject;
        Debug.Log("ultimate: " + ultimate);
        iterator = InventoryController.instance.GetPutted();
        for (int i = iterator; i < ultimate.Count; i++)
        {
            ultimate[i].transform.position = new Vector3(transform.position.x, transform.position.y+(position*distance), transform.position.z);
            ultimate[i].SetActive(true);
            ultimate[i].GetComponent<Interactible>().FinishInteration();
            InventoryController.instance.SetPutted();
            position++;
        }
    }
}
