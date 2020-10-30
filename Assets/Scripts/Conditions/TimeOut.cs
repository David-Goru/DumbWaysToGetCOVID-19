using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : ACondition
{
    [SerializeField]
    private float time;
    private float timeRemaining;

    public float TimeRemaining { get => timeRemaining; }

    public override void Reset()
    {
        Reached = false;
        timeRemaining = time;
    }

    public override void UpdateState(float time)
    {
        timeRemaining -= time;
        if (timeRemaining <= 0) Reached = true;
    }
}