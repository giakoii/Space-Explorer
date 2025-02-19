using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyGO;
    [SerializeField] float maxSpawnRatesInSeconds = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScheduleEnemySpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject clone = (GameObject)Instantiate(EnemyGO);
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

        Invoke("SpawnEnemy", spawnInSeconds);
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

    public void ScheduleEnemySpawner()
    {
        Invoke("SpawnEnemy", maxSpawnRatesInSeconds);

        InvokeRepeating("IncreaseSpawnSpeed", 0f, 30f);
    }
}
