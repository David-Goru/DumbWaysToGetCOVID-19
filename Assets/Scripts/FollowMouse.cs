using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera; 
    private Vector3 worldPosition;
    [SerializeField] private string objectType = "";

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(worldPosition.x, worldPosition.y);

        if (Input.GetMouseButtonDown(0))
        {
            switch (objectType)
            {
                case "Spray":
                    transform.GetComponent<Animator>().SetTrigger("SprayOn");
                    break;
                case "Cloth":
                    transform.GetComponent<CircleCollider2D>().enabled = true;
                    break;
                default:
                    Debug.Log("FollowMouse objectType not detected correctly");
                    break;

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            switch (objectType)
            {
                case "Spray":
                    transform.GetComponent<Animator>().SetTrigger("SprayOff");
                    break;
                case "Cloth":
                    transform.GetComponent<CircleCollider2D>().enabled = false;
                    break;
                default:
                    Debug.Log("FollowMouse objectType not detected correctly");
                    break;

            }
        }
    }
}