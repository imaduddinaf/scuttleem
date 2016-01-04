using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PirateSpawnerController : MonoBehaviour 
{
    // pirate object
    private List<GameObject> pirates;
    public GameObject basicPirate;
    public GameObject mediumPirate;
    public GameObject bossPirateOne;

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
	private float[] delayBasicPirate = new[] {0.0f, 0.0f, 0.0f, 0.0f};
	private float[] delayMediumPirate = new[] {0.0f, 0.0f, 0.0f, 0.0f};
	private float[] delayBossPirate = new[] {0.0f, 0.0f, 0.0f, 0.0f};

	//count of pirate
	private int[] countBasicPirate = new[] {0, 0, 0, 0};
	private int[] countMediumPirate = new[] {0, 0, 0, 0};
	private int[] countBossPirate = new[] {0, 0, 0, 0};
	private int countDestroyShip = 0;

	//audio if die
	//public AudioClip pirateDestroy;

    // datacontroller
    DataController dataController;

	// randomcontroller
	RandomController randomController;

	// Use this for initialization
	void Start ()
    {
        Init();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    /*if(delayCounter >= spawnDelay)
        {
            int idx = RandomNumberGenerator();
            spawnPositionWeight[idx]++;
			print (idx);
            GameObject spawnedPirate = Instantiate(basicPirate);
            spawnedPirate.transform.position = spawnPositionArray[idx];
            spawnedPirate.GetComponent<IShip>().SetSpawner(this.GetComponent<PirateSpawnerController>());
            pirates.Add(spawnedPirate);
            delayCounter = 0.0f;
        }
        */

		for (int i = 0; i < 4; i++) {
			if (countBasicPirate[i] > 0) {
				if (delayCounter >= delayBasicPirate[i]) {
					GameObject spawnedPirate = Instantiate(basicPirate);
					spawnedPirate.transform.position = spawnPositionArray[i];
					//print(i);
					spawnedPirate.GetComponent<IShip>().SetSpawner(this.GetComponent<PirateSpawnerController>());
					//spawnedPirate.GetComponent<IShip>().Speed(5.0f);
					pirates.Add(spawnedPirate);
					delayBasicPirate[i] += randomController.RangeRandomGenerator(1);
					countBasicPirate[i]--;
					//print (delayBasicPirate[i]);
					if (countBasicPirate[i] == 0){
						delayBasicPirate[i] = 0;
					}
				}
			}
			if (countMediumPirate[i] > 0) {
				if (delayCounter >= delayMediumPirate[i]) {
					GameObject spawnedPirate = Instantiate(mediumPirate);
					spawnedPirate.transform.position = spawnPositionArray[i];
					//print(i);
					spawnedPirate.GetComponent<IShip>().SetSpawner(this.GetComponent<PirateSpawnerController>());
					pirates.Add(spawnedPirate);
					delayMediumPirate[i] += randomController.RangeRandomGenerator(2);
					countMediumPirate[i]--;
					//print (delayMediumPirate[i]);
					if (countMediumPirate[i] == 0){
						delayMediumPirate[i] = 0;
					}
				}
			}
			if (countBossPirate[i] > 0) {
				if (delayCounter >= delayBossPirate[i]) {
					GameObject spawnedPirate = Instantiate(bossPirateOne);
					spawnedPirate.transform.position = spawnPositionArray[i];
					//print(i);
					spawnedPirate.GetComponent<IShip>().SetSpawner(this.GetComponent<PirateSpawnerController>());
					pirates.Add(spawnedPirate);
					delayBossPirate[i] += randomController.RangeRandomGenerator(3);
					countBossPirate[i]--;
					//print (delayBossPirate[i]);
					if (countBossPirate[i] == 0){
						delayBossPirate[i] = 0;
					}
				}
			}
		}
		if (countDestroyShip == randomController.totalShip) {
			//print ("test");
			countDestroyShip = 0;
			randomController.totalShip = 0;
			Invoke("SetAmountPirate",3.0f);
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
		randomController = GameObject.Find("RandomController").GetComponent<RandomController>();

        pirates = new List<GameObject>();
        spawnDelay = 2.0f;
        delayCounter = 0.0f;

        InitSpawnerCoordinates();
        LoadPirate();
		for (int i = 0; i < 4; i++) {
			countBasicPirate[i] = randomController.amountBasicPirate;
			delayBasicPirate[i] = i*2 + randomController.RangeRandomGenerator(1);
		}

    }

	//set amount of pirate
	void SetAmountPirate(){
		//randomController.totalShip = 0;
		for (int i = 0; i < 4; i++) {
			countBasicPirate[i] = randomController.amountBasicPirate;
			delayBasicPirate[i] = randomController.RangeRandomGenerator(1);
			countMediumPirate[i] = randomController.amountMediumPirate;
			delayMediumPirate[i] = randomController.RangeRandomGenerator(2);
		}
		int totalBossPirate = randomController.amountBossPirate;
		for (int i = totalBossPirate; i > 0; i--) {
			int index = Random.Range(0,4);
			countBossPirate[index]++ ;
			delayBossPirate[index] = randomController.RangeRandomGenerator(3);
		}
		delayCounter = 0.0f;
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
        //basicPirate = Resources.Load<GameObject>("Pirate/BasicPirate");
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

        IShip pirate = obj.GetComponent<IShip>();
        pirate.Destroy();
		//GetComponent <AudioSource> ().PlayOneShot (pirateDestroy);
		countDestroyShip++;
    }

    // handle pirate that killing player
    public void HandlePirateKillingPlayer(GameObject obj)
    {
        pirates.Remove(obj);
        dataController.End();
        //Debug.Log("awwww");
    }
}
