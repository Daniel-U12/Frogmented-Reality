using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearController : MonoBehaviour
{
    public float timer = 2.5f;
    public float stabbing = 2.0f;
    public float stab_time = 2.0f;
    public bool is_stabbing = false;
    public bool is_returning = false;
    public Vector3 stab_vel = new Vector3 (0,0,0);

    private Vector3 orig_pos;
    // Start is called before the first frame update
    void Start()
    {
        orig_pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!is_stabbing && !is_returning){
            if (timer >= 0f){
                timer -= Time.deltaTime;

            } else if ( timer < 0f ){
                timer = 2.5f;
                int stab = Random.Range(0,2);
                if (stab == 1){
                    gameObject.GetComponent<Rigidbody2D>().velocity = stab_vel;
                    is_stabbing = true;
                }
            }
        } else if(is_stabbing){
            stabbing -= Time.deltaTime;
            if (stabbing <= 0f){
                is_stabbing = false;
                is_returning = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = stab_vel * -1;
            }
        }
        if(is_returning){
            stabbing += Time.deltaTime;
            if (stabbing >= stab_time){
                stabbing = stab_time;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
                is_returning = false;
            }
        }
        
        
    }
}
