using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinable : MonoBehaviour
{
    public string objectName;
    public GameObject objectToExamine;

    public void ExamineObject()
    {
        ObjectExaminer.instance.SetObjectToExamine(objectToExamine, objectName);
    }
}
