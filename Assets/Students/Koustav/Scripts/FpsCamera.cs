using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour
{
    public float MouseSensitivity;
    public Transform PlayerBody;
    float Xrotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        Xrotation -= MouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90, 90);

        transform.localRotation = Quaternion.Euler(Xrotation,0,0);
        PlayerBody.Rotate(Vector3.up * MouseX);

    }
}
