using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 originalPosition;
    private Vector3 offset;
    private Vector3 zlift;

    private void Start()
    {
        originalPosition = transform.position;
        screenPoint = Camera.main.transform.position;
        zlift = new Vector3(0, 0, -5);
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset + zlift;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, originalPosition.z);
    }
}
