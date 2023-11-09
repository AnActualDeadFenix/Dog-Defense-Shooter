using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        
    }
    
    public void ToInstructions()
    {
        SceneManager.LoadScene("Intructions");

    }

    public void ToMain()
    {
        SceneManager.LoadScene("Start");

    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");

    }

}
