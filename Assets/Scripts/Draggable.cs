using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    public bool alwaysReturn;
    public bool dontStick;
    private Vector3 screenPoint;
    private Vector3 originalPosition;
    private Vector3 offset;
    private Vector3 zlift;

    private void Start()
    {
        originalPosition = transform.position;
        screenPoint = Camera.main.transform.position;
        zlift = new Vector3(0, 0, -15);
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) 
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset + zlift;
            transform.position = curPosition;
        }
            
    }

    private void OnMouseUp()
    {
        if (dontStick)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, originalPosition.z);
            return;
        }
            
        if(alwaysReturn)
        {
            transform.position = originalPosition;
            return;
        }
        //try to place the card down on a surface hit by raycast
        int layerMask = (LayerMask.GetMask("surface"));
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 30,layerMask);

        if (hit.collider != null)
        {
            Debug.Log("Target Name: " + hit.collider.gameObject.name);
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            transform.position = new Vector3(transform.position.x, transform.position.y, hit.collider.gameObject.transform.position.z - 0.1f);
        }
        else
        {
            transform.position = originalPosition;
        }


    }
}
