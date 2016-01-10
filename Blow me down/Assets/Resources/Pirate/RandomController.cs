using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomController : MonoBehaviour {

	//wave
	private int wave;
	private int miniWave;
	private int flagMiniWave;
	private float waveTime;

	//amount of pirate
	public int amountBasicPirate;
	public int amountMediumPirate;
	public int amountBossPirate;
	public int totalShip = -1;

	//range of pirate
	private float minBasicPirate;
	private float maxBasicPirate;
	private float minMediumPirate;
	private float maxMediumPirate;
	private float minBossPirate;
	private float maxBossPirate;
	private float rng;

	// datacontroller
	DataController dataController;

	void Awake (){
		amountBasicPirate = 3;
		amountBossPirate = 0;
		amountMediumPirate = 0;
		totalShip = amountBasicPirate * 4;

		minBasicPirate = 5.0f;
		maxBasicPirate = 15.0f;
		minMediumPirate = 15.0f;
		maxMediumPirate = 30.0f;
		minBossPirate = 60.0f;
		maxBossPirate = 80.0f;
		flagMiniWave = 0;
		waveTime = 0.0f;
	}

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (totalShip == 0) {
			dataController.PlayerWave++;
			dataController.PlayerMiniWave = 1;
			wave = dataController.PlayerWave;
			//miniWave = dataController.PlayerMiniWave
			SetAmountPirates ();
			waveTime = 0.0f;
		}
		if (wave > 5) {
			if (flagMiniWave == 0) {
				if (waveTime > 60.0f) {
					dataController.PlayerMiniWave++;
					//miniWave = dataController.PlayerMiniWave;
					flagMiniWave = 1;
				}
			}
		}
		if (wave > 10) {
			if (flagMiniWave == 1) {
				if (waveTime > 120.0f) {
					dataController.PlayerMiniWave++;
					//miniWave = dataController.PlayerMiniWave;
					flagMiniWave = 2;
				}
			}
		}
		waveTime += Time.deltaTime;
	}

	public float RangeRandomGenerator (int x){
		if (wave >= 1 || wave <= 15) {
			if (x == 1) {
				if (flagMiniWave == 1) {
					rng = Random.Range (minBasicPirate - 1.0f , maxBasicPirate - 2.5f);
				}
				else if (flagMiniWave == 2) {
					rng = Random.Range (minBasicPirate - 2.5f , maxBasicPirate - 5.0f);
				}
				else
					rng = Random.Range (minBasicPirate, maxBasicPirate);
			} 
			else if (x == 2) {
				if (flagMiniWave == 1) {
					rng = Random.Range (minMediumPirate - 0.5f, maxMediumPirate - 2.5f);
				}
				else if (flagMiniWave == 2) {
					rng = Random.Range (minMediumPirate - 2.0f , maxMediumPirate - 4.5f);
				}
				else
					rng = Random.Range (minMediumPirate, maxMediumPirate);
			} 
			else if (x == 3) {
				rng = Random.Range (minBossPirate, maxBossPirate);
			}
			return rng;
		} 
		else
			return 2.0f;
	}

	void Init () {
		dataController = GameObject.Find("DataController").GetComponent<DataController>();
		wave = dataController.PlayerWave;
		miniWave = dataController.PlayerMiniWave;

		//noBasicPirate = 0;
		
	}

	void SetAmountPirates () {
		if (wave >= 1 || wave <= 5) {
			amountBasicPirate += 1;
		}
		else if (wave >= 6 || wave <= 15)
			amountBasicPirate += 2;
		if ((wave % 3) == 0) {
			amountMediumPirate += 2;
		}
		if ((wave % 5) == 0) {
			amountBossPirate +=1;
		}

		totalShip = amountBasicPirate * 4 + amountMediumPirate * 4 + amountBossPirate;
	}
}
