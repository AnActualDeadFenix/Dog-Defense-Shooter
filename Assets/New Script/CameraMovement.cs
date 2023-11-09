using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Move Camera")]
    public float sensX;
    public float sensY;
    
    public Transform oriOutside;
    public Transform oriInside;

    float xRotation;
    float yRotation;

    // Old Rotation
    float outX;
    float outY;
    float inX;
    float inY;

    // Test //
    KeyCode changeSens = KeyCode.P; // Editor Speed <-- P --> Build Speed
    float editorSens = 400f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        CameraStuff();

    }

    private void CameraStuff()
    {
        float mouseX;
        float mouseY;

        if(Input.GetKeyDown(changeSens))
        {
            // Editor mouse input
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * editorSens;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * editorSens;

        }
        else
        {
            // Normal mouse input
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        }
        
        yRotation += mouseX;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

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

        }

    }

}
