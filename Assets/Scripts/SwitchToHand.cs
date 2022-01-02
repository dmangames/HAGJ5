using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
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
            Destroy(this.gameObject);
        }
        
    }
}
