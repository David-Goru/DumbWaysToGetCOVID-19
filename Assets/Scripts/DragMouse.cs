using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragMouse : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 worldPosition;

    private bool moveEnabled;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && moveEnabled)
        {
            worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(worldPosition.x, transform.position.y);
        }
    }

    private void OnMouseDown()
    {
        moveEnabled = true;
    }

    private void OnMouseUp()
    {
        moveEnabled = false;
    }
}