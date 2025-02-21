using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;
    [SerializeField] float speed = 7f;

    private GameManager gameManager;
    public GameObject ExplosionGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
    }
    public int GetScoreValue()
    {
        return scoreValue;
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
            Debug.Log("Asteroid collide Player");
            Destroy(gameObject);
            PlayExplosionAnimation();
            gameManager.GameOver();
        }
        else if ((collision.tag == "PlayerBullet"))
        {
            Debug.Log("Asteroid collide Player");
            Destroy(gameObject);
            PlayExplosionAnimation();
            
        }
    }
    void PlayExplosionAnimation()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
        DestroyExplosionAnimation(explosion);
    }
    void DestroyExplosionAnimation(GameObject explosion)
    {
        float explosionDuration = 1f; // Adjust based on the animation length
        Destroy(explosion, explosionDuration);
    }

}
