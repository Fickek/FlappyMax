using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameplayManager : MonoBehaviour
{
    //private SpriteRenderer sprite;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject backToMenuBtn;
    public GameObject gameOver;
    private int _score = 0;
    //public Rigidbody2D playerRb;
    public SpriteRenderer playerCharacterSprite;
    public Sprite[] newCharacter;




    private void Awake()
    {
        //playerRb = GetComponent<Rigidbody2D>();
        //playerCharacterSprite = GetComponent<SpriteRenderer>();
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        playButton.SetActive(false);
        backToMenuBtn.SetActive(false);
        gameOver.SetActive(false);

        int character = PlayerPrefs.GetInt("spriteVersion");
        playerCharacterSprite.sprite = newCharacter[character];
         
    }

    public void Play()
    {

        _score = 0;
        scoreText.text = _score.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);
        backToMenuBtn.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("score", _score);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        playButton.SetActive(true); 
        backToMenuBtn.SetActive(true);
        Pause();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        playerCharacterSprite.sprite = newCharacter[0];
    }



}
