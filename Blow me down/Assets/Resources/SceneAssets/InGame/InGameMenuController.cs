using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenuController : MonoBehaviour 
{
    // UI attribute
    private Text money;
    private Text wave;
    private GameObject pauseLayer;
    private GameObject congratsLayer;

    // datacontroller
    private DataController dataController;
    private MasterData masterData;
    private int pMoney;
    private int pWave;
    private int pMiniWave;

	// Use this for initialization
	void Start () 
    {
        Init();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (pMoney != dataController.PlayerMoney)
        {
            pMoney = dataController.PlayerMoney;
            SetMoneyText(pMoney);
        }

        if (pWave != dataController.PlayerWave || pMiniWave != dataController.PlayerMiniWave)
        {
            pWave = dataController.PlayerWave;
            pMiniWave = dataController.PlayerMiniWave;
            SetWaveText(pWave, pMiniWave);
        }
	}

    //
    void Init()
    {
        Time.timeScale = 1;

        masterData = GameObject.Find("MasterData").GetComponent<MasterData>();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        pMoney = dataController.PlayerMoney;
        pWave = dataController.PlayerWave;
        pMiniWave = dataController.PlayerMiniWave;

        money = GameObject.Find("Money").GetComponent<Text>();
        wave = GameObject.Find("Wave").GetComponent<Text>();
        SetMoneyText(pMoney);
        SetWaveText(pWave, pMiniWave);

        pauseLayer = GameObject.Find("PauseLayer");
        pauseLayer.transform.localScale = new Vector3(1, 1, 1);
        pauseLayer.SetActive(false);

        congratsLayer = GameObject.Find("CongratsLayer");
        congratsLayer.transform.localScale = new Vector3(1, 1, 1);
        congratsLayer.SetActive(false);
    }

    // set money text
    void SetMoneyText(int m)
    {
        money.text = m + " $";
    }

    // set wave : miniwave text
    void SetWaveText(int w, int mw)
    {
        wave.text = w.ToString();
    }

    // restart game
    public void GameRestart()
    {
        //restart logic
        Application.LoadLevel(Application.loadedLevel);
    }

    // exit game
    public void GameExit()
    {
        //exit logic
        Application.LoadLevel("MainMenu");
        //Application.Quit();
    }

    // pause game
    public void GamePause()
    {
        Time.timeScale = 0;
        pauseLayer.SetActive(true);
    }

    // resume game
    public void GameResume()
    {
        Time.timeScale = 1;
        pauseLayer.SetActive(false);
    }

    // end of game
    public void Congratulations()
    {
        Time.timeScale = 0;
        float score = 0;
        int waveScore = dataController.PlayerWave;
        float killScore = dataController.PlayerKill;
        int killDigit = 0;
        int someNumber = 1;
        for (int i = 1; i < 1000000; i++)
        {
            if(killScore >= someNumber)
            {
                killDigit++;
            }
            else if (killScore < someNumber)
            {
                break;
            }

            someNumber *= 10;
        }

        killScore = killScore / (10 * killDigit);
        score = waveScore + killScore;
        Debug.Log("wave = " + waveScore);
        Debug.Log("killdigit = " + killDigit);
        Debug.Log("kill = " + killScore);
        Debug.Log("score = " + score);
        masterData.AddScore(score);
        
        congratsLayer.SetActive(true);
        //Debug.Log("congrats");
    }
}
