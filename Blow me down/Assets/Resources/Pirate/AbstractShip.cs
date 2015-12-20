using UnityEngine;
using System.Collections;

public abstract class AbstractShip : MonoBehaviour, IShip
{
    // ship attr
    public int healthPoint;
    public float speed;
    public int moneyWorth;
    private Vector2 heading;
    private bool destroyed;

    // controller
    private PirateSpawnerController pirateSpawnerController;

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

    public void Init()
    {
        heading = new Vector2(-1.0f, 0.0f);
        destroyed = false;
    }

    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = heading * speed;
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
        GameObject.Destroy(this.gameObject);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            this.GetDamage(col.transform.GetComponent<IBullet>().Damage());
            col.transform.GetComponent<IBullet>().Die();
        }

        if (col.tag == "MustNotInvadedLineEver")
        {
            this.KillThePlayer();
            Debug.Log("ahhhhhh");
        }

        if (col.tag == "Fire" || col.tag == "Thunder")
        {
            Debug.Log("aaaaaaa");
            this.GetDamage(col.GetComponent<ISkill>().Damage());
        }
    }
}
