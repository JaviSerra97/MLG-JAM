using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float v, h;
    public float moveSpeed;
    public float seeDistance;

    private RaycastHit hit;
    private Examinable objectSeen;
    private bool examining = false;

    private void Update()
    {
        if (!examining)
        {
            v = Input.GetAxisRaw("Vertical");
            h = Input.GetAxisRaw("Horizontal");

            transform.Translate((transform.forward * v + transform.right * h) * moveSpeed * Time.deltaTime);

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, seeDistance))
            {
                if (hit.collider.CompareTag("Player"))  // Crear una tag específica
                {
                    objectSeen = hit.collider.GetComponent<Examinable>();
                }
                else
                {
                    objectSeen = null;
                }
            }

            if (objectSeen && Input.GetKeyDown(KeyCode.Space))
            {
                objectSeen.ExamineObject();
                examining = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                examining = false;
                ObjectExaminer.instance.EndExamine();
            }
        }
    }
}
