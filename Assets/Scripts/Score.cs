using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText= default;
    [SerializeField] TMP_Text goldText= default;
    private int score;
    private int HighScore;
    private int gold;
    private int HighGold;
    private bool isPointCollected = true;
    [SerializeField] TMP_Text finishGamescoreText= default;
    [SerializeField] TMP_Text finishGamegoldText= default;
    void Start()
    {
        goldText.text = "X " + gold;
    }

    void Update()
    {
        if (isPointCollected)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Score: "+ score;
        }
        
    }

    public void EarnGold()
    {
        FindObjectOfType<SoundControl>().GoldSound();

        gold++;
        goldText.text = "X " + gold;

    }

    public void FinishGame()
    {
        if (Settings.GetEasyDifficulty() == 1)
        {
            HighScore = Settings.GetEasyScoreDifficulty();
            HighGold = Settings.GetEasyGoldeDifficulty();
            if (score > HighScore)
            {
                Settings.SetEasyScoreDifficulty(score);
            }

            if (gold > HighGold)
            {
                Settings.SetEasyGoldDifficulty(gold);
            }
        }
        
        if (Settings.GetMediumDifficulty() == 1)
        {
            HighScore = Settings.GetMediumScoreDifficulty();
            HighGold = Settings.GetMediumGoldDifficulty();
            if (score > HighScore)
            {
                Settings.SetMediumScoreDifficulty(score);
            }

            if (gold > HighGold)
            {
                Settings.SetMediumGoldDifficulty(gold);
            }
        }
        
        if (Settings.GetHardDifficulty() == 1)
        {
            HighScore = Settings.GetHardScoreDifficulty();
            HighGold = Settings.GetHardGoldDifficulty();
            if (score > HighScore)
            {
                Settings.SetHardScoreDifficulty(score);
            }

            if (gold > HighGold)
            {
                Settings.SetHardGoldDifficulty(gold);
            }
        }
        
        isPointCollected = false;   
        finishGamescoreText.text = "Score :  " + score;
        finishGamegoldText.text = " X : " + gold;
    }
}
