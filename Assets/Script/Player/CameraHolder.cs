using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [Header("Cameras Positions")]
    public Transform cpPlayer;
    // public Transform cpTransition;

    [Space(10)]
    // public KeyCode change = KeyCode.R;
    public static bool canMovePlayer = false;
    // public static bool cameraChange = false;

    void Start()
    {
        canMovePlayer = true;
        transform.position = cpPlayer.position;

        /*// Limit framerate to cinematic 24fps.
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 200;*/

    }
    void Update()
    {
        /*if(Input.GetKeyDown(change))
        {
            canMovePlayer = !canMovePlayer;
            cameraChange = true;

        }*/
        
        transform.position = cpPlayer.position;
        
    }

}
