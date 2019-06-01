using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float transitionDuration;

    private float velocity;
    private float target;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = 0.0f;
        target = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y != target)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.y, target, ref velocity, transitionDuration);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        }
    }

    public void MoveDown(float distance)
    {
        velocity = 0.0f;
        target = transform.position.y - distance;
    }
}
