using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject keyBody;
    public Transform player;
    
    public KeyCode interact = KeyCode.E;

    void Awake()
    {
        player = GameObject.Find("InsidePlayer").transform;

        keyBody.SetActive(false);

    }

    void Update()
    {
        keyBody.transform.LookAt(player);

    }
    
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            keyBody.SetActive(true);
            
            if(Input.GetKey(interact))
            {
                if(Torreta.totalAmmo < (Torreta.totalAmmo - 10))
                    Torreta.totalAmmo += 10;
                else
                    Torreta.totalAmmo = 20;

                this.gameObject.SetActive(false);

            }
            
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            keyBody.SetActive(false);
            
        }

    }

}
