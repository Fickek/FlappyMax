using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    void Awake()
    {

        int highScore = PlayerPrefs.GetInt("highscore");

        int currentScore = PlayerPrefs.GetInt("score");

        if(highScore < currentScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("highscore", highScore);
        }

        //Debug.Log("Current score: " + currentScore);

        DontDestroyOnLoad(gameObject);
    }

}
