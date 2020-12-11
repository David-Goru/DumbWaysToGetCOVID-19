﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachPositionInX : ACondition
{
    [SerializeField] Vector2 initialPos;
    [SerializeField] float x;
    [SerializeField] float speed;
    [SerializeField] bool right;
    [SerializeField] MoveWithMouse moveWithMouse;

    public override void ResetCondition()
    {
        transform.position = initialPos;
        Reached = false;
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

        //If you can drag this item and you dont want to move it if is being dragged
        if (moveWithMouse != null)
        {
            if (!moveWithMouse.draggingObject)
            {
                move(time);
            }
        }
        else
            move(time);
        
    }
    
    void move(float time)
    {
        if (right)
        {
            transform.Translate(Vector3.right * speed * time);
        }
        else
        {
            transform.Translate(Vector3.left * speed * time);
        }
    }
}