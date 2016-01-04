using UnityEngine;
using System.Collections;

public class FireSkill : MonoBehaviour, ISkill
{
    private float timePassed;

    public float duration;
    public float slow;
    public int damage;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (timePassed > duration)
        {
            this.Destroy();
        }
        timePassed += Time.deltaTime;
	}

    public void Action()
    {
        throw new System.NotImplementedException();
    }

    public int Damage()
    {
        return damage;
    }

    public Vector2 AreaOfEffect()
    {
        throw new System.NotImplementedException();
    }

    public void SetTarget(GameObject g)
    {
        throw new System.NotImplementedException();
    }

    public void Destroy()
    {
        GameObject.Find("FireSkillController").GetComponent<ISkillController>().HandleDestroyedSkill(this.gameObject);
    }
}
