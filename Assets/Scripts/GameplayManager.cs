using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class GameplayManager : MonoBehaviour
{
    //private SpriteRenderer sprite;
    [SerializeField] private Player _player;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _backToMenuBtn;
    [SerializeField] private GameObject _gameOver;

    //public Rigidbody2D playerRb;
    [SerializeField] private SpriteRenderer _playerCharacterSprite;
    [SerializeField] private Sprite[] _newCharacter;

    private int _score = 0;

    private void Awake()
    {
        //playerRb = GetComponent<Rigidbody2D>();
        //playerCharacterSprite = GetComponent<SpriteRenderer>();
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        _playButton.SetActive(false);
        _backToMenuBtn.SetActive(false);
        _gameOver.SetActive(false);

        int character = PlayerPrefs.GetInt("spriteVersion");
        _playerCharacterSprite.sprite = _newCharacter[character];
         
    }

    public void Play()
    {

        _score = 0;
        _scoreText.text = _score.ToString();
        _gameOver.SetActive(false);
        _playButton.SetActive(false);
        _backToMenuBtn.SetActive(false);
        Time.timeScale = 1f;
        _player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("score", _score);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        _gameOver.SetActive(true);
        _playButton.SetActive(true); 
        _backToMenuBtn.SetActive(true);
        Pause();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        _playerCharacterSprite.sprite = _newCharacter[0];
    }



}
