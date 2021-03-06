using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerController controller;
    private Vector2 left = new Vector2 (-1,0);
    private Vector2 right = new Vector2(1,0);
    private Vector2 up = new Vector2(0,1);
    private Vector2 down = new Vector2(0,-1);
    private Rigidbody2D rb;
    private int dir;
    private int layermask = 1 << 4;
    public bool grounded = true;
    
    public float maxspeed = 1f;
    public float jetpack_charge = 2.75f;
    public float full_charge = 2.75f;
    public int playerNum;

    public GameObject meter;
    private float meterLength;
    private float leftPos;

    private float shoot_timer = 1.5f;
    private bool reloaded = true;
    // Use this for initialization
    void Start()
    {
        dir = -1;
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 up = new Vector2(0,1);

        meterLength = meter.transform.localScale.x;
        leftPos = (int) meter.transform.localPosition.x - meterLength/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(dir<0 && gameObject.transform.localScale.x<0){
            gameObject.transform.localScale = new Vector3(
                gameObject.transform.localScale.x*-1,
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z);
        }else if(dir>0 && gameObject.transform.localScale.x>0){
            gameObject.transform.localScale = new Vector3(
                gameObject.transform.localScale.x*-1,
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z);
        }
        if(Mathf.Abs(rb.velocity.x) > maxspeed) {
            float unitVector = rb.velocity.x / rb.velocity.magnitude;
            rb.velocity = new Vector2(unitVector * maxspeed, rb.velocity.y);
        }
        if (shoot_timer < 1.5f){
            shoot_timer += Time.deltaTime;
        }
        if (Input.GetAxis("Vertical" + playerNum) <= 0 && jetpack_charge < full_charge){
            jetpack_charge += (Time.deltaTime/1.75f);
        }
        if (Input.GetAxis("Vertical" + playerNum) > 0 && jetpack_charge > 0f) {
            if (grounded) {
                rb.velocity = new Vector2(0,4);
            }
            
            rb.AddForce(up*10f);
            grounded = false;
            jetpack_charge -= Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal" + playerNum) < -0.2f) {
            dir = -1;
            rb.AddForce(left*15);
        }
        else if (Input.GetAxis("Horizontal" + playerNum) > 0.2f) {
            dir = 1;
            rb.AddForce(right*15);
        }
        if (Input.GetButtonDown("fire" + playerNum) && shoot_timer >= 1.5f){
            shoot_timer = 0;
            controller.shoot(dir);
        }
        float length = meterLength * jetpack_charge / full_charge;
        meter.transform.localScale = new Vector3(length, meter.transform.localScale.y, meter.transform.localScale.z);
        meter.transform.localPosition = new Vector2(leftPos + length/2, meter.transform.localPosition.y);
    }
    void FixedUpdate()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0,-1.5f,0), 1.5f, layermask);
        Debug.DrawRay(transform.position, new Vector3(0,-1.5f,0), Color.green);
        if (hit.collider != null && hit.collider.gameObject.tag == "Ground") {
            grounded = true;
        }

    }

}
