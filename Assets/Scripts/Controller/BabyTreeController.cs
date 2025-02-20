using UnityEngine;

namespace Controller
{
    /// <summary>
    /// BabyTreeController - Controls the movement of the Baby Tree
    /// </summary>
    public class BabyTreeController : MonoBehaviour
    {
        public float speed = 3f;
        
        /// <summary>
        /// Update - Moves the Baby Tree down the screen
        /// </summary>
        private void Update()
        {
            transform.Translate(Vector3.down * (speed * Time.deltaTime));
        }
    }
}