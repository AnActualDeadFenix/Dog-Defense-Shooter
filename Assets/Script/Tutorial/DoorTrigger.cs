using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public List<GameObject> doors;

    public bool playerEnter;
    
    void Start()
    {
        playerEnter = false;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !playerEnter)
        {
            playerEnter = true;
            
            for(int d = 0; d < doors.Count; ++d)
            {
                doors[d].GetComponent<Animator>().Play("Closing");
                
            }
        
        }
        
    }

}
