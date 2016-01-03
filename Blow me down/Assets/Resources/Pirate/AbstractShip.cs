using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractShip : MonoBehaviour, IShip
{
    // ship attr
    public int healthPoint;
    public float speed;
    public int moneyWorth;
    public int bulletDrop;
    public GameObject bulletDropText;
    private Vector2 heading;
    private bool destroyed = false;
    private bool isDestroyedByCannon = false;
	public AudioClip soundDie;

    // information
    public string shipName;
    public string shipDescription;

    // controller
    private PirateSpawnerController pirateSpawnerController;
    private ActionButtonController actionButtonController;
    private MasterData masterData;
    private DataController dataController;
	private SoundPirate soundPirate;

    // Use this for initialization
    void Start()
    {
        Init();
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoint <= 0 && !IsDestroyed())
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public virtual int GetId()
    {
        return -1;
    }

    public void Init()
    {
        heading = new Vector2(-1.0f, 0.0f);
        destroyed = false;
        actionButtonController = GameObject.Find("ActionButtonController").GetComponent<ActionButtonController>();
        masterData = GameObject.Find("MasterData").GetComponent<MasterData>();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
		soundPirate = GameObject.Find ("SoundPirate").GetComponent<SoundPirate> ();
    }

    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = heading * speed * Time.deltaTime;
    }

    public void GetDamage(int damage)
    {
        healthPoint -= damage;
    }

    public void Die()
    {
        destroyed = true;
        pirateSpawnerController.HandleDestroyedPirate(this.gameObject);
    }

    public bool IsDestroyed()
    {
        return destroyed;
    }

    public int MoneyWorth()
    {
        return moneyWorth;
    }

    public void Destroy()
    {
		//GetComponent <AudioSource> ().PlayOneShot (soundDie);
		soundPirate.SoundPirates (this.GetId ());
        SpawnBulletDropAmount();
        if(!isDestroyedByCannon)
        {
            List<GameObject> cannons = actionButtonController.cannons;
            foreach (GameObject cannon in cannons)
            {
                cannon.GetComponent<ICannon>().AddBullet((int)bulletDrop / 4);
            }
        }
        if (this.GetId() >= 0)
        {
            //Debug.Log("sid " + this.GetId());
            masterData.killCount[this.GetId()]++;
            masterData.SaveKillCount(this.GetId());
        }
        dataController.PlayerKill++;
        Debug.Log("kill = " + dataController.PlayerKill);
		//GetComponent <AudioSource> ().PlayOneShot (soundDie);
        GameObject.Destroy(this.gameObject);
		//GetComponent <AudioSource> ().PlayOneShot (soundDie);
    }

    public void SetSpawner(PirateSpawnerController spawner)
    {
        pirateSpawnerController = spawner;
    }

    public void KillThePlayer()
    {
        destroyed = true;
        pirateSpawnerController.HandlePirateKillingPlayer(this.gameObject);
    }
    
    public int BulletDrop()
    {
        return bulletDrop;
    }

    public void SpawnBulletDropAmount()
    {
        GameObject spawnedGameObject = Instantiate(bulletDropText);
        spawnedGameObject.transform.position = this.transform.position;
        spawnedGameObject.transform.SetParent(GameObject.Find("Canvas").transform, true);
        spawnedGameObject.transform.localScale = Vector3.one;
        if(!isDestroyedByCannon)
            spawnedGameObject.GetComponent<Text>().text = "+" + ((int)bulletDrop / 4) + " all";
        else
            spawnedGameObject.GetComponent<Text>().text = "+" + bulletDrop;
        //Debug.Log("Drop " + bulletDrop);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
			//GetComponent <AudioSource> ().PlayOneShot (soundDie);
            this.GetDamage(col.transform.GetComponent<IBullet>().Damage());
            if (healthPoint <= 0 && !IsDestroyed())
            {
                col.transform.GetComponent<IBullet>().GetBulletDrop(bulletDrop);
                isDestroyedByCannon = true;
				//print ("dan");
				//GetComponent <AudioSource> ().PlayOneShot (soundDie);
            }
            col.transform.GetComponent<IBullet>().Die();
        }

        if (col.tag == "MustNotInvadedLineEver")
        {
            this.KillThePlayer();
            Debug.Log("ahhhhhh");
        }

        if (col.tag == "Fire" || col.tag == "Thunder")
        {
            this.GetDamage(col.GetComponent<ISkill>().Damage());
        }
    }


    public string ShipName
    {
        get { return shipName; }
    }

    public string ShipDescription
    {
        get { return shipDescription; }
    }
}
