using UnityEngine;

public class ClickItemChangingAnimations : AObjective
{

    [SerializeField] Animator anim = null;
    [SerializeField] string animationTrigger = "";

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
        if (anim != null) anim.SetTrigger(animationTrigger);
    }
}