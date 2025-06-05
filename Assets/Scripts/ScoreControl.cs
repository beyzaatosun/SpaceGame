using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreControl : MonoBehaviour
{

    public TMP_Text easyPuan, easyGold, mediumPuan, mediumGold, hardPuan, hardGold;
    void Start()
    {
        easyPuan.text = "Score: " + Settings.GetEasyScoreDifficulty();
        easyGold.text = "X: " + Settings.GetEasyGoldeDifficulty();
        
        mediumPuan.text = "Score: " + Settings.GetMediumScoreDifficulty();
        mediumGold.text = "X: " + Settings.GetMediumGoldDifficulty();
        
        hardPuan.text = "Score: " + Settings.GetHardScoreDifficulty();
        hardGold.text = "X: " + Settings.GetHardGoldDifficulty();
    }

   

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
