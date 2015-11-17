﻿using UnityEngine;
using System.Collections;

public class BasicPirate : MonoBehaviour, IShip 
{
    // ship attr
    private int healthPoint;
    private float speed;
    private Vector2 heading;
    private int moneyWorth;
    private bool destroyed;

    // controller
    private PirateSpawnerController pirateSpawnerController;

	// Use this for initialization
	void Start () 
    {
        Init();
        Move();
	}
	
	// Update is called once per frame
	void Update () 
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
    
    //
    public void Init()
    {
        healthPoint = 60;
        moneyWorth = 10;
        heading = new Vector2(-1.0f, -0.575f);
        speed = 1.0f;
        destroyed = false;
    }

    //
    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = heading * speed;
    }

    //
    public void GetDamage(int damage)
    {
        healthPoint -= damage;
    }

    //
    public void Die()
    {
        destroyed = true;
        pirateSpawnerController.HandleDestroyedPirate(this.gameObject);
    }

    //
    public bool IsDestroyed()
    {
        return destroyed;
    }

    // 
    public int MoneyWorth()
    {
        return moneyWorth; 
    }

    //
    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }

    //
    public void SetSpawner(PirateSpawnerController spawner)
    {
        pirateSpawnerController = spawner;
    }

    //
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            GetDamage(col.transform.GetComponent<IBullet>().Damage());
            col.transform.GetComponent<IBullet>().Die();
            //GameObject.Destroy(col.gameObject);
        }

        if (col.tag == "MustNotInvadedLineEver")
        {
            Die();
        }
    }
}
