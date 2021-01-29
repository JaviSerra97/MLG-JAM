using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public int hit;

    public void execute()
    {
        switch (hit)
        {
            case 0:
                Debug.Log("Cristal roto");
                break;
            case 1:
                Debug.Log("Cuchillo");
                break;
            case 2:
                Debug.Log("Osito de peluche");
                break;
        }
    }
}
