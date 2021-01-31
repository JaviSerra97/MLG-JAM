using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    public string objectName;
    public GameObject objectToExamine;

    private Renderer objectRenderer;
    private Material originalMaterial;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    public void ExamineObject()
    {
        ObjectExaminer.instance.SetObjectToExamine(objectToExamine);
    }

    public Material GetOriginalMaterial()
    {
        return originalMaterial;
    }

    public void SetMaterial(Material material)
    {
        objectRenderer.material = material;
    }
}
