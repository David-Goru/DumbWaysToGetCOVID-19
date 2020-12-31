using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static bool LastGameResult;
    public static int TotalScore;

    [SerializeField] GameObject winText;
    [SerializeField] GameObject lossText;
    [SerializeField] Text scoreText;
    [SerializeField] Text informativeText;
    [SerializeField] Live[] lives;

    string[] informativeTexts;

    void Awake()
    {
        informativeTexts = new string[] { 
        "Wash your hands", 
        "Use masks", 
        "Is better to get vaccinated than to kill your grand mother", 
        "There are too many things to do and not enough motivation. I just want to die. I don't like college", 
        "Clean things"};
    }

    void OnEnable()
    {
        int remainingLives = MinigameHandler.Instance.lives;
        if (LastGameResult)
        {
            SetLivesSprites(remainingLives);
        }
        else
        {
            winText.SetActive(false);
            lossText.SetActive(true);
            lives[3 - remainingLives].loseLive();
            SetLivesSprites(remainingLives);
            MinigameHandler.Instance.lives--;
        }
        scoreText.text = string.Format("SCORE: {0}", TotalScore);
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
}