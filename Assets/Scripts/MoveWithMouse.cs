using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private Camera mainCamera; 
    private GameObject draggingObject;
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