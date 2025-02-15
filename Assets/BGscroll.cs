using UnityEngine;

public class BGscroll : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y < -20)
        {
            transform.position = StartPosition;
        }
    }
}
