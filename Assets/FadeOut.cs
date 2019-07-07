using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeOutTime = 1.0f;

    private Vector2 origposition;
    private Quaternion origrotation;

    public void Prepare()
    {
        origposition = new Vector2(transform.position.x, transform.position.y);
        origrotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        gameObject.SetActive(true);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        fadeOutTime = Random.Range(0.5f, 3.0f);
        rb.simulated = true;
    }

    public void Finish()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Color tmpColor = mr.material.color;
        tmpColor.a = 1.0f;
        mr.material.color = tmpColor;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        transform.position = origposition;
        transform.rotation = origrotation;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(SpriteFadeOut(GetComponent<MeshRenderer>()));
        StartCoroutine(ApplyForce(GetComponent<Rigidbody2D>()));
    }

    IEnumerator SpriteFadeOut( MeshRenderer _sprite)
    {
        //Debug.Log("corouting fade out");
        Color tmpColor = _sprite.material.color;

        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            _sprite.material.color = tmpColor;

            if (tmpColor.a <= 0f)
            {
                tmpColor.a = 0.0f;
            }

            yield return null;
        }

        _sprite.material.color = tmpColor;
    }

    IEnumerator ApplyForce(Rigidbody2D _sprite)
    {
        _sprite.AddForce(new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)), ForceMode2D.Impulse);
        _sprite.AddTorque(Random.Range(-2f, 2f));
        yield return null;
    }
}
