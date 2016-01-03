using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour 
{
    public GameObject highScoreContainer;
    private MasterData masterData;

	// Use this for initialization
	void Start () 
    {
        masterData = GameObject.Find("MasterData").GetComponent<MasterData>();
        GetHighScore();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Play()
    {
        Application.LoadLevel("InGame");
    }

    public void Almanac()
    {
        Application.LoadLevel("Ensiklopedia");
    }
    
    public void Sound()
    {

    }

    public void ShowHighScore()
    {
        highScoreContainer.GetComponent<ContainerController>().Open();
    }

    public void HideHighScore()
    {
        highScoreContainer.GetComponent<ContainerController>().Close();
    }

    public void GetHighScore()
    {
        for (int i = 0; i < masterData.maxHighScore; i++)
        {
            GameObject tmpContainer = GameObject.Find("TheScore" + (i + 1));
            Text sWave = tmpContainer.transform.Find("Wave").GetComponent<Text>();
            Text sKill = tmpContainer.transform.Find("Kill").GetComponent<Text>();

            string[] strScore = masterData.highScores[i].ToString().Split('.');
            sWave.text = strScore[0];
            if (strScore.Length < 2)
                sKill.text = "0";
            else
                sKill.text = strScore[1];
        }
    }
}
