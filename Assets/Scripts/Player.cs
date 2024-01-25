using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int _spriteIndex;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _strength = 5f;


    //private GameplayManager gameplayManger;


    private void Awake()
    {
        //gameplayManger = GetComponent<GameplayManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            _direction = Vector3.up * _strength;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                _direction = Vector3.up * _strength;
            }
        }

        _direction.y += _gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacles"))
        {
            FindObjectOfType<GameplayManager>().GameOver();
        } 
        else if(other.CompareTag("Score"))
        {
            FindObjectOfType<GameplayManager>().IncreaseScore();
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        _direction = Vector3.zero;
    }

}