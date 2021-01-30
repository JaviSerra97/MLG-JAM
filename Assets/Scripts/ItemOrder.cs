using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOrder : MonoBehaviour
{
    Order order;

    void Awake()
    {
        order = GameObject.FindGameObjectWithTag("Order").GetComponent<Order>(); 
    }

    private void OnEnable()
    {
        order.CheckOrder();
    }

}
