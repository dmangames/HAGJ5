using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SwitchToPaper : MonoBehaviour
{
    public GameObject switchToPaperObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if switching to hand
        if (collision.gameObject.tag == "switch_to_paper")
        {
            //create the game object and destroy the paper version
            GameObject so = Instantiate(switchToPaperObject);
            if (gameObject.GetComponent<EvidenceHand>())
            {
                so.GetComponent<EvidencePaper>().evidenceResult = gameObject.GetComponent<EvidenceHand>().evidenceResult;
            }
            Destroy(this.gameObject);
        }

    }
}
