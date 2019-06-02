using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphController : MonoBehaviour
{

    public MorphController[] stages;
    public float morphDuration;
    public float morphDistance;
    public int numMorphs;

    private CameraController maincamera;

    // Start is called before the first frame update
    void Start()
    {
        maincamera = Camera.main.gameObject.GetComponent<CameraController>();
        Debug.Log(morphDuration);
        Invoke("Morph", morphDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Morph()
    {
        Debug.Log("Morphing");
        CreateStage();
        maincamera.MoveDown(morphDistance);
        Destroy(gameObject);
    }

    void CreateStage()
    {
        Vector3 position = gameObject.transform.position -  new Vector3(0, morphDistance, 0);
        MorphController newStage = Instantiate(GetStage(), position, Quaternion.identity);
        
        newStage.morphDuration = morphDuration; 
        stages.CopyTo(newStage.stages , 0);
        newStage.numMorphs = numMorphs + 1;
        newStage.morphDistance = morphDistance;
    }

    MorphController GetStage()
    {
        return stages[(numMorphs + 1) % stages.Length];
    }
}
