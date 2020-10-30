using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private Camera mainCamera; 
    private GameObject draggingObject;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // Do fancy things
    }

    void OnMouseDrag()
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void OnMouseUp()
    {
        // Do fancy things
    }
}