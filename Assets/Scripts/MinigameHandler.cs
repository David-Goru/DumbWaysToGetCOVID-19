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
        showMinigamesQueue();
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

    private void reAddToQueue() //Call this when you think enough minigames have passed to randomly insert them again
    {
        randomizeMinigamesList(minigamesToPick);
    }

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

    public void StartGame()
    {
        TestMinigame.StartMinigame();
    }
}