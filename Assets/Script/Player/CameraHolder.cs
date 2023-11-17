using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Header("Cameras Positions")]
    public Transform cpTurret;
    public Transform cpTransition;

    [Space(10)]
    public KeyCode change = KeyCode.R;
    public static bool canMovePlayer = false;
    public static bool cameraChange = false;

    void Start()
    {
        transform.position = cpTurret.position;

    }
    void Update()
    {
        if(Input.GetKeyDown(change))
        {
            canMovePlayer = !canMovePlayer;
            cameraChange = true;

        }
        
        if(!canMovePlayer)
            transform.position = cpTurret.position;

        else
            transform.position = cpTransition.position;
        
    }

}
