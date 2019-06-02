using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{   

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButton("left")) {
            anim.SetBool("IsRunning", true);
        }
        else if (Input.GetButton("right")) {
            anim.SetBool("IsRunning", true);
        }else {
            anim.SetBool("IsRunning", false);
            //anim.SetTrigger("IsIdle");
        }
    }
}
