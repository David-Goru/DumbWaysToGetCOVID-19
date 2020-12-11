using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{

    [SerializeField] BoxCollider2D myTrigger;
    [SerializeField] BoxCollider2D myTriggerDisable;
    [SerializeField] GameObject myGO;
    [SerializeField] GameObject myGODisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myTrigger != null)
        {
            myTrigger.enabled = true;
        }
        if (myTriggerDisable != null)
        {
            myTriggerDisable.enabled = false;
        }
        if (myGO != null)
        {
            myGO.SetActive(true);
        }
        if (myGODisable != null)
        {
            myGODisable.SetActive(false);
        }
    }
}
