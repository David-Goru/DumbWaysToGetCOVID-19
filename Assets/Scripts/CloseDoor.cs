using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] Collider2D doorTrigger;
    SpriteRenderer sp;

    [SerializeField] Sprite initialSprite;
    [SerializeField] Sprite closedSprite;

    private void Awake()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        doorTrigger.enabled = true;
        sp.sprite = closedSprite;
        sp.sortingOrder = 1;
    }

    private void OnEnable()
    {
        doorTrigger.enabled = false;
        sp.sprite = initialSprite;
        sp.sortingOrder = -1;
    }
}
