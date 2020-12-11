using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AObjective : MonoBehaviour
{
    [HideInInspector]
    public bool Completed;
    public abstract void ResetObjective();
    public abstract void UpdateState();
}