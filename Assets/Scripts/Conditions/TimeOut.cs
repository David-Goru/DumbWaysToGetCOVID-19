using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : ACondition
{
    [SerializeField] private float time = 0f;
    private float timeRemaining;

    [SerializeField] private Transform timeBar;

    public float TimeRemaining { get => timeRemaining; }

    public override void ResetCondition()
    {
        Reached = false;
        timeRemaining = time;

        if (timeBar != null)
        {
            timeBar.localScale = new Vector3(6.25f, 0.4f, 1);
            timeBar.position = new Vector3(0.2f, timeBar.position.y, timeBar.position.z);
        }
    }

    public override void UpdateState(float time)
    {
        timeRemaining -= time;
        if (timeRemaining <= 0) Reached = true;
        else if (timeBar != null)
        {
            timeBar.localScale = new Vector3(6.25f * timeRemaining / this.time, 0.16f, 1);
            timeBar.position = new Vector3(0.2f - (6.25f - timeBar.localScale.x) / 2, timeBar.position.y, timeBar.position.z);
        }
    }
}