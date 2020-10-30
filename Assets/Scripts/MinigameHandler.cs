using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : MonoBehaviour
{
    public Minigame TestMinigame;

    public void StartGame()
    {
        TestMinigame.StartMinigame();
    }
}