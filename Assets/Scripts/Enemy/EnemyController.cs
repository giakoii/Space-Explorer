using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;
    [SerializeField] float speed = 5f;

    [SerializeField] GameObject enemyBulletGO;
    [SerializeField] Transform? AlienType1BulletPosition;
    [SerializeField] Transform? AlienType3BulletPosition1;
    [SerializeField] Transform? AlienType3BulletPosition2;
    [SerializeField] Transform? AlienType3BulletPosition3;

    private int moveDirection;
    private float changeDirectionTime = 2f; // Change direction every 2 seconds
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBullets();
        moveDirection = Random.Range(0, 2); // 0 = Vertical, 1 = Horizontal
        InvokeRepeating(nameof(ChangeDirection), changeDirectionTime, changeDirectionTime);

        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    private void Spawn()
    {


        if (moveDirection == 0)
        {
            MoveVertical();
        }
        else
        {
            MoveHorizontal();
        }
    }

    void MoveVertical()
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

    void MoveHorizontal()
    {
        Vector2 pos = transform.position;

        pos = new Vector2(pos.x + speed * Time.deltaTime, pos.y);

        transform.position = pos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x < min.x || transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnBullets()
    {
        if (enemyBulletGO != null)
        {
            if (AlienType1BulletPosition != null) InstantiateBullet(AlienType1BulletPosition.position);
            if (AlienType3BulletPosition1 != null) InstantiateBullet(AlienType3BulletPosition1.position);
            if (AlienType3BulletPosition2 != null) InstantiateBullet(AlienType3BulletPosition2.position);
            if (AlienType3BulletPosition3 != null) InstantiateBullet(AlienType3BulletPosition3.position);
        }
    }

    private void InstantiateBullet(Vector2 spawnPosition)
    {
        GameObject bullet = (GameObject)Instantiate(enemyBulletGO);
        bullet.transform.position = spawnPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Spaceship") || (collision.tag == "PlayerBullet"))
        {
            Debug.Log("Enemy collide Player");
            //Destroy(gameObject);

        }
    }

    public void SetMoveDirection(int direction)
    {
        moveDirection = direction;
    }
    private void ChangeDirection()
    {
        moveDirection = Random.Range(0, 2);
    }
}
