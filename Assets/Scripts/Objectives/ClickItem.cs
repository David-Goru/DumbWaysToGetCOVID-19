using UnityEngine;

public class ClickItem : AObjective
{
    public override void ResetObjective()
    {
        Completed = false;
    }

    public override void UpdateState()
    {
        
    }

    void OnMouseDown()
    {
        Completed = true;
    }
}