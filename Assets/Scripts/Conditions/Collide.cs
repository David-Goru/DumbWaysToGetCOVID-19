using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : ACondition
{
    [SerializeField] string colliderTag;

    public override void ResetCondition()
    {
        Reached = false;
    }

    public override void UpdateState(float time)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(colliderTag))
        {
            Reached = true;
        }
    }

}
