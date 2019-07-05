using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMaker : MonoBehaviour
{
    public GameObject note;
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
        Instantiate(note, new Vector3(Random.Range(-1, 2), 4f, 0), Quaternion.identity);
        
    }
}
