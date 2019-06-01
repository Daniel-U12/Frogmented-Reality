using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifespan = 3.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if( lifespan <= 0){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        
    }
}
