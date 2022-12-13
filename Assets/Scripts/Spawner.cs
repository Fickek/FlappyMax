using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void Start()
    {
        //Debug.Log("onEnable");
        InvokeRepeating(nameof(spawnPipes), 0.5f, spawnRate);
    }

    /*private void OnDisable()
    {
        CancelInvoke(nameof(spawnPipes));
    }*/


    void spawnPipes()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);     
    }

}
