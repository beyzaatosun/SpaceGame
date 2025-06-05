using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private Sprite[] musicIcons = default;
    
    [SerializeField]
    private Button musicButton = default;
    
    void Start()
    {
        if (global::Settings.HasData() == false)
        {
            global::Settings.SetEasyDifficulty(1);
        }
        if (global::Settings.HasDataMusic() == false)
        {
            global::Settings.MusicOpenSet(1);
        }
        MusicSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("Score");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Music()
    {
        if (global::Settings.MusicOpenGet() ==1)
        {
            global::Settings.MusicOpenSet(0);
            MusicControl.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
        else
        {
            global::Settings.MusicOpenSet(1);
            MusicControl.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
        
    }

    void MusicSettings()
    {
        if (global::Settings.MusicOpenGet() == 1)
        {
            musicButton.image.sprite = musicIcons[1];
            MusicControl.instance.PlayMusic(true);

        }
        else
        {
            musicButton.image.sprite = musicIcons[0];
            MusicControl.instance.PlayMusic(false);

        }
    }
}
