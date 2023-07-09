using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Road roadPrefab;
    [SerializeField] private Road initialRoad;
    [SerializeField] private Road intersectionPrefab;
    
    private float _timer;
    private Road _latestRoad;

    private void Awake()
    {
        _latestRoad = initialRoad;
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
        var road = Random.value < .5f ? Instantiate(intersectionPrefab, transform) : Instantiate(roadPrefab, transform);
        road.SetUp(this);
        road.transform.position = _latestRoad.transform.position + new Vector3(road.transform.position.x, _latestRoad.SpriteVerticalSize / 2 + road.SpriteVerticalSize / 2, 0);
        _latestRoad = road;
    }
}
