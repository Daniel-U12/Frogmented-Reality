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
    
    public float maxspeed = 1f;
    public float jetpack_charge = 1.5f;
    public float full_charge = 1.5f;
    private float shoot_timer = 1.5f;
    private bool reloaded = true;
    // Use this for initialization
    void Start()
    {
        dir = -1;
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 up = new Vector2(0,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > maxspeed) {
            Vector2 unitVector = rb.velocity / rb.velocity.magnitude;
            rb.velocity = unitVector * maxspeed;
        }
        if (shoot_timer < 1.5f){
            shoot_timer += Time.deltaTime;
        }
        if (!Input.GetButton("up") && jetpack_charge < full_charge){
            jetpack_charge += (Time.deltaTime/1.75f);
        }
        if (Input.GetButton("up") && jetpack_charge > 0f) {
            
            rb.AddForce(up*15);
            jetpack_charge -= Time.deltaTime;
        }
        if (Input.GetButton("down")) {
            //attack
        }
        if (Input.GetButton("left")) {
            dir = -1;
            rb.AddForce(left*15);
        }
        else if (Input.GetButton("right")) {
            dir = 1;
            rb.AddForce(right*15);
        }
        if (Input.GetButtonDown("fire") && shoot_timer >= 1.5f){
            Debug.Log("fired");
            shoot_timer = 0;
            controller.shoot(dir);
        }
    }

}
