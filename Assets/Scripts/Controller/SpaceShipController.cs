using Components;
using Const;
using Enities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

namespace Controller
{
    
    public class SpaceShipController : MonoBehaviour
    {
        private Movement _movement;
        private Shooting _shooting;
        private SpaceShip _spaceShip;
        
        [FormerlySerializedAs("missile")] [Header("Missile")]
        public GameObject _missile;
        
        [FormerlySerializedAs("fireRate")] 
        public float _fireRate = 20f;

        public Transform missileSpawn;
        public Transform muzzleFlashTransform;

        public GameManager gameManager;
        public GameObject ExplosionGO;
        
        private void Awake()
        {
            _movement = gameObject.AddComponent<Movement>();
            _shooting = gameObject.AddComponent<Shooting>();
            _spaceShip = gameObject.AddComponent<SpaceShip>();
            gameManager = GameManager.instance;
        }

      
        private void Update()
        {
            _movement.SpawnMove(muzzleFlashTransform);
            _shooting.Shoot(_missile, missileSpawn, muzzleFlashTransform);
        }
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == (Constant.Object.BabyTree.ToString()))
            {
                _spaceShip.TakeDamage(80);
                //Destroy(this.gameObject);
                Destroy(other.gameObject);

                PlayExplosionAnimation();
                Debug.LogWarning(_spaceShip.Health);
            }

            if(other.gameObject.tag == (Constant.Object.Enemy.ToString()))
            {
                _spaceShip.TakeDamage(20);
                Destroy(other.gameObject);

                
                PlayExplosionAnimation();
                gameManager.GameOver();
                Debug.LogWarning(_spaceShip.Health);
            }

            if (other.gameObject.tag == (Constant.Object.Asteroid.ToString()))
            {
                _spaceShip.TakeDamage(20);
                Destroy(other.gameObject);

                
                PlayExplosionAnimation();
                gameManager.GameOver();
                Debug.LogWarning(_spaceShip.Health);
            }

            if (other.gameObject.tag == (Constant.Object.Star.ToString()))
            {
                _spaceShip.AddScore(10);
                Debug.LogWarning(_spaceShip.Score);
            }

            if (other.gameObject.tag == (Constant.Object.EnemyBullet.ToString()))
            {
                _spaceShip.TakeDamage(20);
                Destroy(other.gameObject);
                
                PlayExplosionAnimation();
                gameManager.GameOver();
                Debug.LogWarning(_spaceShip.Health);
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
}