using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    private SpriteRenderer sr;

    public GameObject evidencePrefab;

    public Sprite pigeonNormal;
    public Sprite pigeonLetter;
    public Sprite pigeonFlap;
    public Sprite pigeonFly;
    public Sprite pigeonGone;

    private GameObject something;
    private bool somethingOnPigeon;
    private bool hasLetter;

    private GameObject order;
    private bool orderOnPigeon;
    private bool hasOrder;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
    }


    private void OnMouseUp()
    {
        //Debug.Log("Mouse up!");
        if (orderOnPigeon)
        {
            sr.sprite = pigeonLetter;
            hasOrder = true;
            Destroy(order);
            return;
        }
        if (somethingOnPigeon)
        {
            sr.sprite = pigeonLetter;
            hasLetter = true;
            GameEngine.Instance.SubmitTrial(something.GetComponent<Trial>().GetTrialName());
            Destroy(something);

        }
    }

    private void OnMouseDown()
    {
        if (hasOrder)
        {
            sr.sprite = pigeonFlap;
            Invoke("PigeonCarryOrder", 1f);
        }
        if (hasLetter)
        {
            sr.sprite = pigeonFlap;
            Invoke("PigeonFlyAway", 1f);
        }
    }

    private void PigeonCarryOrder()
    {
        sr.sprite = pigeonGone;
        GameEngine.Instance.ShowWitchCourtResult();
    }

    private void PigeonFlyAway()
    {
        sr.sprite = pigeonGone;
        Invoke("PigeonReturn", 10f);
    }

    private void PigeonReturn()
    {
        sr.sprite = pigeonNormal;
        GameObject evidence = Instantiate(evidencePrefab);
        evidence.GetComponent<EvidencePaper>().evidenceResult = GameEngine.Instance.GetTrialResult();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger entered");
        if(collision.gameObject.tag == "trial")
        {
            somethingOnPigeon = true;
            something = collision.gameObject;
        }

        if(collision.gameObject.tag == "order")
        {
            orderOnPigeon = true;
            order = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Trigger exit");
        if (collision.gameObject.tag == "trial")
        {
            somethingOnPigeon = false;
            something = null;
        }
        if (collision.gameObject.tag == "order")
        {
            orderOnPigeon = false;
            order = null;
        }
    }
}
