using UnityEngine;
using System.Collections;

public class ActionButtonController : MonoBehaviour 
{
    public GameObject yellowCannon;
    public GameObject greenCannon;
    public GameObject redCannon;
    public GameObject blueCannon;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    // yellow cannon
    public void YellowCannonFire()
    {
        yellowCannon = GameObject.FindGameObjectWithTag("YellowCannon");
        yellowCannon.GetComponent<ICannon>().Attack();
    }

    // green cannon
    public void GreenCannonFire()
    {
        greenCannon = GameObject.FindGameObjectWithTag("GreenCannon");
        greenCannon.GetComponent<ICannon>().Attack();
    }

    // red cannon
    public void RedCannonFire()
    {
        redCannon = GameObject.FindGameObjectWithTag("RedCannon");
        redCannon.GetComponent<ICannon>().Attack();
    }

    // blue cannon
    public void BlueCannonFire()
    {
        blueCannon = GameObject.FindGameObjectWithTag("BlueCannon");
        blueCannon.GetComponent<ICannon>().Attack();
    }

    public void Up()
    {
        yellowCannon = GameObject.FindGameObjectWithTag("YellowCannon");
        yellowCannon.GetComponent<ICannon>().Upgrade();
    }
}
