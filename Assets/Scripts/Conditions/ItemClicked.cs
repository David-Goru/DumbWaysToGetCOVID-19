using UnityEngine;

public class ItemClicked : ACondition
{
    public override void ResetCondition()
    {
        Reached = false;
    }

    public override void UpdateState(float time)
    {
        
    }

    void OnMouseDown()
    {
        Reached = true;
    }
}