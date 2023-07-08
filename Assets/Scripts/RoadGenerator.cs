using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;

    [SerializeField] private float spawnInterval;

    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        //spawn the start of level here instead, spawning base prefab for now
        SpawnRoadPrefab();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > spawnInterval)
        {
            //spawn new road prefab, spawning base prefab for now
            SpawnRoadPrefab();
            _timer = 0f;
        }
    }

    void SpawnRoadPrefab()
    {
        Instantiate(roadPrefab, transform);
    }
}
