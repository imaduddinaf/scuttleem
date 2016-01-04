using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterData : MonoBehaviour 
{
    public List<GameObject> piratePrefabs;
    public List<int> killCount;
    public List<float> highScores;
    public int pirateType;
    public int maxHighScore = 8;
    public float volume = 0;

    public bool developerMode = false;
    public static bool isMasterDataPresent = false;

    void Awake()
    {
        if (MasterData.isMasterDataPresent)
            GameObject.Destroy(this.gameObject);

        DontDestroyOnLoad(this);
        isMasterDataPresent = true;
    }
	// Use this for initialization
	void Start () 
    {
        pirateType = 3;
        InitKillCount();
        InitHighScore();
        InitVolume();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void InitKillCount()
    {
        Debug.Log("kk " + pirateType);
        killCount = new List<int>(pirateType);

        for (int i = 0; i < pirateType; i++)
        {
            if (!PlayerPrefs.HasKey("KillCount" + i))
            {
                PlayerPrefs.SetInt("KillCount" + i, 0);
                killCount.Add(0);
            }
            else
            {
                killCount.Add(PlayerPrefs.GetInt("KillCount" + i));
            }
            Debug.Log("kk " + i + " = " + killCount[i]);
        }
    }

    public void InitHighScore()
    {
        highScores = new List<float>(maxHighScore);
        for (int i = 0; i < maxHighScore; i++)
        {
            if (!PlayerPrefs.HasKey("HighScore" + i))
            {
                PlayerPrefs.SetFloat("HighScore" + i, 0);
                highScores.Add(0.0f);
            }
            else
            {
                highScores.Add(PlayerPrefs.GetFloat("HighScore" + i));
            }
            Debug.Log("hc " + i + " = " + highScores[i]);
        }
        highScores.Sort();
        SaveHighScores();
    }

    public void InitVolume()
    {
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1.0f);
        }

        volume = PlayerPrefs.GetFloat("SoundVolume");
        AudioListener.volume = volume;
    }

    public void SaveKillCount(int idx)
    {
        Debug.Log("save id " + idx + " value = " + killCount[idx]);
        PlayerPrefs.SetInt("KillCount" + idx, killCount[idx]);
    }

    public void AddScore(float score)
    {
        highScores.Add(score);
        highScores.Sort();
        highScores.RemoveAt(0);
        SaveHighScores();
    }

    public void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
            PlayerPrefs.SetFloat("HighScore" + i, highScores[i]);
    }

    public void SaveSoundVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
}
