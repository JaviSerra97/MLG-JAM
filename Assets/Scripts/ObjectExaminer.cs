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

    private RaycastHit hit;
    private bool examining = false;
    private Vector3 posLastFrame;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Physics.Raycast(examineCamera.position, Vector3.forward, out hit, 100))
        {
            if (hit.collider.CompareTag("Examinable"))  // Crear una tag específica
            {
                // Shader?
            }
            else
            {
                // Quitar shader?
            }
        }

        
        if (examining)
        {
            if (Input.GetMouseButtonDown(0))
            {
                posLastFrame = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - posLastFrame;
                posLastFrame = Input.mousePosition;

                Vector3 axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
                currentExaminedObject.rotation = Quaternion.AngleAxis(delta.magnitude * rotationSpeed * Time.deltaTime, axis) * currentExaminedObject.rotation;
            }
        }
    }

    public void SetObjectToExamine(GameObject objectToExamine, string name)
    {
        currentExaminedObject = objectToExamine.transform;
        objectName.text = name;
        BeginExamine();
    }

    private void BeginExamine()
    {
        currentExaminedObject.gameObject.SetActive(true);
        currentExaminedObject.rotation = Quaternion.identity;
        examineObjectTexture.SetActive(true);
        examining = true;
    }

    public void EndExamine()
    {
        currentExaminedObject.gameObject.SetActive(false);
        examineObjectTexture.SetActive(false);
        examining = false;
    }
}
