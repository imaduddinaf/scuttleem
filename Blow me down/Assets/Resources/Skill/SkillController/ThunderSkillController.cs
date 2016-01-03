using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ThunderSkillController : MonoBehaviour, ISkillController
{
    private GameObject spawnArea;
    private Vector2 spawnPosition;

	public AudioClip thunderSound;

    //attribute
    public GameObject thunderSkill;
    public float cooldown;
    private float timePassed;
    private int state;
    private static int IDLE = 1;
    private static int DELAY = 2;
    private static string READY = "Ready";
    private bool getInput;

    //ui button
    private Button button;
    private Text textDelay;

    void Awake()
    {
        spawnArea = GameObject.Find("ThunderArea");
    }

	// Use this for initialization
	void Start ()
    {
        //attribute
        timePassed = 0;
        state = IDLE;
        getInput = false;

        //get
        button = GameObject.Find("ThunderButton").GetComponent<Button>();
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

        spawnArea.GetComponent<ContainerController>().Open();        
    }

    public void SpawnAt()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 pos = Input.GetTouch(0).position;
            pos = Camera.main.ScreenToWorldPoint(pos);

            GameObject spawnedSkill = (GameObject)Instantiate(thunderSkill);
            spawnedSkill.transform.position = pos;
            spawnArea.GetComponent<ContainerController>().Close();
			GetComponent<AudioSource> ().PlayOneShot (thunderSound);
            state = DELAY;
        }
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
        if (timePassed > cooldown)
        {
            timePassed = 0;
            state = IDLE;
            this.EnableButton();
            textDelay.text = READY;
        }
        if (state == DELAY)
        {
            timePassed += Time.deltaTime;
            int tmp = (int)timePassed;
            textDelay.text = tmp.ToString();
        }
    }
}
