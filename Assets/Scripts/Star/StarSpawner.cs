using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] GameObject Stars;
    [SerializeField] float maxSpawnRatesInSeconds = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScheduleStarsSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnStars()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject clone = (GameObject)Instantiate(Stars);
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

        Invoke("SpawnStars", spawnInSeconds);
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

    public void ScheduleStarsSpawner()
    {
        Invoke("SpawnStars", maxSpawnRatesInSeconds);

        InvokeRepeating("IncreaseSpawnSpeed", 0f, 10f);
    }
}
