using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Move Camera")]
    public float sensX;
    public float sensY;
    
    // public Transform oriOutside;
    public Transform oriPlayer;

    float xRotation;
    float yRotation;

    // Old Rotation
    float outX;
    float outY;
    float inX;
    float inY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        if(CameraHolder.canMovePlayer)
            CameraStuff();

    }

    private void CameraStuff()
    {
        float mouseX;
        float mouseY;

        // Mouse input
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
        
        yRotation += mouseX;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        oriPlayer.rotation = Quaternion.Euler(0, yRotation, 0);

        /*
        // Set rotation to old rotation //
        if(CameraHolder.cameraChange)
        {
            //Debug.Log("Save the old Ori");
            if(!CameraHolder.canMovePlayer)
            {
                xRotation = outX;
                yRotation = outY;

            }
            else if(CameraHolder.canMovePlayer)
            {
                xRotation = inX;
                yRotation = inY;

            }

            CameraHolder.cameraChange = false;

        }

        // Rotate camera and determine orientation //
        if(!CameraHolder.canMovePlayer) // Outside truck
        {
            outX = xRotation;
            outY = yRotation;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            oriOutside.rotation = Quaternion.Euler(0, yRotation, 0);

        }
        else if(CameraHolder.canMovePlayer) // Inside truck
        {
            inX = xRotation;
            inY = yRotation;
            
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            oriInside.rotation = Quaternion.Euler(0, yRotation, 0);

        }*/

    }

}
