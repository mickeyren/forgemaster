using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Move : MonoBehaviour
{
    private bool colliding = false;

    void Start()
    {
        float targetx = 0f;
        if (transform.position.x < 0)
            targetx = -2.0f;
        else if (transform.position.x > 0)
            targetx = 2.0f;

        transform.DOMove(new Vector2(targetx, -6), 2f)
            .SetEase(Ease.InCubic)
            .OnComplete(Release);
            
        transform.DOScale(2f, 2f)
            .SetEase(Ease.InCubic);
    }
        
    void Release()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (colliding) return;
		Destroy(gameObject);

		GameObject fragments = GameObject.Find("Meteor Fragments");
        Explodable[] explodables = fragments.GetComponentsInChildren<Explodable>();

        // randomly find an explodable from the pool
		Explodable explodable = explodables[Random.Range(0, explodables.Length)];
		while (explodable.exploding)
		{
			explodable = explodables[Random.Range(0, explodables.Length)];
		}		

        GameObject meteorFragment = explodable.gameObject;
        meteorFragment.transform.position = collision.transform.position;

        Explodable _explodable = meteorFragment.GetComponent<Explodable>();
        _explodable.explode();
    }
}
