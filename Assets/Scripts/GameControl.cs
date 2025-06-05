using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject finishGamePanel;
    public GameObject joystick;
    public GameObject jumpButton;
    public GameObject sign;
    public GameObject menuButton;
    public GameObject slider;
    
    void Start()
    {
        finishGamePanel.SetActive(false);
        UIOpen();
        
    }

    public void FinishGame()
    {
        FindObjectOfType<SoundControl>().FinishGameSound();

        finishGamePanel.SetActive(true);
        FindObjectOfType<Score>().FinishGame();
        FindObjectOfType<PlayerMove>().FinishGame();
        FindObjectOfType<CameraMove>().FinishGame();

        UIClose();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void UIOpen()
    {
        joystick.SetActive(true);
        jumpButton.SetActive(true);
        sign.SetActive(true);
        menuButton.SetActive(true);
        slider.SetActive(true);
    }

    void UIClose()
    {
        joystick.SetActive(false);
        jumpButton.SetActive(false);
        sign.SetActive(false);
        menuButton.SetActive(false);
        slider.SetActive(false);
    }
}
