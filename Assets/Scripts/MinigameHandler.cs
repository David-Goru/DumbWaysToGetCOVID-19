using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : MonoBehaviour
{
    public Minigame TestMinigame; //Test a specific minigame

    [SerializeField] private Minigame scoreMinigame; //This will be the score minigame (minigame to show the score of the game)
    [SerializeField] private List<Minigame> minigamesPrefabs; //List of all the minigames prefabs available
    private Queue<Minigame> minigames; //Queue of minigames
    private List<Minigame> minigamesToPick; //List of minigames that have already been played and can be picked again to enqueue (ScoreMinigames should not be here)

    private bool runningQueue; //Bool for starting the minigames queue the first time

    private void Awake()
    {
        minigames = new Queue<Minigame>();
        randomizeMinigamesList(minigamesPrefabs);
    }

    private void addToQueue(List<Minigame> minigamesList)
    {
        //showMinigamesList(minigamesList);
        for (int i = 0; i < minigamesList.Count; i++)
        {
            minigames.Enqueue(minigamesList[i]); //Enqueue minigame
            minigames.Enqueue(scoreMinigame); //Enqueue score minigame
        }
        if (!runningQueue)
        {
            StartMinigamesQueue();
            runningQueue = true;
        }
        //showMinigamesQueue();
    }

    private void randomizeMinigamesList(List<Minigame> minigamesList) //Shuffle a list of minigames
    {
        for (int i = minigamesList.Count; i > 0; i--)
        {
            swap(minigamesList, 0, Random.Range(0, i));
        }
        addToQueue(minigamesList);
    }

    private void swap(List<Minigame> minigamesList, int i, int j)
    {
        Minigame temp = minigamesList[i];
        minigamesList[i] = minigamesList[j];
        minigamesList[j] = temp;
    }

    private void reAddToQueue(List<Minigame> minigamesList) //Call this when you think enough minigames have passed to randomly insert them again
    {
        randomizeMinigamesList(minigamesList);
    }

    private void StartMinigamesQueue() //Call this to start the minigame queue for the first time
    {
        Minigame firstGame = minigames.Dequeue();
        StartGame(firstGame);
    }

    public void NextMinigame() //Call this when a minigame has been finished
    {
        Minigame nextMinigame = minigames.Dequeue();

        //This way, the last minigame won't be on minigamesToPick but it will on next queue iteration, so we make sure that there won't be two same minigames in a row
        //So we will insert in queue n-1 minigames (being n the size of minigamesPrefabs)
        if (minigames.Count <= 1) // <= 1 because there will just be a score minigame left inside the queue
        {
            reAddToQueue(minigamesToPick);
        }

        if (!nextMinigame == scoreMinigame) //Just add minigames to minigamesToPick, not scoreminigames
        {
            minigamesToPick.Add(nextMinigame);
        }

        StartGame(nextMinigame);
    }
    public void StartGame(Minigame game)
    {
        game.StartMinigame();
    }

    #region DEBUG

    private void showMinigamesQueue() //Show the minigames enqueued in console
    {
        int minigamesCount = minigames.Count;
        for (int i = 0; i < minigamesCount; i++)
        {
            Debug.Log(minigames.Dequeue());
        }
    }

    private void showMinigamesList(List<Minigame> minigamesList) //Show the minigames in the list passed as an argument in console
    {
        for (int i = 0; i < minigamesList.Count; i++)
        {
            Debug.Log(minigamesList[i]);
        }
    }

    #endregion
}