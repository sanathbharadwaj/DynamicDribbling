using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // This allows you to manage different scenes in Unity.

public class ScoreManager : MonoBehaviour
{
    public static int[] score = new int[2];  // A static array holding the scores of two players.
                                             // Static values are only one per class. They can be conviniently accessed and set from other scripts.
    public static int lastWinner = 1;  // A static integer holding the last winner, defaulting to 1.

    

    // This function will load the scene again when the continue button is pressed.
    public void onContinue()
    {
        SceneManager.LoadScene(0);
    }

    // This function will reset both player scores and then load the scene again. This function is called when restart button is pressed. 
    public void onRestart()
    {
        score[0] = 0;
        score[1] = 0;
        SceneManager.LoadScene(0);
    }
}
