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
        
            if (Input.GetKeyDown(KeyCode.C))
            {
                SpawnSpecialStars("circle", 10, 2f); // 10 stars in a circle with size 2
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                SpawnSpecialStars("square", 9, 3f); // 9 stars in a square with size 3
            }

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

        InvokeRepeating("SpawnSpecialStarsAuto", 10f, 10f); // Spawn special stars every 10 seconds
    }

    public void SpawnSpecialStars(string shape, int count, float size)
    {
        Vector2 center = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1f)); // Top center

        if (shape == "circle")
        {
            for (int i = 0; i < count; i++)
            {
                float angle = i * Mathf.PI * 2f / count;
                Vector2 position = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * size;

                GameObject star = Instantiate(Stars);
                star.transform.position = position;
            }
        }
        else if (shape == "square")
        {
            int side = Mathf.CeilToInt(Mathf.Sqrt(count)); // Find how many per side
            float spacing = size / side;

            for (int x = 0; x < side; x++)
            {
                for (int y = 0; y < side; y++)
                {
                    if (x * side + y >= count) break; // Stop when we reach the count limit
                    Vector2 position = center + new Vector2(x * spacing - size / 2, y * spacing - size / 2);

                    GameObject star = Instantiate(Stars);
                    star.transform.position = position;
                }
            }
        }
    }

    private void SpawnSpecialStarsAuto()
    {
        string shape = (Random.Range(0, 2) == 0) ? "circle" : "square"; // 50/50 chance
        SpawnSpecialStars(shape, 9, 2f);
    }



}