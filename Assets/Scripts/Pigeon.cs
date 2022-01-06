using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public SpriteRenderer sr;

    public Sprite pigeonNormal;
    public Sprite pigeonLetter;
    public Sprite pigeonGone;

    private GameObject something;
    private bool somethingOnPigeon;
    private bool hasLetter;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        if (somethingOnPigeon)
        {
            Destroy(something);
            sr.sprite = pigeonLetter;
        }
    }

    private void OnMouseDown()
    {
        if (hasLetter)
        {
            sr.sprite = pigeonGone;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trial")
        {
            somethingOnPigeon = true;
            something = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trial")
        {
            somethingOnPigeon = false;
            something = null;
        }
    }
}
