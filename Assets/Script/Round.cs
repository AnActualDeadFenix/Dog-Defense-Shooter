using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour
{
    [Header("Game Rounds")]
    public Text roundText;
    public static int roundNum;

    public static bool show = false;
    public static bool inTutorial = false;
    
    Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        roundNum = 0;

        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Tutorial_Level")
            inTutorial = true;
        else
            inTutorial = false;

    }
    
    void Update()
    {
        if(show && !inTutorial)
        {
            show = false;

            ShowNewRound();

        }
        else if(show && inTutorial)
        {
            show = false;

            ShowProtect();

        }

    }

    public void ShowNewRound()
    {
        ++roundNum;
        roundText.text = "Round " + roundNum.ToString();

        animator.SetTrigger("Show");


    }
    public void ShowProtect()
    {
        ++roundNum;
        roundText.text = "Protect the generator";

        animator.SetTrigger("Show");


    }

}
