using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private Heal healPrefab;
    [SerializeField] private float spawnInterval;
    private float _spawnTimer;
    
    void Start()
    {
        _spawnTimer = 0f;
    }

    void Update()
    {
        _spawnTimer += Time.deltaTime;
        
        if (_spawnTimer > spawnInterval)
        {
            SpawnCar(healPrefab, GetRandomPosition());
            SoundManager.Instance.GetRandomPoliceSpawnSound();
            _spawnTimer = 0f;
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
    
    void SpawnCar(Heal type, Vector2 randomPosition)
    {
        Instantiate(type, randomPosition, quaternion.identity);
    }
}