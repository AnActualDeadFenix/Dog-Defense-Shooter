using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool doorStartOpen;
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if(doorStartOpen)
        {
            animator.Play("OPEN");

        }
        else
        {
            animator.Play("DEFAULT");

        }
        
    }

}
