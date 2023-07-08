using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NeutralSpawner : MonoBehaviour
{
    [SerializeField] private GameObject neutralPrefab;
    [SerializeField] private float neutralSpawnInterval;
    [SerializeField] private Sprite[] randomSprites;
    private float _neutralSpawnTimer;
    
    void Start()
    {
        _neutralSpawnTimer = 0f;
    }

    void Update()
    {
        _neutralSpawnTimer += Time.deltaTime;
        
        if (_neutralSpawnTimer > neutralSpawnInterval)
        {
            SpawnCar(neutralPrefab, GetRandomPosition());
            _neutralSpawnTimer = 0f;
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
        GameObject newCar = Instantiate(type, randomPosition, quaternion.identity);
        newCar.GetComponent<SpriteRenderer>().sprite = randomSprites[Random.Range(0, randomSprites.Length)];
    }
}
