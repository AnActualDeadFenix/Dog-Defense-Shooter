using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Camera")]
    public float mouseSens;
    public Camera inside;
    public Transform playerBody;

    float xRotation;
    
    void Start()
    {
        SetCamera(false);

    }

    void Update()
    {
        if (MoveCamera.cameraIsInside)
        {
            GatherInput();
            SetCamera(true);

        }

    }

    public void GatherInput()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotation camera and player && move Audio Listener
        inside.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }

    public void SetCamera(bool set)
    {
        inside.enabled = set;

    }

}
