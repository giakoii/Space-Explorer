using Components;
using Const;
using Enities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controller
{
    /// <summary>
    /// SpaceShipController - Controls the movement and shooting of the spaceship
    /// </summary>
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
        //public Transform afterBurnerTransform;

        /// <summary>
        /// Awake - Initializes the Movement and Shooting components
        /// </summary>
        private void Awake()
        {
            _movement = gameObject.AddComponent<Movement>();
            _shooting = gameObject.AddComponent<Shooting>();
            _spaceShip = gameObject.AddComponent<SpaceShip>();
        }

        /// <summary>
        /// Update - Moves the spaceship and shoots missiles
        /// </summary>
        private void Update()
        {
            _movement.SpawnMove(muzzleFlashTransform);
            _shooting.Shoot(_missile, missileSpawn, muzzleFlashTransform);
        }
        
        /// <summary>
        /// OnCollisionEnter2D - Destroys the spaceship and the Baby Tree when they collide
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == (Constant.Object.BabyTree.ToString()))
            {
                _spaceShip.TakeDamage(80);
                //Destroy(this.gameObject);
                Destroy(other.gameObject);
                Debug.LogWarning(_spaceShip.Health);
            }

            if(other.gameObject.tag == (Constant.Object.Asteroid.ToString()))
            {
                _spaceShip.TakeDamage(20);
                Destroy(other.gameObject);
                Debug.LogWarning(_spaceShip.Health);
            }

            if(other.gameObject.tag == (Constant.Object.Star.ToString()))
            {
                _spaceShip.AddScore(20);
                Debug.LogWarning(_spaceShip.Score);
            }
        }
    }
}