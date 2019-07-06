using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator animator;
    public GameObject triggerAnimation;
    private GameObject prefabCopy;
    private bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (animator)
            {
                animator.SetBool("LeftArrowPressed", true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (animator)
                animator.SetBool("LeftArrowPressed", false);
        }
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            if (animator)
            {
                animator.SetBool("RightArrowPressed", true);
            }
			
		} else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (animator)
            {
                animator.SetBool("RightArrowPressed", false);
            }
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Player OnTrigger2D Enter");
    //    if (colliding) return;

    //    prefabCopy = Instantiate(triggerAnimation, collision.transform.position, Quaternion.identity);
    //    Destroy(prefabCopy, 0.35f);
    //    colliding = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    //if(colliding) colliding = false;
    //}
}
