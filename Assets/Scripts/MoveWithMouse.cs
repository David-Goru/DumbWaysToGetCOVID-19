using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private Camera mainCamera; 
    private GameObject draggingObject;
    private float maxX;
    private float minX;
    private float maxY;
    private float minY;

    void Start()
    {
        mainCamera = Camera.main;
        maxX = mainCamera.orthographicSize * Screen.width / Screen.height;
        minX = -maxX;
        maxY = mainCamera.orthographicSize;
        minY = -maxY;
    }

    void OnMouseDown()
    {
        // Do fancy things
    }

    void OnMouseDrag()
    {
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.x = Mathf.Clamp(worldPosition.x, minX, maxX);
        worldPosition.y = Mathf.Clamp(worldPosition.y, minY, maxY);
        transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void OnMouseUp()
    {
        // Do fancy things
    }
}