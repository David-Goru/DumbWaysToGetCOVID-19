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
        if (LastGameResult)
        {
            winText.SetActive(true);
            lossText.SetActive(false);
        }
        else
        {
            winText.SetActive(false);
            lossText.SetActive(true);
        }
        scoreText.text = string.Format("SCORE: {0}", TotalScore);
        informativeText.text = informativeTexts[Random.Range(0, informativeTexts.Length)];
    }
}