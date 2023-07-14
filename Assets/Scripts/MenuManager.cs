using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _textLogo;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _player;
    [SerializeField] private Text _highScoreText;
    [SerializeField] private Sprite[] _newCharacter;
    private int _spriteVersion;
    private int _highScoreNum = 0;

    void Awake()
    {
        _player.transform.position = new Vector2(0, 0);
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        _spriteRenderer.sprite = _newCharacter[0];
        PlayerPrefs.SetInt("spriteVersion", _spriteVersion);


        _highScoreNum = PlayerPrefs.GetInt("highscore");
        _highScoreText.text += _highScoreNum.ToString();

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
            _spriteVersion = _newCharacter.Length - 1;
        }
        else
        {
            _spriteVersion--;
        }

        _spriteRenderer.sprite = _newCharacter[_spriteVersion];
        // Передаёт интовое число для переключения скина на другой сцене
        PlayerPrefs.SetInt("spriteVersion", _spriteVersion);


    }

    public void rightChange()
    {
        if (_spriteVersion == _newCharacter.Length - 1)
        {
            _spriteVersion = 0;
        }
        else
        {
            _spriteVersion++;
        }

        _spriteRenderer.sprite = _newCharacter[_spriteVersion];

        PlayerPrefs.SetInt("spriteVersion", _spriteVersion);

    }

}
