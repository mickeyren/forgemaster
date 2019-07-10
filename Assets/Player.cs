using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator animator;
    public bool firing = false;

    public GameObject leftTarget;
    public GameObject middleTarget;
    public GameObject rightTarget;

    public GameObject leftImpactPrefab;
    public GameObject rightImpactPrefab;
    public GameObject middleImpactPrefab;

    public AudioSource laserAudioSource;

    private void Start()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void ToggleCanFire()
    {
        firing = false;
        animator.SetBool("Firing", firing);


        GameObject.Find("right target")
            .GetComponent<BoxCollider2D>().isTrigger = false;
        GameObject.Find("middle target")
            .GetComponent<BoxCollider2D>().isTrigger = false;
        GameObject.Find("left target")
            .GetComponent<BoxCollider2D>().isTrigger = false;

    }

    public void ToggleLeftTrigger()
    {
        GameObject.Find("left target")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(leftImpactPrefab, leftTarget.transform.position, Quaternion.identity);

        laserAudioSource.Play();
    }

    public void ToggleRightTrigger()
    {
        GameObject.Find("right target")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(rightImpactPrefab, rightTarget.transform.position, Quaternion.identity);

        laserAudioSource.Play();
    }

    public void ToggleMiddleTrigger()
    {
        GameObject.Find("middle target")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(middleImpactPrefab, middleTarget.transform.position, Quaternion.identity);

        laserAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
            if(GameObject.Find("middle target")
                .GetComponent<BoxCollider2D>().OverlapPoint(wp))
            {
                if (!firing)
                {
                    FireAtMiddleTarget();
                }
            }
        }

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

    private void FireAtMiddleTarget()
    {
        firing = true;
        animator.SetBool("RightArrowPressed", true);
        animator.SetBool("Firing", firing);
    }
}
