using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public Splatter splatter;
    public GameObject triggerAnimation;
    private GameObject prefabCopy;
    private bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        //Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        ////Fetch the Renderer from the GameObject
        //Renderer rend = GetComponent<Renderer>();

        ////Set the main Color of the Material to green
        //rend.material.shader = Shader.Find("_Color");
        //rend.material.SetColor("_Color", randomColor);

        ////Find the Specular shader and change its Color to red
        //rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_SpecColor", Color.red);

        float targetx = 0f;
        if (transform.position.x < 0)
            targetx = -2.0f;
        else if (transform.position.x > 0)
            targetx = 2.0f;
        
        iTween.MoveTo(gameObject, iTween.Hash("x", targetx, "y", -5, "easeType", "easeInCubic", "loopType", "none", "time", 2, "oncomplete", "DestroyMe"));
        iTween.ScaleBy(gameObject, iTween.Hash("y", 4, "easeType", "easeInCubic", "loopType", "none", "x", 4, "time", 2, "oncomplete", "DestroyMe"));

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colliding) return;
        Debug.Log("Note OnTrigger2D Enter");
		Destroy(gameObject);

                
		GameObject fragments = GameObject.Find("MeteorFragments");
        Explodable[] explodables = fragments.GetComponentsInChildren<Explodable>();
        triggerAnimation = Array.Find(explodables, i => i.exploding == false).gameObject;

        //triggerAnimation = explodables[0].gameObject;

        triggerAnimation.transform.position = collision.transform.position;

        Explodable _explodable = triggerAnimation.GetComponent<Explodable>();
        _explodable.explode(collision.transform.position);
        //ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        //ef.doExplosion(transform.position);

        //Instantiate(triggerAnimation, collision.transform.position, Quaternion.identity);
        //prefabCopy = Instantiate(triggerAnimation, collision.transform.position, Quaternion.identity);
        //Destroy(prefabCopy, 0.35f);
        colliding = true;
    }
}
