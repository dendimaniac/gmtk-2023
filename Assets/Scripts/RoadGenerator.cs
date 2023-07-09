using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Road roadPrefab;
    [SerializeField] private Road initialRoad;
    [SerializeField] private Road intersectionPrefab;
    
    private float _timer;
    private Transform _latestRoad;

    private void Awake()
    {
        _latestRoad = initialRoad.transform;
        initialRoad.SetUp(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawn the start of level here instead, spawning base prefab for now
        for (var i = 0; i < 2; i++)
        {
            SpawnRoadPrefab();
        }
    }

    public void SpawnRoadPrefab()
    {
        //10% to spawn intersection instead of a normal road
        var road = Random.value < 0.1f ? Instantiate(intersectionPrefab, transform) : Instantiate(roadPrefab, transform);
        road.SetUp(this);
        road.transform.position = _latestRoad.transform.position + new Vector3(0, 10, 0);
        _latestRoad = road.transform;
    }
}
