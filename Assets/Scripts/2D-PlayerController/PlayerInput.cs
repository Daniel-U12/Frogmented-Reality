using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private PlayerController controller;
    private Rigidbody2D rb;
    public float jetpack_charge = 1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("up") && jetpack_charge < 1){
            jetpack_charge += (Time.deltaTime/2);
        }
        if (Input.GetButton("up") && jetpack_charge > 0) {
            Vector2 up = new Vector2(0,1);
            rb.AddForce(up*15);
            jetpack_charge -= Time.deltaTime;
        }
        
        // else if (Input.GetButtonDown("down")) {
            
        // }
        // else if (Input.GetButtonDown("left")) {
            
        // }
        // else if (Input.GetButtonDown("right")) {
            
        // }

        // if (Input.GetButtonDown("Vertical" + playerNum.ToString()) < 0) {
        //     controller.FastFall();
        // }

        // if (Input.GetButtonDown("Jump" + playerNum.ToString())) {
        //     controller.JumpPressed();
        // }
        // else if (Input.GetButton("Jump" + playerNum.ToString())) {
        //     controller.ContinueJump();
        // }

        // if (Input.GetButtonDown("Fire" + playerNum.ToString())) {
        //     controller.Shoot();
        // }

    }

}
