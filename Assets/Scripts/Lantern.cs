using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public float Distance;
    public bool debug;

    private RaycastHit hit;
    private Ray ray;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Distance))
        {
            if (hit.collider.tag == "Interactible")
            {
                hit.collider.gameObject.GetComponent<Interactible>().execute();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.white, Distance);
        }
    }  
}
