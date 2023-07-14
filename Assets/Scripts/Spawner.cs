using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnRate = 5f;
    [SerializeField] private float _minHeight = -1f;
    [SerializeField] private float _maxHeight = 1f;

    private void Start()
    {
        StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while (true)
        {
            Vector3 spawn = transform.position + Vector3.up * Random.Range(_minHeight, _maxHeight);
            Instantiate(_prefab, spawn, Quaternion.identity);
            Debug.Log("5sec");
            yield return new WaitForSeconds(_spawnRate);
        }        
    }

}
