using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToArea : AObjective
{
    [SerializeField] Collider2D area;
    [SerializeField] MoveWithMouse moveWithMouse;
    [SerializeField] bool customBool;
    [SerializeField] GameObject customGO;
    [SerializeField] Transform playerGO;
    [SerializeField] BoxCollider2D customTrigger;
    private Vector3 initPos;
    bool inArea;

    private void Awake()
    {
        initPos = playerGO.position;
    }

    public override void ResetObjective()
    {
        Completed = false;
        inArea = false;
        if (customBool)
        {
            customGO.SetActive(false);
            customTrigger.enabled = false;
            playerGO.position = initPos;
        }
    }

    public override void UpdateState()
    {
        if (inArea && !moveWithMouse.draggingObject)
            Completed = true;
        else
            Completed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == area)
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == area)
        {
            inArea = false;
        }
    }

}
