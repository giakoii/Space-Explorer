using Enities;
using UnityEngine;

namespace Components
{
    public class Movement : MonoBehaviour
    {
        private Entity entity;
        private Camera mainCamera;

        private void Start()
        {
            entity = GetComponent<Entity>();
            mainCamera = Camera.main;
            
            // Kiểm tra nếu Entity không tồn tại, log lỗi
            if (entity == null)
            {
                Debug.LogError("Entity không tồn tại trên " + gameObject.name);
                return;
            }
            
            if (mainCamera == null)
            {
                Debug.LogError("Main Camera không tồn tại!");
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
            ClampPosition();
            //SpawnAfterBurner(afterBurnerTransform);
        }
        
        /// <summary>
        /// Clamp the position of the spaceship to the screen
        /// </summary>
        private void ClampPosition()
        {
            Vector3 pos = transform.position;

            // Lấy kích thước màn hình tính theo thế giới
            Vector3 screenMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
            Vector3 screenMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

            // Giới hạn vị trí của máy bay
            pos.x = Mathf.Clamp(pos.x, screenMin.x, screenMax.x);
            pos.y = Mathf.Clamp(pos.y, screenMin.y, screenMax.y);

            transform.position = pos;
        }
        
        // private void SpawnAfterBurner(Transform transform)
        // {
        //     GameObject afterBurner = Instantiate(GameManager.instance.afterBurner, transform);
        //     afterBurner.transform.SetParent(null);
        //     Destroy(afterBurner, 0.2f);
        // }
    }
}