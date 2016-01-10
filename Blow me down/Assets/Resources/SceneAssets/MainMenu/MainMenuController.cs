using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour 
{
    public GameObject highScoreContainer;
    public GameObject helpContainer;
    private Image helpContent;
    private int helpContentIdx;
    private MasterData masterData;

    private Button soundButton;
    public List<Sprite> soundButtonSprite;
    public List<Sprite> helpSprite;

    void Awake()
    {
        helpContent = GameObject.Find("HelpContent").GetComponent<Image>();
    }

	// Use this for initialization
	void Start () 
    {
        masterData = GameObject.Find("MasterData").GetComponent<MasterData>();
        soundButton = GameObject.Find("Sound").GetComponent<Button>();

        helpContentIdx = 0;
        LoadHelpContent();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Time.timeScale = 0;
            Application.Quit();
            //quit = true;
            //Pause();
        }

        if (AudioListener.volume == 0.0)
        {
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[1];
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundButtonSprite[0];
        }
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
        if (masterData.volume == 0.0)
        {
            masterData.volume = 1.0f;
            AudioListener.volume = 1.0f;
        }
        else
        {
            masterData.volume = 0.0f;
            AudioListener.volume = 0.0f;
        }
        masterData.SaveSoundVolume();
    }

    public void ShowHighScore()
    {
        highScoreContainer.GetComponent<ContainerController>().Open();
        GetHighScore();
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
			else{
				sKill.text = strScore[1];
			} 
        }
    }

    public void ShowHelp()
    {
        helpContainer.GetComponent<ContainerController>().Open();
    }

    public void HideHelp()
    {
        helpContainer.GetComponent<ContainerController>().Close();
    }

    public void NextHelp()
    {
        helpContentIdx++;
        if (helpContentIdx > helpSprite.Count - 1)
            helpContentIdx = 0;

        LoadHelpContent();
    }

    public void PrevHelp()
    {
        helpContentIdx--;
        if (helpContentIdx < 0)
            helpContentIdx = helpSprite.Count - 1;

        LoadHelpContent();
    }

    public void LoadHelpContent()
    {
        helpContent.sprite = helpSprite[helpContentIdx];
    }
}
