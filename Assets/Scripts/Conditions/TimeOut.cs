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
            timeBar.localScale = new Vector3(15.6f, 0.4f, 1);
            timeBar.position = new Vector3(-7.5f + (15.6f / 2), timeBar.position.y, timeBar.position.z);
        }
    }

    public override void UpdateState(float time)
    {
        timeRemaining -= time;
        if (timeRemaining <= 0) Reached = true;
        else if (timeBar != null)
        {
            timeBar.localScale = new Vector3(15.6f * timeRemaining / this.time, 0.4f, 1);
            timeBar.position = new Vector3(-7.5f + timeBar.localScale.x / 2, timeBar.position.y, timeBar.position.z);
        }
    }
}