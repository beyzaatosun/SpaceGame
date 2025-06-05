using UnityEngine;

public static class Settings
{
    public const string easy = "easy";
    public const string medium = "medium";
    public const string hard = "hard";
    
    public const string easyScore = "easyScore";
    public const string mediumScore = "mediumScore";
    public const string hardScore = "hardScore";
    
    public const string easyGold = "easyGold";
    public const string mediumGold = "mediumGold";
    public const string hardGold = "hardGold";
    
    public const string musicOpen = "musicOpen";

    public static void SetEasyDifficulty(int easy)
    {
        PlayerPrefs.SetInt(Settings.easy, easy);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.easy);
    }
    public static void SetMediumDifficulty(int medium)
    {
        PlayerPrefs.SetInt(Settings.medium, medium);
    }
    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.medium);
    }
    public static void SetHardDifficulty(int hard)
    {
        PlayerPrefs.SetInt(Settings.hard, hard);
    }
    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.hard);
    }
    
    
    
    public static void SetEasyScoreDifficulty(int easyScore)
    {
        PlayerPrefs.SetInt(Settings.easyScore, easyScore);
    }

    public static int GetEasyScoreDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.easyScore);
    }
    
    public static void SetMediumScoreDifficulty(int mediumScore)
    {
        PlayerPrefs.SetInt(Settings.mediumScore, mediumScore);
    }
    public static int GetMediumScoreDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.mediumScore);
    }
    public static void SetHardScoreDifficulty(int hardScore)
    {
        PlayerPrefs.SetInt(Settings.hardScore, hardScore);
    }
    public static int GetHardScoreDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.hardScore);
    }
    
    
    
    
    public static void SetEasyGoldDifficulty(int easyGold)
    {
        PlayerPrefs.SetInt(Settings.easyGold, easyGold);
    }

    public static int GetEasyGoldeDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.easyGold);
    }
    
    public static void SetMediumGoldDifficulty(int mediumGold)
    {
        PlayerPrefs.SetInt(Settings.mediumGold, mediumGold);
    }
    public static int GetMediumGoldDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.mediumGold);
    }
    public static void SetHardGoldDifficulty(int hardGold)
    {
        PlayerPrefs.SetInt(Settings.hardGold, hardGold);
    }
    public static int GetHardGoldDifficulty()
    {
        return PlayerPrefs.GetInt(Settings.hardGold);
    }
    
    
    public static void MusicOpenSet(int musicOpen)
    {
        PlayerPrefs.SetInt(Settings.musicOpen, musicOpen);
    }
    public static int MusicOpenGet()
    {
        return PlayerPrefs.GetInt(Settings.musicOpen);
    }
    

    public static bool HasData()
    {
        if (PlayerPrefs.HasKey(Settings.easy) || PlayerPrefs.HasKey(Settings.medium) ||
            PlayerPrefs.HasKey(Settings.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static bool HasDataMusic()
    {
        if (PlayerPrefs.HasKey(Settings.musicOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
