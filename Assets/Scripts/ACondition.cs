using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACondition : MonoBehaviour
{
    [HideInInspector]
    public bool Reached;
    public abstract void ResetCondition();
    public abstract void UpdateState(float time);
}