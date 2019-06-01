using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MorphController : MonoBehaviour
{

    public MorphController stage;
    public float morphDuration;
    public float morphDistance;

    private CameraController maincamera;

    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main.gameObject.GetComponent<CameraController>();
        Invoke("Morph", morphDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Morph()
    {
        CreateStage();
        maincamera.MoveDown(morphDistance);
        Destroy(gameObject);
    }

    void CreateStage()
    {
        Vector3 position = gameObject.transform.position -  new Vector3(0, morphDistance, 0);
        MorphController newStage = Instantiate(stage, position, Quaternion.identity);
        
        newStage.stage = stage;
        newStage.morphDistance = morphDistance;
        newStage.morphDuration = morphDuration; 
    }

    void GetStage()
    {

    }
}
