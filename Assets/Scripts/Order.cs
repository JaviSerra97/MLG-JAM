using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<GameObject> orderToActivate;

    public GameObject note;

    public GameObject cage;

    public GameObject cageFinal;

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

                else if(i == 4 && orderToActivate[i].activeInHierarchy && orderToActivate[i - 1].activeInHierarchy)
                {
                    note.SetActive(true);

                    cage.SetActive(false);
                    cageFinal.SetActive(true);
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
