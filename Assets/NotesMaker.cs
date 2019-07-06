using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMaker : MonoBehaviour
{
    public GameObject note;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateNote", 0.0f, 1.0f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNote()
    {
        float starty = mainCamera.transform.position.y + 5.0f;
        Instantiate(note, new Vector3(Random.Range(-1, 2), starty, 0), Quaternion.identity);
        
    }
}
