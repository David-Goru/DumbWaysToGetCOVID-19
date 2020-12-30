using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : AObjective
{
    [SerializeField] private string activatorTag = "";
    private bool hovered = false;

    [SerializeField] private Transform player;
    private Vector3 initPos;
    //[SerializeField] Transform initPosCovid;

    [SerializeField] Animator anim;

    private void Awake()
    {
        initPos = player.position;
    }

    public override void ResetObjective()
    {
        if (anim != null) resetAnim();
        resetPlayer();
        Completed = false;
        hovered = false;
    }

    public override void UpdateState()
    {
        if (hovered)
        {
            if (anim != null) anim.SetBool("TriggerAnim", true);
            Completed = true;
        }
        else Completed = false;
    }

    private void resetPlayer()
    {
        player.position = initPos;
    }

    private void resetAnim()
    {
        //anim.transform.position = initPosCovid.position; //NO FUNCIONA
        anim.SetBool("TriggerAnim", false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == activatorTag) hovered = true;
    }
}
