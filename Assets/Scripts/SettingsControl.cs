using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsControl : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;
    void Start()
    {
        if (Settings.GetEasyDifficulty() == 1)
        {
            easyButton.interactable = false;
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }

        if (Settings.GetMediumDifficulty() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }
        if (Settings.GetHardDifficulty() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
    }
    

    public void SelectOptions(string level)
    {
        switch (level)
        {
            case "easy":
                Settings.SetEasyDifficulty(1);
                Settings.SetMediumDifficulty(0);
                Settings.SetHardDifficulty(0);
                easyButton.interactable = false;
                mediumButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "medium":
                Settings.SetEasyDifficulty(0);
                Settings.SetMediumDifficulty(1);
                Settings.SetHardDifficulty(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                Settings.SetEasyDifficulty(0);
                Settings.SetMediumDifficulty(0);
                Settings.SetHardDifficulty(1);
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
                break;
            default:
                break;
            
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
