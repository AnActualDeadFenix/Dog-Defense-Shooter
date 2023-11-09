using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{   
    [Header("Keycode")]
    public KeyCode reload = KeyCode.R;

    public static bool cameraIsInside;
    
    void Start()
    {
        cameraIsInside = false;

    }
    
    void Update()
    {
        if (Input.GetKeyDown(reload))
            cameraIsInside = true;

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraIsInside = false;

            other.transform.position = new Vector3(0, other.transform.position.y, other.transform.position.z + 5);
            
        }

    }
    
}
