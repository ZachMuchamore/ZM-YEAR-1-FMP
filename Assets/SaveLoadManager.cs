using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;

    string highScoreKey = "HighScoreSavedValue";

    string zombiesKilledKey = "MostZombiesKilledValue";

    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void SaveHighScore(int WaveScore)
    {
        PlayerPrefs.SetInt(highScoreKey, WaveScore);
        
    }

    public void SaveZombiesKilled(int ZombieScore)
    {
        PlayerPrefs.SetInt(zombiesKilledKey, ZombieScore);

    }
    public int LoadHighScore()
    {
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            return PlayerPrefs.GetInt(highScoreKey);

        }
        else
        {
            return 0;
        }
         
    }
    public int LoadZombieScore()
    {
        if (PlayerPrefs.HasKey(zombiesKilledKey))
        {
            return PlayerPrefs.GetInt(zombiesKilledKey);

        }
        else
        {
            return 0;
        }

    }

}