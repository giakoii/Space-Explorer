using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] int scoreValue = 100;
    [SerializeField] float speed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        Vector2 pos = transform.position;

        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);

        transform.position = pos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Spaceship"))
        {
            Debug.Log("Star collide Player");
            gameManager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
