using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    public GameObject cam;

    void Start()
    {
        // locking the cursor to the middle of the screen 
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        // Getting mouse inputs 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation around the X axis (look up and down)
        xRotation -= mouseY;

        // clamp the rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rotation around the Y axis (Look left and right)
        yRotation += mouseX;

        // Apply Rotations to our transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


    }
}
