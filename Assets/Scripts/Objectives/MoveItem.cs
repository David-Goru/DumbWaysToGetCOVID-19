﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : AObjective
{
    [SerializeField] private Vector2 initialPosition = new Vector2(0, 0);
    [SerializeField] private Vector2 finalPosition = new Vector2(0, 0);
    [SerializeField] private Transform item = null;

    public Vector2 InitialPosition { get => initialPosition; }
    public Vector2 FinalPosition { get => finalPosition; }

    public override void ResetObjective()
    {
        Completed = false;
        item.position = initialPosition;
    }

    public override void UpdateState()
    {
        if (finalPosition.x == Mathf.Floor(item.position.x * 10) / 10 && finalPosition.y == Mathf.Floor(item.position.y * 10) / 10) Completed = true;
        else Completed = false;
    }
}