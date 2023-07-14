using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    
    [SerializeField] private float _speed = 1.0f;
    private float _leftEdge = -12f;

    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if (transform.position.x < _leftEdge)
        {
            //Debug.Log("Detected");
            Destroy(gameObject);
        }
    }
}
