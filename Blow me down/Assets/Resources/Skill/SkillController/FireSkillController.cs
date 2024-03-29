﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FireSkillController : MonoBehaviour, ISkillController 
{
    private GameObject laneSelector;
    private List<Vector2> spawnPosition;

	public AudioClip fireSound;

    //attribute
    public GameObject fireSkill;
    public float cooldown;
    private float timePassed;
    private int state;
    private static int IDLE = 1;
    private static int DELAY = 2;
    private static string READY = "Ready";

    //ui button
    private Button button;
    private Text textDelay;

    void Awake()
    {
        laneSelector = GameObject.Find("FireSkillLaneSelector");
    }

	// Use this for initialization
	void Start () 
    {
        //attribute
        timePassed = cooldown;
        state = IDLE;

        //get
        button = GameObject.Find("FireButton").GetComponent<Button>();
        textDelay = button.transform.Find("Delay").GetComponent<Text>();
        textDelay.text = READY;
        spawnPosition = new List<Vector2>();
        for (int i = 1; i <= 4; i++)
        {
            GameObject spawnPoint = GameObject.Find("Spawner" + i);
            spawnPosition.Add(new Vector2(-2.41f, spawnPoint.transform.position.y - 0.2f));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.CooldownHandler();
	}

    public void SpawnSkill()
    {
        if (state != IDLE)
            return;

        laneSelector.GetComponent<ContainerController>().Open();
        this.DisableButton();
    }

    public void SpawnAt(int i)
    {
        GameObject spawnedSkill = (GameObject)Instantiate(fireSkill);
        spawnedSkill.transform.position = spawnPosition[3 - i];
        laneSelector.GetComponent<ContainerController>().Close();
		GetComponent<AudioSource> ().PlayOneShot (fireSound);
		print("mon");
        state = DELAY;
    }

    public void HandleDestroyedSkill(GameObject g)
    {
        GameObject.Destroy(g.gameObject);
    }


    public void DisableButton()
    {
        button.enabled = false;
    }

    public void EnableButton()
    {
        button.enabled = true;
    }

    public void CooldownHandler()
    {
        if (timePassed < 0)
        {
            timePassed = cooldown;
            state = IDLE;
            this.EnableButton();
            textDelay.text = READY;
        }
        if (state == DELAY)
        {
            timePassed -= Time.deltaTime;
            int tmp = (int)timePassed;
            textDelay.text = tmp.ToString();
        }
    }
}
