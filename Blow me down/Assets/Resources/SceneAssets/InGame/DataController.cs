using UnityEngine;
using System.Collections;

public class DataController : MonoBehaviour 
{
    // player progression
    private int money;
    private int wave;
    private int miniWave;

    // piratespawnercontroller
    private PirateSpawnerController pirateSpawnerController;
    private int numberOfPirates;

    // ingame menu controller
    private InGameMenuController inGameMenuController;

	// Use this for initialization
	void Start () 
    {
        Init();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (numberOfPirates != pirateSpawnerController.Pirates.Count)
        {
            numberOfPirates = pirateSpawnerController.Pirates.Count;
        }
	}

    // getter
    public int PlayerMoney
    {
        get { return money; }
        set { money = value; }
    }

    public int PlayerWave
    {
        get { return wave; }
		set { wave = value; }
    }

    public int PlayerMiniWave
    {
        get { return miniWave; }
		set { miniWave = value; }
    }

    //
    public void Init()
    {
        money = 0;
        wave = 1;
        miniWave = 1;

        pirateSpawnerController = GameObject.Find("PirateSpawnerController").GetComponent<PirateSpawnerController>();
        numberOfPirates = 0;

        inGameMenuController = GameObject.Find("InGameMenuController").GetComponent<InGameMenuController>();
    }

    // get money from destroyed pirate
    public void GetMoneyFromDestroyedPirate(GameObject obj)
    {
        IShip pirate = obj.GetComponent<IShip>();
        money += pirate.MoneyWorth();
        //pirate.Destroy();
    }

    // end of the game
    public void End()
    {
        inGameMenuController.Congratulations();
        //Debug.Log("end");
    }
}
