using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 _direction;
    public float gravity = -9.8f;
    public float strength = 5f;


    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Pressed");
            _direction = Vector3.up * strength;
        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                _direction = Vector3.up * strength;
            }
        }

        _direction.y += gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
        
    }

    /*private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacles"))
        {
            //GameManagergameManager.GameOver();
            FindObjectOfType<GameplayManager>().GameOver();
        } 
        else if(other.CompareTag("Score"))
        {
            //GameManagergameManager.IncreaseScore();
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
