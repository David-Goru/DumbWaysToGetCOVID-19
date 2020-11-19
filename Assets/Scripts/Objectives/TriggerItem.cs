using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : AObjective
{
    [SerializeField] private string activatorTag = "";
    private bool hovered = false;

    [SerializeField] private Transform player;
    private Vector3 initPos;

    private void Awake()
    {
        initPos = player.position;
    }

    public override void Reset()
    {
        resetPlayer();
        Completed = false;
        hovered = false;
    }

    public override void UpdateState()
    {
        if (hovered) Completed = true;
        else Completed = false;
    }

    private void resetPlayer()
    {
        player.position = initPos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == activatorTag) hovered = true;
    }
}
