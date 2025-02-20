using Enities;
using UnityEngine;

namespace Components
{
    public class Movement : MonoBehaviour
    {
        private Entity entity;

        private void Start()
        {
            entity = GetComponent<Entity>();

            // Kiểm tra nếu Entity không tồn tại, log lỗi
            if (entity == null)
            {
                Debug.LogError("Entity không tồn tại trên " + gameObject.name);
                return;
            }
        }

        /// <summary>
        /// Move the spaceship based on user input
        /// </summary>
        public void SpawnMove(Transform afterBurnerTransform)
        {
            // Get input from player
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            
            // Calculate movement
            var deltaSpeed = entity.Speed * Time.deltaTime;
            
            // Move the object
            var movement = new Vector3(moveX * deltaSpeed, moveY * deltaSpeed, 0);     
            transform.Translate(movement);
            //SpawnAfterBurner(afterBurnerTransform);
        }
        
        private void SpawnAfterBurner(Transform transform)
        {
            GameObject afterBurner = Instantiate(GameManager.instance.afterBurner, transform);
            afterBurner.transform.SetParent(null);
            Destroy(afterBurner, 0.2f);
        }
    }
}