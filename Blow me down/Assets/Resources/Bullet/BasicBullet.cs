using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour, IBullet 
{
    private int attackDamage;
    private ICannon cannon;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    //
    public void SetDamage(int damage)
    {
        attackDamage = damage;
    }

    //
    public int Damage() 
    {
        return attackDamage;
    }

    //
    public void Shot(Vector2 direction, float speed)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }

    //
    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }

    //
    public void Die()
    {
        cannon.DestroyBullet(this.gameObject);
    }

    //
    public void SetCannon(ICannon cannon)
    {
        this.cannon = cannon;
    }
    
    public void GetBulletDrop(int n)
    {
        cannon.AddBullet(n);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BulletDestroyer")
        {
            Die();
        }
    }
}
