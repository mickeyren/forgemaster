using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator animator;
    public GameObject triggerAnimation;
    private GameObject prefabCopy;
    private bool colliding = false;
    public bool firing = false;

    public GameObject leftTarget;
    public GameObject middleTarget;
    public GameObject rightTarget;

    public GameObject leftImpactPrefab;
    public GameObject rightImpactPrefab;
    public GameObject middleImpactPrefab;

    // Start is called before the first frame update
    public void ToggleCanFire()
    {
        Debug.Log("can fire");
        firing = false;
        animator.SetBool("Firing", firing);


        GameObject.Find("right target")
            .GetComponent<BoxCollider2D>().isTrigger = false;

        GameObject.Find("middle target")
            .GetComponent<BoxCollider2D>().isTrigger = false;


        //if (animator.GetBool("LeftArrowPressed"))
        {
            GameObject.Find("left target")
                .GetComponent<BoxCollider2D>().isTrigger = false;


            //    animator.SetBool("LeftArrowPressed", false);
        }
    }

    public void ToggleLeftTrigger()
    {
        GameObject.Find("left target")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(leftImpactPrefab, leftTarget.transform.position, Quaternion.identity);
    }

    public void ToggleRightTrigger()
    {
        GameObject.Find("right target")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(rightImpactPrefab, rightTarget.transform.position, Quaternion.identity);
    }

    public void ToggleMiddleTrigger()
    {
        GameObject.Find("middle target")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(middleImpactPrefab, middleTarget.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (animator && !firing)
            {
                firing = true;
                animator.SetBool("LeftArrowPressed", true);
                animator.SetBool("Firing", firing);
            }
                
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (animator)
                animator.SetBool("LeftArrowPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            if (animator && !firing)
            {
                firing = true;
                animator.SetBool("RightArrowPressed", true);
                animator.SetBool("Firing", firing);

            }   
			
		} else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (animator)
                animator.SetBool("RightArrowPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (animator && !firing)
            {
                firing = true;
                animator.SetBool("UpArrowPressed", true);
                animator.SetBool("Firing", firing);
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (animator)
                animator.SetBool("UpArrowPressed", false);
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
