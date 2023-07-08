using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] neutralSpawnPoints;
    [SerializeField] private GameObject[] policeSpawnPoints;
    
    [SerializeField] private GameObject neutralPrefab;
    [SerializeField] private GameObject policePrefab;

    [SerializeField] private float neutralSpawnInterval;
    private float _neutralSpawnTimer;
    [SerializeField] private float policeSpawnInterval;
    private float _policeSpawnTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        _neutralSpawnTimer = 0f;
        // _policeSpawnTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _neutralSpawnTimer += Time.deltaTime;
        // _policeSpawnTimer += Time.deltaTime;
        
        if (_neutralSpawnTimer > neutralSpawnInterval)
        {
            //spawn a neutral car at a random point
            SpawnCar(neutralPrefab, GetRandomPoint(neutralSpawnPoints).transform);
            //reset timer
            _neutralSpawnTimer = 0f;
        }

        // if (_policeSpawnTimer > policeSpawnInterval)
        // {
        //     //spawn a police car
        //     SpawnCar(policePrefab, GetRandomPoint(policeSpawnPoints).transform);
        //     //reset timer
        //     _policeSpawnTimer = 0f;
        // }
    }

    public GameObject GetRandomPoint(GameObject[] randomPoints)
    {
        GameObject point = randomPoints[Random.Range(0, randomPoints.Length)];
        return point;
    }
    
    void SpawnCar(GameObject type, Transform transform)
    {
        Instantiate(type, transform);
    }
}
