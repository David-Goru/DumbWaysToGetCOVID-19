using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private Camera mainCamera; 
    [HideInInspector] public bool draggingObject;

    [Header("These values just take place if you tick the booleans. Otherwise they will take the values from the bounds of the camera")]
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [Space]
    [SerializeField] bool overrideMaxX;
    [SerializeField] bool overrideMaxY;
    [SerializeField] bool overrideMinX;
    [SerializeField] bool overrideMinY;
    [Space]
    [SerializeField] bool lockAxisX;
    [SerializeField] bool lockAxisY;

    Vector2 lastMousePosition;

    void Start()
    {
        mainCamera = Camera.main;
        float horizontalBound = mainCamera.orthographicSize * Screen.width / Screen.height;
        float verticalBound = mainCamera.orthographicSize;
        if (!overrideMaxX)
            maxX = horizontalBound;
        if (!overrideMinX)
            minX = -horizontalBound;
        if(!overrideMaxY)
            maxY = verticalBound;
        if(!overrideMinY)
            minY = -verticalBound;
    }

    void OnMouseDown()
    {
        lastMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;
        draggingObject = true;
    }

    void OnMouseDrag()
    {
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 deltaMove = worldPosition - lastMousePosition;
        float x;
        float y;
        if (lockAxisX)
        {
            x = Mathf.Clamp(transform.position.x + deltaMove.x, minX, maxX);
            y = transform.position.y;
        }
        else if(lockAxisY)
        {
            x = transform.position.x;
            y = Mathf.Clamp(transform.position.y + deltaMove.y, minY, maxY);
        }
        else
        {
            x = Mathf.Clamp(transform.position.x + deltaMove.x, minX, maxX);
            y = Mathf.Clamp(transform.position.y + deltaMove.y, minY, maxY);
        }
        transform.position = new Vector2(x, y);
        lastMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    void OnMouseUp()
    {
        Cursor.visible = true;
        draggingObject = false;
        // Do fancy things
    }
    private void OnDisable()
    {
        Cursor.visible = true;
        draggingObject = false;
    }
}