using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static bool LastGameResult;
    public static int TotalScore;
    public static int ScoreToAdd;

    [SerializeField] Text scoreText;
    [SerializeField] Text informativeText;
    [SerializeField] Live[] lives;

    string[] informativeTexts;

    void Awake()
    {
        informativeTexts = new string[] { 
        "Wash your hands for at least 20 seconds with soap everytime you can", 
        "Use masks if you're with people or away from home", 
//        "Is better to get vaccinated than to kill your grandmother", 
        "Try to not touch your face. Are you touching it right now? Move your hands away!", 
        "Stop shaking hands and hugging people - for now", 
        "Don't share personal items, like phones or makeup", 
        "Cover your mouth and nose when you cough and sneeze", 
        "Take physical social distancing seriously. Life is not a game", 
        "Don't gather in groups. There'll be enough time to do parties", // unless you die of COVID-19
        "Avoid eating or drinking in public places", 
        "Are you sick? Do self-quarantine. Please.", 
        "You can carry or have the COVID-19 even if you don't have symptoms at all and transmit it to other people unknowingly", 
        "Do you have symptoms? Don't go to the hospital, call them!", 
        "Disinfect your hands everytime you get into a place, like a shop or a restaurant",
        "Make sure to always have a second mask available in case the first one breaks or disappears",
        "Clean and disinfect surfaces like toys, furnitures or door handles"};
    }

    void OnEnable()
    {
        int remainingLives = MinigameHandler.Instance.lives;
        if (LastGameResult)
        {
            StartCoroutine(AddScore());
            SetLivesSprites(remainingLives);
        }
        else
        {
            lives[3 - remainingLives].loseLive();
            SetLivesSprites(remainingLives);
            MinigameHandler.Instance.lives--;
        }
        informativeText.text = informativeTexts[Random.Range(0, informativeTexts.Length)];
    }

    void SetLivesSprites(int remainingLives)
    {
        int i = 2;
        while (remainingLives > 0)
        {
            lives[i].setImage(false);
            i--;
            remainingLives--;
        }
        for (int j = 0; j < i; j++)
        {
            lives[j].setImage(true);
        }
    }

    private IEnumerator AddScore()
    {
        while (ScoreToAdd > 0)
        {
            ScoreSystem.TotalScore++;
            ScoreToAdd--;
            scoreText.text = string.Format("SCORE: {0}", TotalScore);

            yield return new WaitForSeconds(0.1f);
        }
    }
}