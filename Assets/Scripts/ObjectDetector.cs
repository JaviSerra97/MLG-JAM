using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    public float seeDistance;
    public Transform myCamera;
    public LayerMask examinableLayer;

    private RaycastHit hit;
    private Examinable objectSeen = null;
    private bool isExamining = false;
    private FPSPlayer playerController;

    private void Awake()
    {
        playerController = GetComponent<FPSPlayer>();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(myCamera.position, myCamera.forward);
    }

    private void Update()
    {
        CheckAction();
    }

    private void CheckAction()
    {
        if (isExamining)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !NoteController.instance.showingNote)
            {
                StopExamine();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartExamine();
            }
        }
    }

    private void StartExamine()
    {
        CheckObjectSeen();

        if (objectSeen != null)
        {
            isExamining = true;
            objectSeen.ExamineObject();
            playerController.SetExamining(true);
        }
    }

    public void StopExamine()
    {
        isExamining = false;
        ObjectExaminer.instance.EndExamine();
        playerController.SetExamining(false);
    }

    private Examinable CheckObjectSeen()
    {
        if (Physics.Raycast(myCamera.position, myCamera.forward, out hit, seeDistance, examinableLayer))
        {
            objectSeen = hit.collider.GetComponent<Examinable>();
        }
        else
        {
            objectSeen = null;
        }

        return objectSeen;
    }
}
