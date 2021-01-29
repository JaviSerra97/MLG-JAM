using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public float seeDistance;
    public Transform myCamera;
    public LayerMask itemLayer;

    private RaycastHit hit;

    private void OnDrawGizmos()
    {
        Debug.DrawRay(myCamera.position, myCamera.forward);
    }

    private void Update()
    {
        CheckObjectSeen();
    }

    private void CheckObjectSeen()
    {
        if (Physics.Raycast(myCamera.position, myCamera.forward, out hit, seeDistance, itemLayer))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hit.collider.GetComponent<Item>().Collect();
            }
        }
    }
}
