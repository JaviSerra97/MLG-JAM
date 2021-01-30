using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public float Distance;
    public bool debug;
    public Transform myCamera;
    public Material outlineMaterial;
    public LayerMask interactibleLayer;

    private Interactible objectSeen;
    private RaycastHit hit;
    private Ray ray;

    void Update()
    {
        CheckObjectSeen();

        if (objectSeen != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                objectSeen.Execute();
            }
        }
        //ray = new Ray(transform.position, transform.forward);

        //if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Distance))
        //{
        //    if (hit.collider.tag == "Interactible")
        //    {
        //        hit.collider.gameObject.GetComponent<Interactible>().Execute();
        //    }
        //}
    }

    private Interactible CheckObjectSeen()
    {
        if (Physics.Raycast(myCamera.position, myCamera.forward, out hit, Distance, interactibleLayer))
        {
            if (objectSeen != null && hit.collider.GetComponent<Interactible>() != objectSeen)
            {
                objectSeen.SetMaterial(objectSeen.GetOriginalMaterial());
            }

            objectSeen = hit.collider.GetComponent<Interactible>();

            if (objectSeen != null)
            {
                objectSeen.SetMaterial(outlineMaterial);
            }
        }
        else
        {
            if (objectSeen != null)
            {
                objectSeen.SetMaterial(objectSeen.GetOriginalMaterial());
                objectSeen = null;
            }
        }

        return objectSeen;
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Debug.DrawRay(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward)* Distance, Color.red);
        }
    }  
}
