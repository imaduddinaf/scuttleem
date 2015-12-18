using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicCannon : MonoBehaviour, ICannon, INormalCannon 
{
    //
    private List<GameObject> bullets;
    private GameObject bullet;

    // attribute
    public int attackDamage;
    public int bulletSpeed;
    public float attackSpeed;
    public float attackCooldown;
    private bool isCooldown;
    private Vector2 heading;
    private GameObject spawner;

    // animator
    private Animator animator;
    private const int IDLE = 1;
    private const int SHOT = 1;

	// Use this for initialization
	void Start () 
    {
        Init();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isCooldown)
        {
            attackCooldown -= Time.deltaTime;
        }
        if (attackCooldown <= 0)
        {
            isCooldown = false;
            attackCooldown = attackSpeed;
        }
	}

    //
    public void Init()
    {
        bullets = new List<GameObject>();
        //attackDamage = 10;
        //bulletSpeed = 100;
        //attackSpeed = 10.0f;
        heading = new Vector2(1.0f, 0.0f);
        attackCooldown = attackSpeed;
        isCooldown = false;
        LoadBullet();
        animator = GetComponent<Animator>();
        spawner = transform.Find("spawner").gameObject;
    }

    //
    public void LoadBullet()
    {
        bullet = Resources.Load<GameObject>("Bullet/BasicBullet");
    }

    // 
    public void Attack()
    {
        if (isCooldown)
        {
            return;
        }
        //animator.SetInteger("State", SHOT);
        animator.SetBool("Shot", true);
        //animator.SetBool("Shot", false);
        SpawnBullet(heading);
        attackCooldown = attackSpeed;
        isCooldown = true;
    }

    //
    public void Upgrade()
    {
        GameObject nextLevel = Resources.Load<GameObject>("Cannon/cannon2");
        GameObject spawned = Instantiate(nextLevel);
        spawned.transform.SetParent(GameObject.Find("Cannons").transform);
        //spawned.transform.localPosition = new Vector2(this.transform.position.x, this.transform.position.y + 0.57f);
        spawned.tag = this.transform.tag;
        Destroy();
    }

    //
    public void SpawnBullet(Vector2 direction)
    {
        GameObject bulletSpawn = Instantiate(bullet);
        bulletSpawn.GetComponent<IBullet>().Shot(direction, bulletSpeed);
        bulletSpawn.GetComponent<IBullet>().SetDamage(attackDamage);
        bulletSpawn.GetComponent<IBullet>().SetCannon(this.GetComponent<ICannon>());
        bulletSpawn.transform.position = spawner.transform.position;
        bullets.Add(bulletSpawn);
    }

    //
    public void DestroyBullet(GameObject obj)
    {
        IBullet bullet = obj.GetComponent<IBullet>();
        bullets.Remove(obj);
        bullet.Destroy();
    }

    //
    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
