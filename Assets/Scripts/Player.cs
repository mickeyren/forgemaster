using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Player : MonoBehaviour
{
	public Animator animator;

    public GameObject leftTarget;
    public GameObject middleTarget;
    public GameObject rightTarget;

    public GameObject leftImpactPrefab;
    public GameObject rightImpactPrefab;
    public GameObject middleImpactPrefab;

    public AudioSource laserAudioSource;

    private bool firing = false;
    private string[] targets = { "LeftTarget", "RightTarget", "MiddleTarget" };

    private void Start()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void ToggleCanFire()
    {
        firing = false;
        animator.SetBool("Firing", firing);

        foreach (string target in targets)
        {
            GameObject.Find(target)
            .GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    public void ToggleLeftTrigger()
    {
        GameObject.Find("LeftTarget")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(leftImpactPrefab, leftTarget.transform.position, Quaternion.identity);

        laserAudioSource.Play();
    }

    public void ToggleRightTrigger()
    {
        GameObject.Find("RightTarget")
            .GetComponent<BoxCollider2D>().isTrigger = true;

        Instantiate(rightImpactPrefab, rightTarget.transform.position, Quaternion.identity);

        laserAudioSource.Play();
    }

    public void ToggleMiddleTrigger()
    {
        GameObject.Find("MiddleTarget")
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

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {

                        Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
                        if (!firing)
                        {
                            foreach (string target in targets)
                            {
                                if (GameObject.Find(target)
                                    .GetComponent<BoxCollider2D>().OverlapPoint(wp))
                                {
                                    MethodInfo mi = this.GetType().GetMethod(target, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                                    Debug.Log(mi);
                                    mi.Invoke(this, null);
                                }
                            }
                        }
                        break;
                    }

                case TouchPhase.Ended:                    
                    animator.SetBool("RightArrowPressed", false);
                    animator.SetBool("LeftArrowPressed", false);
                    animator.SetBool("UpArrowPressed", false);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (animator && !firing)
                FireLeftTarget();
                
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (animator)
                animator.SetBool("LeftArrowPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
		{
            if (animator && !firing)
                FireRightTarget();
			
		} else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (animator)
                animator.SetBool("RightArrowPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (animator && !firing)
                FireMiddleTarget();
            
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (animator)
                animator.SetBool("UpArrowPressed", false);
        }
    }

    private void FireLeftTarget()
    {
        firing = true;
        animator.SetBool("LeftArrowPressed", true);
        animator.SetBool("Firing", firing);

    }

    private void FireMiddleTarget()
    {
        firing = true;
        animator.SetBool("UpArrowPressed", true);
        animator.SetBool("Firing", firing);

    }

    private void FireRightTarget()
    {
        firing = true;
        animator.SetBool("RightArrowPressed", true);
        animator.SetBool("Firing", firing);
     }
}
