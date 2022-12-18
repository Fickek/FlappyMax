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
    private int _highScoreNum = 0;
    public Sprite[] newCharacter;
    private int _spriteVersion;
   

    //public GameObject newPlayer;
    //public GameObject[] prefabs;
    //private int newPrefab;



    void Awake()
    {
        player.transform.position = new Vector2(0, 0);
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        spriteRenderer.sprite = newCharacter[0];
        PlayerPrefs.SetInt("spriteVersion", _spriteVersion);


        _highScoreNum = PlayerPrefs.GetInt("highscore");
        highScoreText.text += _highScoreNum.ToString();

        Debug.Log("High Score: " + _highScoreNum);


    }

    // Запускает сцену с игрой
    public void Play()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void leftChange()
    {
        if (_spriteVersion == 0)
        {
            _spriteVersion = newCharacter.Length - 1;
        }
        else
        {
            _spriteVersion--;
        }

        spriteRenderer.sprite = newCharacter[_spriteVersion];
        // Передаёт интовое число для переключения скина на другой сцене
        PlayerPrefs.SetInt("spriteVersion", _spriteVersion);


    }

    public void rightChange()
    {
        if (_spriteVersion == newCharacter.Length - 1)
        {
            _spriteVersion = 0;
        }
        else
        {
            _spriteVersion++;
        }

        spriteRenderer.sprite = newCharacter[_spriteVersion];

        PlayerPrefs.SetInt("spriteVersion", _spriteVersion);

    }

}
