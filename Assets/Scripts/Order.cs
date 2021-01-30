using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<GameObject> orderToActivate;

    public void CheckOrder()
    {
        for(int i = 0; i < orderToActivate.Count; i++)
        {
            if (i == 0)
            {
                if (!orderToActivate[0].activeInHierarchy)
                    DeactivateAll();
            }
            else
            {
                if (orderToActivate[i].activeInHierarchy && !orderToActivate[i - 1].activeInHierarchy)
                {
                    DeactivateAll();
                }
            }
        }
    }

    private void DeactivateAll()
    {
        for (int i = 0; i < orderToActivate.Count; i++)
        {
            orderToActivate[i].SetActive(false);
        }
    }
}
