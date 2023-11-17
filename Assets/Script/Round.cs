using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    [Header("Game Rounds")]
    public Text roundText;
    public static int roundNum;

    public static bool show = false;
    
    Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        roundNum = 0;

    }
    
    void Update()
    {
        if(show)
        {
            show = false;

            ShowNewRound();

        }

    }

    public void ShowNewRound()
    {
        ++roundNum;
        roundText.text = "Round " + roundNum.ToString();

        animator.SetTrigger("Show");


    }

}
