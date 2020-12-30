using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public bool AnyObjectiveWin = false;
    public List<AObjective> Objectives;
    public List<ACondition> LossCondition;

    public float DelayTime;

    MinigameState state;
    float endTimer;

    void Update()
    {  
        if (state != MinigameState.RUNNING)
        {
            endTimer -= Time.deltaTime;
            if (endTimer <= 0)
            {
                if (state == MinigameState.VICTORY) EndMinigame(true);
                else EndMinigame(false);
            }
            return;
        }

        if (checkObjectives()) state = MinigameState.VICTORY;
        else if (checkConditions()) state = MinigameState.DEFEAT;
    }

    private void Start()
    {
        StartMinigame();
    }

    private bool checkObjectives()
    {
        bool objectivesCompleted = true;

        if (AnyObjectiveWin)
        {
            objectivesCompleted = false;
            foreach (AObjective o in Objectives)
            {
                if (o.Completed) objectivesCompleted = true;
                o.UpdateState();
            }
        }
        else
        {
            foreach (AObjective o in Objectives)
            {
                if (!o.Completed) objectivesCompleted = false;
                o.UpdateState();
            }
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
        state = MinigameState.RUNNING;
        endTimer = DelayTime;

        gameObject.SetActive(true);
        foreach (AObjective o in Objectives)
        {
            o.ResetObjective();
        }

        foreach (ACondition c in LossCondition)
        {
            c.ResetCondition();
        }
    }

    public void EndMinigame(bool win)
    {
        if (gameObject.name != "SCORE")
        {
            if (win) ScoreSystem.TotalScore++;
            ScoreSystem.LastGameResult = win;
        }
        MinigameHandler.Instance.NextMinigame();
        gameObject.SetActive(false);
    }
}

public enum MinigameState
{
    RUNNING,
    VICTORY,
    DEFEAT
}