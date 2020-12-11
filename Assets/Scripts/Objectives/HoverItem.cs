using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverItem : AObjective
{
    [SerializeField] private string activatorTag = "";
    private bool hovered = false;

    public override void ResetObjective()
    {
        Completed = false;
        hovered = false;
        gameObject.SetActive(true);
    }

    public override void UpdateState()
    {
        if (hovered)
        {   
            Completed = true;
            gameObject.SetActive(false);
        }
        else Completed = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == activatorTag) hovered = true;
    }
}