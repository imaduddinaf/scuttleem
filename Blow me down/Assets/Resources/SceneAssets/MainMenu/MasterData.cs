using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterData : MonoBehaviour 
{
    public List<GameObject> piratePrefabs;
    public List<int> killCount;
    public int pirateType;

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

    public void SaveKillCount(int idx)
    {
        Debug.Log("save id " + idx + " value = " + killCount[idx]);
        PlayerPrefs.SetInt("KillCount" + idx, killCount[idx]);
    }
}
