using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Header("Cameras Positions")]
    public Transform cpOutside;
    public Transform cpInside;

    [Space(10)]
    public KeyCode change = KeyCode.R;
    public static bool canMovePlayer = false;
    public static bool cameraChange = false;

    void Start()
    {
        transform.position = cpOutside.position;

    }
    
    void Update()
    {
        if(Input.GetKeyDown(change))
        {
            canMovePlayer = !canMovePlayer;
            cameraChange = true;

        }
        
        if(!canMovePlayer)
            transform.position = cpOutside.position;

        else
            transform.position = cpInside.position;
        
    }
    
}
