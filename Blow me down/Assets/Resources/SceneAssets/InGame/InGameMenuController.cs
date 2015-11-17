using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenuController : MonoBehaviour 
{
    // UI attribute
    private Text money;
    private Text wave;

    // datacontroller
    private DataController dataController;
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
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        pMoney = dataController.PlayerMoney;
        pWave = dataController.PlayerWave;
        pMiniWave = dataController.PlayerMiniWave;

        money = GameObject.Find("Money").GetComponent<Text>();
        wave = GameObject.Find("EnemyWave").GetComponent<Text>();
        SetMoneyText(pMoney);
        SetWaveText(pWave, pMiniWave);
    }

    // set money text
    void SetMoneyText(int m)
    {
        money.text = "Money = " + m;
    }

    // set wave : miniwave text
    void SetWaveText(int w, int mw)
    {
        wave.text = "WAVE ( " + w + " : " + mw + " )";
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
        //Application.LoadLevel("Main Menu");
        Application.Quit();
    }
}
