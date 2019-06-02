using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int hp = 2;
    
    private PlayerInput player_in; 
    // Start is called before the first frame update
    public float slippForce = 5f;
    public float safety_timer = 2.0f;
    public float safe_time = 2.0f;
    public float projectile_power = 25f;
    public GameObject projectile;
    public Vector3 inst_pos;
    public Vector3 object_half_size;
    
    void Start()
    {
        object_half_size = gameObject.GetComponent<BoxCollider2D>().bounds.size / 2;
        player_in = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(safety_timer < safe_time){
            safety_timer += Time.deltaTime;
        }
        if(hp == 0){
            Destroy(gameObject);
        }
        
    }

    public void shoot(int dir){
        Vector3 gameObj_pos = gameObject.transform.position;
        float inst_pos_x = gameObj_pos.x;

        if(dir < 0){
            inst_pos_x = inst_pos_x - (object_half_size.x + 0.5f);

        } else if (dir > 0){
            inst_pos_x = inst_pos_x + (object_half_size.x + 0.25f);
        }
        inst_pos = new Vector3(
            inst_pos_x, 
            gameObj_pos.y,
            0);
        inst_pos.x = inst_pos.x;
        GameObject bullet = Instantiate(projectile, inst_pos, new Quaternion(gameObj_pos.x, gameObj_pos.y , 0, 1)) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2 (1.5f*dir,0f)*projectile_power;
    }


    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Hazard" && safety_timer >= safe_time){
            safety_timer = 0;
            hp -= 1;
        }
    }
    void OnCollisionEnterStay(Collision2D col){
        if(col.gameObject.tag == "Slippy"){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-1)*slippForce);
        }
    }
}