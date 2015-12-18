using UnityEngine;
using System.Collections;

public class IceSkill : MonoBehaviour, ISkill
{
    private GameObject targetShip;
    private float targetSpeed;
    private float duration;
    private float timePassed;

    public float slow;

    void Awake()
    {
        slow = 0.5f;
        duration = 5.0f;
        timePassed = 0;
    }

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (targetShip != null)
        {
            transform.position = targetShip.transform.position;
        }

        if (targetShip.GetComponent<IShip>().IsDestroyed() || timePassed > duration)
        {
            this.Destroy();
        }

        timePassed += Time.deltaTime;
	}

    public void Action()
    {
        //
        Debug.Log("icee");
    }

    public int Damage()
    {
        throw new System.NotImplementedException();
    }

    public Vector2 AreaOfEffect()
    {
        throw new System.NotImplementedException();
    }


    public void SetTarget(GameObject g)
    {
        targetShip = g;
        targetSpeed = g.GetComponent<IShip>().Speed;

        g.GetComponent<IShip>().Speed = targetSpeed - (targetSpeed * slow);
    }


    public void Destroy()
    {
        if (targetShip != null)
        {
            targetShip.GetComponent<IShip>().Speed = targetSpeed;
        }
        GameObject.Find("IceSkillController").GetComponent<ISkillController>().HandleDestroyedSkill(this.gameObject);
    }
}
