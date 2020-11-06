using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public List<AObjective> Objectives;
    public List<ACondition> LossCondition;

    void Update()
    {        
        if (checkObjectives()) EndMinigame(true);
        else if (checkConditions()) EndMinigame(false);
    }

    private bool checkObjectives()
    {
        bool objectivesCompleted = true;
        foreach (AObjective o in Objectives)
        {
            if (!o.Completed) objectivesCompleted = false;
            o.UpdateState();
        }
        return objectivesCompleted;
    }

    private bool checkConditions()
    {
        foreach (ACondition c in LossCondition)
        {
            if (c.Reached) return true;
            c.UpdateState(Time.deltaTime);
        }
        return false;
    }

    public void StartMinigame()
    {
        gameObject.SetActive(true);
        foreach (AObjective o in Objectives)
        {
            o.Reset();
        }

        foreach (ACondition c in LossCondition)
        {
            c.Reset();
        }
    }

    public void EndMinigame(bool win)
    {
        MinigameHandler.instance.NextMinigame();

        if (win)    Debug.Log("VICTORIA");
        else        Debug.Log("DERROTA");

        gameObject.SetActive(false);
    }
}