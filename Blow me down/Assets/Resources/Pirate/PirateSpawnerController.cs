using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PirateSpawnerController : MonoBehaviour 
{
    // pirate object
    private List<GameObject> pirates;
    private GameObject basicPirate;

    // spawner
    private float spawnDelay;
    private float delayCounter;
    private Vector3[] spawnPositionArray = new[] {
		new Vector3(0, 0, 0), 
		new Vector3(0, 0, 0), 
		new Vector3(0, 0, 0),
        new Vector3(0, 0, 0)
    };
    private int[] spawnPositionWeight = new[] {0, 0, 0, 0};

    // datacontroller
    DataController dataController;

	// Use this for initialization
	void Start ()
    {
        Init();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(delayCounter >= spawnDelay)
        {
            int idx = RandomNumberGenerator();
            spawnPositionWeight[idx]++;
            GameObject spawnedPirate = Instantiate(basicPirate);
            spawnedPirate.transform.position = spawnPositionArray[idx];
            spawnedPirate.GetComponent<IShip>().SetSpawner(this.GetComponent<PirateSpawnerController>());
            pirates.Add(spawnedPirate);
            delayCounter = 0.0f;
        }
        delayCounter += Time.deltaTime;
	}

    // setter getter
    public List<GameObject> Pirates
    {
        get { return pirates; }
        set { pirates = value; }
    }

    void Init()
    {
        dataController = GameObject.Find("DataController").GetComponent<DataController>();

        pirates = new List<GameObject>();
        spawnDelay = 2.0f;
        delayCounter = 0.0f;

        InitSpawnerCoordinates();
        LoadPirate();
    }

    // init spawner
    void InitSpawnerCoordinates()
    {
        for (int i = 0; i < 4; i++)
        {
            spawnPositionArray[i] = GameObject.Find("Spawner" + (i + 1)).transform.position;
        }
    }

    //
    void LoadPirate()
    {
        basicPirate = Resources.Load<GameObject>("Pirate/BasicPirate");
    }

    //
    int RandomNumberGenerator()
    {
        int maxWeight = 0;
        int idx = Random.Range(0, 4);
        for (int i = 0; i < spawnPositionWeight.Length; i++)
        {
            if(spawnPositionWeight[i] >= spawnPositionWeight[maxWeight])
            {
                maxWeight = i;
            }
        }
        //Debug.Log("generated idx = " + idx + " while max at = " + spawnPositionWeight[maxWeight]);
        //check if the value was sering dipanggil
        if(idx == maxWeight)
        {
            idx = RandomNumberGenerator();
        }

        return idx;
    }

    // handle destroyed pirate
    public void HandleDestroyedPirate(GameObject obj)
    {
        pirates.Remove(obj);
        dataController.GetMoneyFromDestroyedPirate(obj);
    }
}
