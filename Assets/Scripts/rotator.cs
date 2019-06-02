using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    private float z = 0;
    private float dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dir);
        Debug.Log(gameObject.transform.rotation.z);
        if (gameObject.transform.rotation.z >= 0.7){
            dir = -1f;
        } else if (gameObject.transform.rotation.z <= -0.7){
            dir = 1f;
        }
        z += Time.deltaTime * 15 * 3 * dir;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, z);   
    }
}
