using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SwitchToHand : MonoBehaviour
{
    public GameObject switchToHandObject;
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
        if (collision.gameObject.tag == "switch_to_hand")
        {
            //create the game object and destroy the paper version
            GameObject so = Instantiate(switchToHandObject);
            if (gameObject.GetComponent<EvidencePaper>())
            {
                so.GetComponent<EvidenceHand>().evidenceResult = gameObject.GetComponent<EvidencePaper>().evidenceResult;
            }
            Destroy(this.gameObject);
        }
        
    }
}
