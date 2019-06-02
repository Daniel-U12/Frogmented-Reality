using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb.velocity = new Vector2(Random.value - 0.5f, Random.value -0.5f).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude == 0)
            rb.velocity = new Vector2(Random.value, Random.value).normalized * speed;
        else if (rb.velocity.magnitude != speed)
            rb.velocity = rb.velocity.normalized * speed;

        sr.flipX = rb.velocity.x > 0;

        if(!GetComponent<Renderer>().isVisible) {
            rb.velocity = -1*new Vector3(transform.position.x - Camera.main.transform.position.x,  transform.position.y - Camera.main.transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "bee_boundary")
            return;

        switch (other.gameObject.GetComponent<BeeBoundary>().side)
        {
            case "bottom":
            case "top":
                rb.velocity = new Vector2(rb.velocity.x + Random.value*speed/2, -1*rb.velocity.y).normalized * speed;
                break;
            case "left":
            case "right":
                rb.velocity = new Vector2(-1*rb.velocity.x,  rb.velocity.y + Random.value*speed/2).normalized * speed;
                break;
        }
    }
}
