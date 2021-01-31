using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectExaminer : MonoBehaviour
{
    public static ObjectExaminer instance;

    public Transform currentExaminedObject;
    public Transform examineCamera;
    public float rotationSpeed;
    public GameObject examineObjectTexture;
    public Text objectName;

    public Material outlineMaterial;

    private RaycastHit hit;
    private bool examining = false;
    private Vector3 posLastFrame;
    private bool interactionAvailable = false;
    private bool blocked = false;

    private Examinable currentExaminable;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!blocked)
        {
            CheckExaminable();
        
            if (interactionAvailable)
            {
                CheckInteraction();
            }


            if (examining)
            {
                Examine();
            }
        }
    }

    private void CheckExaminable()
    {
        if (Physics.Raycast(examineCamera.position, Vector3.forward, out hit, 100))
        {
            if (hit.collider.CompareTag("Examinable"))
            {
                currentExaminable = hit.collider.GetComponent<Examinable>();
                currentExaminable.SetMaterial(outlineMaterial);
                interactionAvailable = true;
            }
            else
            {
                if (interactionAvailable)
                {
                    currentExaminable.SetMaterial(currentExaminable.GetOriginalMaterial());

                    interactionAvailable = false;
                }
            }
        }
    }

    private void CheckInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit.collider.GetComponent<Interactible>().Execute();
        }
    }

    private void Examine()
    {
        if (Input.GetMouseButtonDown(1))
        {
            posLastFrame = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - posLastFrame;
            posLastFrame = Input.mousePosition;

            Vector3 axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            currentExaminedObject.rotation = Quaternion.AngleAxis(delta.magnitude * rotationSpeed * Time.deltaTime, axis) * currentExaminedObject.rotation;
        }
    }


    public void SetObjectToExamine(GameObject objectToExamine)
    {
        currentExaminedObject = objectToExamine.transform;
        BeginExamine();
    }

    private void BeginExamine()
    {
        //currentExaminedObject.rotation = Quaternion.identity;
        currentExaminedObject.gameObject.SetActive(true);
        examineObjectTexture.SetActive(true);
        examining = true;
    }

    public void EndExamine()
    {
        currentExaminedObject.gameObject.SetActive(false);
        examineObjectTexture.SetActive(false);
        examining = false;
    }

    public void BlockActions()
    {
        blocked = true;
    }

    public void UnblockActions()
    {
        blocked = false;
    }
}