using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMaker : MonoBehaviour
{
    public GameObject meteor;
    public Camera mainCamera;
    public float meteorTiming = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateMeteor", 0.0f, meteorTiming);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMeteor()
    {
        float starty = mainCamera.transform.position.y + 5.5f;
        Instantiate(meteor, new Vector3(Random.Range(-1, 2), starty, 0), Quaternion.identity);        
    }
}
