using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{   

    private Animator anim;
    public int playerNum;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerNum = GetComponent<PlayerInput>().playerNum;
        Debug.Log(playerNum);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Mathf.Abs(Input.GetAxis("Horizontal" + playerNum)) < 0.2f) {
            anim.SetBool("IsRunning", true);
        }else{
            anim.SetBool("IsRunning", false);
        }
    }
}
