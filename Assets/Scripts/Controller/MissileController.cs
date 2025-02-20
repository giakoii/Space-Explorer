using System;
using Const;
using Enities;
using UnityEngine;

namespace Controller
{
    /// <summary>
    /// MissileController - Controls the movement of the missile
    /// </summary>
    /// 

    public class MissileController : MonoBehaviour
    {
        public float missileSpeed = 20f;
        private SpaceShip _spaceShip;

        private GameManager gameManager;

        private void Start()
        {
            _spaceShip = gameObject.AddComponent<SpaceShip>();
            gameManager = GameManager.instance;
        }

        /// <summary>
        /// Update - Moves the missile up the screen
        /// </summary>
        private void Update()
        {
            transform.Translate(Vector3.up * (missileSpeed * Time.deltaTime));
        }

        /*
        /// <summary>
        /// OnCollisionEnter2D - Destroys the missile and the Baby Tree when they collide
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == (Constant.Object.BabyTree.ToString()))
            {
                GameObject gm = Instantiate(GameManager.instance.explosionEffect, transform.position, transform.rotation);
                Destroy(gm, 2f);
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                _spaceShip.AddScore(70);
                Debug.LogWarning(_spaceShip.Score);
            }
        }
        */

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if((collision.tag == "Enemy"))
            {
                EnemyController enemyController = FindAnyObjectByType<EnemyController>();
                gameManager.AddScore(enemyController.GetScoreValue());
                Destroy(gameObject);
            }
            else if ((collision.tag == "Asteroid"))
            {
                AsteroidController asteroidController = FindAnyObjectByType<AsteroidController>();
                gameManager.AddScore(asteroidController.GetScoreValue());
                Destroy(gameObject);
            }
        }
        

    }
}