using UnityEngine;

namespace Components
{
    public class Shooting : MonoBehaviour
    {
        public Transform firePoint;
        public float fireRate = 0.5f;

        /// <summary>
        /// Shoot - Shoots the missile
        /// </summary>
        /// <param name="missile"></param>
        /// <param name="missileSpawn"></param>
        public void Shoot(GameObject missile, Transform missileSpawn, Transform flashEffectTransform)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnFlashEffect(flashEffectTransform);
                SpawnMissile(missile, missileSpawn);
            }
        }
        
        /// <summary>
        /// SpawnFlashEffect - Spawns the flash effect
        /// </summary>
        private void SpawnFlashEffect(Transform transform)
        {
            GameObject flash = Instantiate(GameManager.instance.flashEffect, transform);
            flash.transform.SetParent(null);
            Destroy(flash, 0.1f);
        }

        /// <summary>
        /// SpawnMissile - Spawns the missile
        /// </summary>
        /// <param name="missile"></param>
        /// <param name="missileSpawn"></param>
        private void SpawnMissile(GameObject missile, Transform missileSpawn)
        {
            GameObject gm = Instantiate(missile, missileSpawn.position, Quaternion.identity);
            gm.transform.SetParent(null);
            Destroy(gm, fireRate);
        }
    }
}