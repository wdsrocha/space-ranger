using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private int XSizeTotalToSpawn = 10; //Distance from Left to Right screen bounds
    [SerializeField] private Transform YSpawnPoint;
    [SerializeField] private List<GameObject> asteroidPrefabs;
    [SerializeField] private int spacing = 20;
    private List<GameObject> asteroidsSpawned;
    private float timeToSpawn = 1f;
    private float time;
    private float spawnY;
    void Start()
    {
        time = timeToSpawn;
        spawnY = YSpawnPoint.position.y;
        if (asteroidPrefabs.Count == 0) print("Nao ha asteroides setados para spawnar");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GamePaused) return;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SpawnAsteroid();
            time = timeToSpawn;
        }
    }

    void SpawnAsteroid()
    {
        if (spacing <= 0 || asteroidPrefabs.Count == 0) return;
        float boundX = XSizeTotalToSpawn / 2f;
        int delta = XSizeTotalToSpawn / spacing;
        int x = Random.Range(0, spacing);

        float spawnX = Random.Range(-3, 3);
        Vector3 newAsteroidPosition = new Vector3(spawnX, spawnY, 0);
        Instantiate(GetRandomAsteroid(),newAsteroidPosition,Quaternion.identity,transform);
    }

    GameObject GetRandomAsteroid()
    {
        return asteroidPrefabs[Random.Range(0, asteroidPrefabs.Count)];
    }
}
