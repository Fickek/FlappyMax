using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject textLogo;
    public GameObject playButton;
    public GameObject player;
    public Text highScoreText;
    private int highScoreNum = 0;
    public Sprite[] newCharacter;
    private int spriteVersion;
   

    //public GameObject newPlayer;
    //public GameObject[] prefabs;
    //private int newPrefab;



    void Awake()
    {
        player.transform.position = new Vector2(0, 0);
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        spriteRenderer.sprite = newCharacter[0];
        PlayerPrefs.SetInt("spriteVersion", spriteVersion);


        highScoreNum = PlayerPrefs.GetInt("score");

        highScoreText.text += highScoreNum.ToString();

    }

    // Запускает сцену с игрой
    public void Play()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void leftChange()
    {
        if (spriteVersion == 0)
        {
            spriteVersion = newCharacter.Length - 1;
        }
        else
        {
            spriteVersion--;
        }

        spriteRenderer.sprite = newCharacter[spriteVersion];
        // Передаёт интовое число для переключения скина на другой сцене
        PlayerPrefs.SetInt("spriteVersion", spriteVersion);


    }

    public void rightChange()
    {
        if (spriteVersion == newCharacter.Length - 1)
        {
            spriteVersion = 0;
        }
        else
        {
            spriteVersion++;
        }

        spriteRenderer.sprite = newCharacter[spriteVersion];

        PlayerPrefs.SetInt("spriteVersion", spriteVersion);

    }

}
