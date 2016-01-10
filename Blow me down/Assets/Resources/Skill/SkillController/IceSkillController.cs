using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IceSkillController : MonoBehaviour, ISkillController
{
    //pirate controller
    private PirateSpawnerController pirateSpawnerController;

    //attribute
    public GameObject iceSkill;
    public GameObject iceCircle;
    private List<GameObject> iceSkills;
    public float cooldown;
    private float timePassed;
    private int state;
    private static int IDLE = 1;
    private static int DELAY = 2;
    private static string READY = "Ready";

    //ui button
    private Button button;
    private Text textDelay;

	// Use this for initialization
	void Start ()
    {
        //attr set
        //cooldown = 10;
        timePassed = cooldown;
        state = IDLE;

        //get
        pirateSpawnerController = GameObject.Find("PirateSpawnerController").GetComponent<PirateSpawnerController>();
        iceSkills = new List<GameObject>();
        button = GameObject.Find("IceButton").GetComponent<Button>();
        textDelay = button.transform.Find("Delay").GetComponent<Text>();
        textDelay.text = READY;
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

        Instantiate(iceCircle);

        List<GameObject> pirates = pirateSpawnerController.Pirates;
        for (int i = 0; i < pirates.Count; i++)
        {
            GameObject spawnedSkill = (GameObject)Instantiate(iceSkill);
            spawnedSkill.transform.position = pirates[i].transform.position;
            spawnedSkill.GetComponent<ISkill>().SetTarget(pirates[i]);
            iceSkills.Add(spawnedSkill);
        }
        state = DELAY;
        this.DisableButton();
    }

    public void HandleDestroyedSkill(GameObject g)
    {
        iceSkills.Remove(g);
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
