using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachPositionInX : ACondition
{
    [SerializeField] float x;
    [SerializeField] bool right;

    public override void Reset()
    {

    }

    public override void UpdateState(float time)
    {
        if (right)
        {
            if(transform.position.x >= x)
                Reached = true;
        }
        else
        {
            if (transform.position.x <= x)
                Reached = true;
        }
    }
}