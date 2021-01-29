using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleAxisTest : MonoBehaviour
{
    public float moveSpeed;
    public float cameraRotateSpeed;
    public Transform cameraT;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h != 0 || v != 0)
        {
            Vector3 moveDir = new Vector3(h, 0, v);
            moveDir = Quaternion.AngleAxis(cameraT.eulerAngles.y, Vector3.up) * moveDir;
            transform.forward = moveDir;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Q))
            cameraT.RotateAround(Vector3.zero, Vector3.down, cameraRotateSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.E))
            cameraT.RotateAround(Vector3.zero, Vector3.up, cameraRotateSpeed * Time.deltaTime);

    }
}
