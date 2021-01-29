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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isExamining)
            {
                isExamining = false;
                ObjectExaminer.instance.EndExamine();
                playerController.SetExamining(false);
            }
            else
            {
                CheckObjectSeen();

                if (objectSeen != null)
                {
                    isExamining = true;
                    objectSeen.ExamineObject();
                    playerController.SetExamining(true);
                }
            }
        }
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
