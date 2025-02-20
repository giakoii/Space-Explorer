using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject Asteroids;
    [SerializeField] float maxSpawnRatesInSeconds = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScheduleAsteroidsSpawner();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnAsteroids()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject clone = (GameObject)Instantiate(Asteroids);
        clone.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextSpawn();
    }

    private void ScheduleNextSpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRatesInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRatesInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnAsteroids", spawnInSeconds);
    }

    private void IncreaseSpawnSpeed()
    {
        if (maxSpawnRatesInSeconds > 1f)
        {
            maxSpawnRatesInSeconds--;
        }
        if (maxSpawnRatesInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnSpeed");
        }
    }

    public void ScheduleAsteroidsSpawner()
    {
        Invoke("SpawnAsteroids", maxSpawnRatesInSeconds);

        InvokeRepeating("IncreaseSpawnSpeed", 0f, 30f);
    }
}
