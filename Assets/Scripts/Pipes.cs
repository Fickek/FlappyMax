using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    
    public float speed = 1.0f;
    private float leftEdge = -12f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            //Debug.Log("Detected");
            Destroy(gameObject);
        }
    }
}
