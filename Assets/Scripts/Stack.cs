using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public float distance, weight;
    public Transform Tstack1, Tstack2;
    public List<GameObject> CorrectStack1, CorrectStack2;
    public List<GameObject> ultimate, stack1, stack2;
    private int position1,position2, iterator, nObjects;
    private GameObject pivot;

    private void Awake()
    {
        pivot = GameObject.FindGameObjectWithTag("PivotWeightScale");
        nObjects = CorrectStack1.Count + CorrectStack2.Count;
    }

    public void Heap(bool left)
    {

        ultimate = InventoryController.instance.ultimateDestroyObject;
        iterator = InventoryController.instance.GetPutted();

        if (left)
        {
            for (int i = iterator; i < ultimate.Count; i++)
            {
                stack1.Add(ultimate[i]);
                pivot.transform.Rotate(new Vector3(0, 0, weight));
                InventoryController.instance.AddPutted();
                ultimate[i].SetActive(true);
                ultimate[i].GetComponent<Interactible>().FinishInteration();
            }
        }
        else
        {
            for (int i = iterator; i < ultimate.Count; i++)
            {
                stack2.Add(ultimate[i]);
                pivot.transform.Rotate(new Vector3(0, 0, -1*weight));
                InventoryController.instance.AddPutted();
                ultimate[i].SetActive(true);
                ultimate[i].GetComponent<Interactible>().FinishInteration();
            }
        }

        for (int i = 0; i < stack1.Count; i++)
        {
            Debug.Log("Stack1");
            stack1[i].transform.position = new Vector3(Tstack1.position.x, Tstack1.position.y + 0.2f + (position1 * distance), Tstack1.position.z);
            position1++;
        }
        position1 = 0;

        for (int i = 0; i < stack2.Count; i++)
        {
            Debug.Log("Stack2");
            stack2[i].transform.position = new Vector3(Tstack2.position.x, Tstack2.position.y + 0.1f+(position2 * distance), Tstack2.position.z);
            position2++;
        }
        position2 = 0;

        if ((stack1.Count + stack2.Count) == nObjects)
            checkBooks();
    }
   
    public void checkBooks()
    {
            bool reset = false;
            if ((stack1.Count == CorrectStack1.Count) && (stack2.Count == CorrectStack2.Count))
            {
                 
                    for(int i = 0; i < stack1.Count; i++)
                    {
                        if (!stack1.Contains(CorrectStack1[i]))
                        {
                            reset = true;
                            Debug.Log("Stack1 no contiene: " + CorrectStack1[i]);
                        }
                    }

                    for (int i = 0; i < stack2.Count; i++)
                    {
                        if (!stack2.Contains(CorrectStack2[i]))
                        {
                            reset = true;
                            Debug.Log("Stack2 no contiene: " + CorrectStack2[i]);
                        }
                    }
            }
            else
            {
                reset = true;
            }

            if (reset)
                Invoke("ResetHeap",2f);

    }

    public void ResetHeap()
    {
        Debug.Log("ResetHeap");
        
        for (int i = 0; i < ultimate.Count; i++)
        {
            ultimate[i].transform.position = ultimate[i].GetComponent<Interactible>().GetInitialPosition();
            ultimate[i].GetComponent<Interactible>().RestartInteraction();
        }
        pivot.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        stack1.Clear();
        stack2.Clear();
        ultimate.Clear();
        iterator = 0;
        InventoryController.instance.SetPutted(0);
        
    }
}
