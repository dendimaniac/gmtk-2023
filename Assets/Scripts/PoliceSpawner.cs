using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject policePrefab;
    [SerializeField] private float policeSpawnInterval;
    private float _policeSpawnTimer;
    
    void Start()
    {
        _policeSpawnTimer = 0f;
    }

    void Update()
    {
        _policeSpawnTimer += Time.deltaTime;
        
        if (_policeSpawnTimer > policeSpawnInterval)
        {
            SpawnCar(policePrefab, GetRandomPosition());
            _policeSpawnTimer = 0f;
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 zoneSize = transform.localScale;
        Vector2 randomPosition = transform.position;

        randomPosition.x += Random.Range(-zoneSize.x / 2f, zoneSize.x / 2f);
        randomPosition.y += Random.Range(-zoneSize.y / 2f, zoneSize.y / 2f);

        return randomPosition;
    }
    
    void SpawnCar(GameObject type, Vector2 randomPosition)
    {
        Instantiate(type, randomPosition, quaternion.identity);
    }
}
