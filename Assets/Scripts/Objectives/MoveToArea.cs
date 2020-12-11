using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToArea : AObjective
{
    [SerializeField] Collider2D area;
    [SerializeField] MoveWithMouse moveWithMouse;
    bool inArea;

    public override void ResetObjective()
    {
        Completed = false;
        inArea = false;
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
