using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public Animator animator;

    [Header("Game Rounds")]
    public int round;
    public Text roundText;

    public static bool show = false;
    
    void Awake()
    {
        round = 0;

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
        ++round;
        roundText.text = "Round " + round.ToString();

        animator.SetTrigger("Show");


    }

}
